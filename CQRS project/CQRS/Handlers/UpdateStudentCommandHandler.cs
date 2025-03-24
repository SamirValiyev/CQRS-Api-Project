using CQRS_project.Context;
using CQRS_project.CQRS.Commands.Update;
using System.Linq;

namespace CQRS_project.CQRS.Handlers
{
    public class UpdateStudentCommandHandler
    {
        private readonly AppDbContext _appDbContext;
        public UpdateStudentCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Handle(UpdateStudentCommand command)
        {
            var updatedStudent = _appDbContext.Students.Find(command.Id);
            updatedStudent.Name = command.Name;
            updatedStudent.Surname = command.Surname;
            updatedStudent.Age = command.Age;
            _appDbContext.SaveChanges();
        }
    }
}
