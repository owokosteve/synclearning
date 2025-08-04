namespace synclearning;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to SYNC LEARNING PORTAL!");
        Console.WriteLine("How can we help you today? Select one option below.");

        bool isValidOption = false;

        CourseLogic courseLogic = new CourseLogic();
        InitCourses(courseLogic);

        do
        {
            Console.WriteLine("\n[1] Registration\n[2] Login\n[3] Exit");
            Console.Write("\nEnter your options (1, 2 or 3): ");
            string option = Console.ReadLine()!.Trim();

            switch (option)
            {
                case "1":
                    courseLogic.Register();
                    break;
                case "2":
                    courseLogic.Login();
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

    static void InitCourses(CourseLogic courseLogic)
    {
        courseLogic.AddCourse(new Course("C#", "Baskaran", 5, 0));
        courseLogic.AddCourse(new Course("HTML", "Ravi", 2, 5));
        courseLogic.AddCourse(new Course("CSS", "Priyadharshini", 2, 3));
        courseLogic.AddCourse(new Course("JS", "Baskaran", 3, 1));
        courseLogic.AddCourse(new Course("TS", "Ravi", 1, 2));
    }
}
