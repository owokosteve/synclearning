namespace synclearning;

public class Enrollment
{
    private static int EnrollmentCounter = 3001;
    public string? EnrolLmentID { get; }
    public string? CourseID { get; }
    public string? RegistrationID { get; }
    public DateTime EnrollmentDate { get; }

    public Enrollment(string courseId, string regId, DateTime enrollment)
    {
        EnrolLmentID = $"EMT{EnrollmentCounter}";
        CourseID = courseId;
        RegistrationID = regId;
        EnrollmentDate = enrollment;
        EnrollmentCounter++;
    }
}