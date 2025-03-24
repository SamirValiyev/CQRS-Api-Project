using CQRS_project.Context;
using CQRS_project.CQRS.Commands.Create;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRS_project.CQRS.Handlers
{
    public class CreateStudentCommandHandler:IRequestHandler<CreateStudentCommand>
    {
        private readonly AppDbContext _appDbContext;
        public CreateStudentCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region Old Handle
        //public void Handle(CreateStudentCommand command)
        //{
        //    _appDbContext.Students.Add(new Data.Entities.Student { Age=command.Age,Name=command.Name,Surname=command.Surname});
        //    _appDbContext.SaveChanges();

        //}
        #endregion

        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            _appDbContext.Students.Add(new Data.Entities.Student { Age = request.Age, Name = request.Name, Surname = request.Surname });
            await _appDbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
