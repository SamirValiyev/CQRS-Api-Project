using MediatR;

namespace CQRS_project.CQRS.Commands.Create
{
    public class CreateStudentCommand:IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
