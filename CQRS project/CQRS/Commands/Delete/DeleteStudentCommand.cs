using MediatR;

namespace CQRS_project.CQRS.Commands.Delete
{
    public class DeleteStudentCommand:IRequest
    {
        public int Id { get; set; }
        public DeleteStudentCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
