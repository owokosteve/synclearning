namespace synclearning;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to SYNC LEARNING PORTAL!");
        Console.WriteLine("How can we help you today? Select one option below.");

        bool isValidOption = false;

        do
        {
            Console.WriteLine("\n[1] Registration\n[2] Login\n[3] Exit");
            Console.Write("\nEnter your options (1, 2 or 3): ");
            string option = Console.ReadLine()!.Trim();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Registration...");
                    isValidOption = true;
                    break;
                case "2":
                    Console.WriteLine("Login in...");
                    isValidOption = true;
                    break;
                case "3":
                    Console.WriteLine("Exiting application...");
                    isValidOption = true;
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please select (1, 2 or 3)");
                    isValidOption = false;
                    break;
            }
        } while (isValidOption == false);


    }
}
