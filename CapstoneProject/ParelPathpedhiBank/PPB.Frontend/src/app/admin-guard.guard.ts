import { CanActivateFn } from '@angular/router';
import { UserService } from './services/auth/user.service';
import { inject } from '@angular/core';

export const adminGuardGuard: CanActivateFn = (route, state) => {
  const userService=inject(UserService);
    if(userService.checkAdmin()){
      return true;
    }
    else{
      return false;
    }
};
