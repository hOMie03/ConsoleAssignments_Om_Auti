namespace Assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int flag = 0, bal=0;
            int[,] userData = new int[2, 2]
            {
                { 101, 10000 },
                { 102, 69000 }
            };
            takeID:
            Console.WriteLine("Please enter your user ID: ");
            int userID;
            bool isID = int.TryParse(Console.ReadLine(), out userID);
            if (isID == false)
            {
                Console.WriteLine("Please enter correct ID.");
                goto takeID;
            }
            for (int i = 0; i < userData.GetLength(0); i++)
            {
                if (userData[i, 0] == userID)
                {
                    bal = userData[i, 1];
                    flag = 1;
                    break;
                }
                else
                {
                    flag = 0;
                }
            }
            if (flag == 1)
            {
                Console.WriteLine($"Your available wallet balance is Rs. {bal}.");
            }
            else
            {
                Console.WriteLine("Wrong User ID entered. Please enter again.");
                goto takeID;
            }
        }
    }
}
