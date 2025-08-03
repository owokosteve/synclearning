namespace synclearning;

public enum Gender
{
    Male,
    Female,
    Trans
}

public class User
{
    private static int IDCounter { get; set; } = 100;
    public string? RegistrationID { get; private set; }
    public string? Username { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public string? Qualification { get; set; }
    public string? MobileNumber { get; set; }
    public string? MailID { get; set; }
    public List<User> users { get;set; }

    public void SetID()
    {
        IDCounter++;
        RegistrationID = "SYNC" + IDCounter;
    }

    public string GetID() { return RegistrationID!; }

    public User(string regID, string username, int age, Gender gender, string qualification, string mobilenumber, string mailid)
    {
        this.RegistrationID = regID;
        this.Username = username;
        this.Age = age;
        this.Gender = gender;
        this.Qualification = qualification;
        this.MobileNumber = mobilenumber;
        this.MailID = mailid;
        this.users = new List<User>();
    }

    public void Register()
    {
        Console.WriteLine("\n---Registration---");
        Console.Write("Enter username: ");
        string username = Console.ReadLine()!.Trim();
        Console.Write("Enter age: ");
        int age = int.Parse(Console.ReadLine()!.Trim());
        Console.Write("Enter gender: (Male, Female or Trans: )");
        Gender gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine()!.Trim(), true);
        Console.Write("Enter qualification: i.e. MA/BA etc.: ");
        string qualification = Console.ReadLine()!.Trim();
        Console.Write("Enter mobile number: ");
        string mobileNumber = Console.ReadLine()!.Trim();
        Console.Write("Enter mail id: ");
        string mailid = Console.ReadLine()!.Trim();

        User user = new User(GetID(), username, age, gender, qualification, mobileNumber, mailid);
        users.Add(user);
        Console.WriteLine($"Success {user.Username}! Your UserID is {user.GetID()}");
    }
}