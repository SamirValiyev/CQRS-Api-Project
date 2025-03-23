namespace CQRS_project.CQRS.Commands.Delete
{
    public class DeleteStudentCommand
    {
        public int Id { get; set; }
        public DeleteStudentCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
