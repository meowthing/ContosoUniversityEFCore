namespace ContosoUniversityEFCore.Models
{
    //This is a view model class designed to restrict the permitted properties that can be submitted from the web page form.
    public class StudentVM
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
