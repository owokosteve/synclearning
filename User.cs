namespace synclearning;

public enum Gender
{
    Male,
    Female,
    Trans
}

public class User
{
    private static int IDCounter = 1001;
    public string RegistrationID { get; }
    public string? Username { get; }
    public int Age { get; }
    public Gender Gender { get;}
    public string? Qualification { get; }
    public string? MobileNumber { get; }
    public string? MailID { get; }

    public User(string username, int age, Gender gender, string qualification, string mobilenumber, string mailid)
    {
        RegistrationID = $"SYNC{IDCounter}";
        IDCounter++;
        Username = username;
        Age = age;
        Gender = gender;
        Qualification = qualification;
        MobileNumber = mobilenumber;
        MailID = mailid;
    }
}