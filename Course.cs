namespace synclearning;
public class Course
{
    private static int CourseCounter = 2001;
    public string? CourseID { get; }
    public string? CourseName { get; }
    public string? TrainerName { get; }
    public int CourseDuration { get; }
    public int SeatsAvailable { get; }

    public Course(string name, string trainerName, int duration, int seats)
    {
        CourseID = $"CS{CourseCounter}";
        CourseName = name;
        TrainerName = trainerName;
        CourseDuration = duration;
        SeatsAvailable = seats;
        CourseCounter++;
    }

}