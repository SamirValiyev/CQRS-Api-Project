using CQRS_project.Context;
using CQRS_project.CQRS.Commands.Delete;

namespace CQRS_project.CQRS.Handlers
{
    public class DeleteStudentCommandHandler
    {
        private readonly AppDbContext _appDbContext;
        public DeleteStudentCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Handle(DeleteStudentCommand command)
        {
            var deletedStudent = _appDbContext.Students.Find(command.Id);
            _appDbContext.Students.Remove(deletedStudent);
            _appDbContext.SaveChanges();
        }
    }
}
