namespace CQRS_project.CQRS.Commands.Create
{
    public class CreateStudentCommand
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
