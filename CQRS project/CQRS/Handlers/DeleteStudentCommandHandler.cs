using CQRS_project.Context;
using CQRS_project.CQRS.Commands.Delete;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRS_project.CQRS.Handlers
{
    public class DeleteStudentCommandHandler:IRequestHandler<DeleteStudentCommand>
    {
        private readonly AppDbContext _appDbContext;
        public DeleteStudentCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #region Old Handle
        //public void Handle(DeleteStudentCommand command)
        //{
        //    var deletedStudent = _appDbContext.Students.Find(command.Id);
        //    _appDbContext.Students.Remove(deletedStudent);
        //    _appDbContext.SaveChanges();
        //}
        #endregion

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var deletedStudent = await _appDbContext.Students.FindAsync(request.Id);
            _appDbContext.Students.Remove(deletedStudent);
            await _appDbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
