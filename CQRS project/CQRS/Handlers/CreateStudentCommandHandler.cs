using CQRS_project.Context;
using CQRS_project.CQRS.Commands.Create;

namespace CQRS_project.CQRS.Handlers
{
    public class CreateStudentCommandHandler
    {
        private readonly AppDbContext _appDbContext;
        public CreateStudentCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Handle(CreateStudentCommand command)
        {
            _appDbContext.Students.Add(new Data.Entities.Student { Age=command.Age,Name=command.Name,Surname=command.Surname});
            _appDbContext.SaveChanges();

        }
    }
}
