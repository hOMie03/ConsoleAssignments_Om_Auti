using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PPB.Application.Exceptions;
using PPB.Application.Interfaces.Identity;
using PPB.Application.Models.Identity;
using PPB.Domain.Models;

namespace PPB.Identity.Service
{
    internal class AuthService : IAuthService
    {
        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManager;
        readonly JwtSettings _jwtSettings;

        //Constructor
        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<RegistrationResponse> Register(RegistrationRequest registrationRequest)
        {
            var user = new User
            {
                UserName = registrationRequest.Email,
                Email = registrationRequest.Email,
                Name = registrationRequest.Name,
                EmailConfirmed = true
            };
            var registration = await _userManager.CreateAsync(user, registrationRequest.Password);
            if (registration.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return new RegistrationResponse() { UserID = user.Id };
            }
            else
            {
                var errorResult = registration.Errors.Select(e => e.Description).ToList();
                throw new BadRequestException($"{errorResult}");
            }
        }
        public async Task<AuthResponse> Login(AuthRequest authRequest)
        {
            var user = await _userManager.FindByEmailAsync(authRequest.Email);
            if (user == null)
            {
                throw new NotFoundException($"User with email {authRequest.Email} not exists");
            }
            var userPswd = await _signInManager.CheckPasswordSignInAsync(user, authRequest.Password, false);
            if (userPswd.Succeeded)
            {
                JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
                var response = new AuthResponse
                {
                    Id = user.Id,
                    Email = user.Email,
                    Username = user.Email,
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                };
                return response;
            }
            return null;
        }
        public async Task<JwtSecurityToken> GenerateToken(User user)
        {
            // Get user info from DB
            var userClaims = await _userManager.GetClaimsAsync(user);
            // Get list of roles that user belongs to
            var roles = await _userManager.GetRolesAsync(user);
            // Convert into Claims
            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r)).ToList();
            // Create Claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("UID", user.Id)
            }.Union(userClaims).Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256); // Generally used this type
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signingCredentials
            );
            return jwtSecurityToken;
        }

        //public async Task Logout(string token) { }
    }
}
