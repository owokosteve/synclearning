namespace synclearning;

public class CourseLogic
{
    private List<User> users = new List<User>();

    // Register new user
    public void Register()
    {
        Console.WriteLine("\n---Registration---");
        Console.Write("Enter username: ");
        string username = Console.ReadLine()!.Trim();
        Console.Write("Enter age: ");
        int age = int.Parse(Console.ReadLine()!.Trim());
        Console.Write("Enter gender: (Male, Female or Trans): ");
        Gender gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine()!.Trim(), true);
        Console.Write("Enter qualification: i.e. MA/BA etc.: ");
        string qualification = Console.ReadLine()!.Trim();
        Console.Write("Enter mobile number: ");
        string mobileNumber = Console.ReadLine()!.Trim();
        Console.Write("Enter mail id: ");
        string mailid = Console.ReadLine()!.Trim();

        User newUser = new User(username, age, gender, qualification, mobileNumber, mailid);
        users.Add(newUser);
        Console.WriteLine($"\nSuccess {newUser.Username}! Your UserID is {newUser.RegistrationID}");
    }

    public void Login()
    {
        Console.WriteLine("\n---Login---");
        Console.Write("Enter UserID: ");
        string userId = Console.ReadLine()!.Trim();

        // Check if ID exists
        User? user = users.Find(u => u.RegistrationID == userId);

        if (user == null)
        {
            Console.WriteLine("\nInvalid User ID. Please enter a valid one.");
        }
        else
        {
            bool isValidOption = false;
            do
            {
                Console.WriteLine("\n[a] Enroll Course\n[b] View Enrollment History\n[c] Next Enrollment\n[d] Exit");
                Console.Write("Please select options (1, 2 or 3): ");
                string option = Console.ReadLine()!.Trim();

                switch (option)
                {
                    case "a":
                        Console.WriteLine("Enrolling...");
                        break;
                    case "b":
                        Console.WriteLine("View history...");
                        break;
                    case "c":
                        Console.WriteLine("Next enrollment is on...");
                        break;
                    case "d":
                        Console.WriteLine("Exiting...");
                        isValidOption = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again!");
                        break;
                }
            } while (isValidOption == false);
        }
    }
}