using CQRS_project.Context;
using CQRS_project.CQRS.Commands.Update;
using MediatR;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRS_project.CQRS.Handlers
{
    public class UpdateStudentCommandHandler:IRequestHandler<UpdateStudentCommand>
    {
        private readonly AppDbContext _appDbContext;
        public UpdateStudentCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region Old Handle
        //public void Handle(UpdateStudentCommand command)
        //{
        //    var updatedStudent = _appDbContext.Students.Find(command.Id);
        //    updatedStudent.Name = command.Name;
        //    updatedStudent.Surname = command.Surname;
        //    updatedStudent.Age = command.Age;
        //    _appDbContext.SaveChanges();
        //}
        #endregion
        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var updatedStudent = await _appDbContext.Students.FindAsync(request.Id);
            updatedStudent.Name = request.Name;
            updatedStudent.Surname = request.Surname;
            updatedStudent.Age = request.Age;
            await _appDbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
