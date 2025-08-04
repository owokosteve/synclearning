using System.Globalization;

namespace synclearning;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to SYNC LEARNING PORTAL!");
        Console.WriteLine("How can we help you today? Select one option below.");

        CourseLogic courseLogic = new CourseLogic();
        InitCourses(courseLogic);
        InitUsers(courseLogic);
        InitEnrollments(courseLogic);

        bool isValidOption = false;

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

    static void InitUsers(CourseLogic courseLogic)
    {
        courseLogic.AddUser(new User("Ravichandran", 30, Gender.Male, "ME", "9938388333", "ravi@gmail.com"));
        courseLogic.AddUser(new User("Priyadharshini", 25, Gender.Female, "BE", "9944444455", "priya@gmail.com"));
    }

    static void InitEnrollments(CourseLogic courseLogic)
    {
        courseLogic.AddEnrollment(new Enrollment("CS2001", "SYNC1001", DateTime.ParseExact("28/01/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture)));
        courseLogic.AddEnrollment(new Enrollment("CS2003", "SYNC1001", DateTime.ParseExact("15/02/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture)));
        courseLogic.AddEnrollment(new Enrollment("CS2004", "SYNC1002", DateTime.ParseExact("18/02/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture)));
        courseLogic.AddEnrollment(new Enrollment("CS2002", "SYNC1002", DateTime.ParseExact("20/02/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture)));
    }
}
