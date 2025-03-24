using MediatR;

namespace CQRS_project.CQRS.Commands.Update
{
    public class UpdateStudentCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
