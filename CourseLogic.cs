namespace synclearning;

public class CourseLogic
{
    private List<User> users = new List<User>();
    private List<Course> courses = new List<Course>();
    private List<Enrollment> enrollments = new List<Enrollment>();

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
                Console.Write("\nPlease select options (a, b, c or d): ");
                string option = Console.ReadLine()!.Trim();

                switch (option)
                {
                    case "a":
                        EnrollCourse(user);
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

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void AddCourse(Course course)
    {
        courses.Add(course);
    }

    public void AddEnrollment(Enrollment enrollment)
    {
        enrollments.Add(enrollment);
    }

    public void EnrollCourse(User user)
    {
        // Print available courses
        Console.WriteLine("\nCOURSE ID| COURSE NAME| TRAINER NAME| DURATION| SEATS AVAILABLE|");
        Console.WriteLine(new string('-', 60));

        foreach (Course c in courses)
        {
            Console.WriteLine("{0, -10} {1, -10} {2, -15} {3, -10} {4, -10}", c.CourseID, c.CourseName, c.TrainerName, c.CourseDuration, c.SeatsAvailable);
        }

        Console.Write("\nPlease select CourseID to enroll: ");
        string courseID = Console.ReadLine()!.Trim();

        // Check if seats is available
        Course? course = courses.Find(c => c.CourseID == courseID);

        if (course?.SeatsAvailable <= 0)
        {
            Console.WriteLine("\nSeats are not available for the current course");
        }
        else
        {
            // Check if user has enrolled in any courses
            List<Enrollment> enrolledCourses = enrollments.FindAll(ec => ec.RegistrationID == user.RegistrationID);
            int enrollmentCount = enrolledCourses.Count;

            if (enrollmentCount < 2)
            {
                // Enroll user and add to database
                AddEnrollment(new Enrollment(courseID, user.RegistrationID, DateTime.Now));
            }
            else
            {
                // Get the course for the enrolledCourses
                Course? currentEnrolledCouse1 = courses.Find(c => c.CourseID == enrolledCourses[0].CourseID);
                Course? currentEnrolledCouse2 = courses.Find(c => c.CourseID == enrolledCourses[1].CourseID);

                // Extract enrolled date from the the enrolledCourses list
                DateTime courseOneDate = enrolledCourses[0].EnrollmentDate.AddDays(currentEnrolledCouse1!.CourseDuration);
                DateTime courseTwoDate = enrolledCourses[1].EnrollmentDate.AddDays(currentEnrolledCouse2!.CourseDuration);
                
                string nextAvailableDate = courseOneDate > courseTwoDate ? courseTwoDate.ToString().Split(" ")[0] : courseOneDate.ToString().Split(" ")[0];

                Console.WriteLine($"You have already enrolled in two courses. You can enroll in the next course on {nextAvailableDate}.");

            }
        }
    }
}