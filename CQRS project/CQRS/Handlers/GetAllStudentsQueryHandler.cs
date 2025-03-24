using CQRS_project.Context;
using CQRS_project.CQRS.Queries;
using CQRS_project.CQRS.Responces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_project.CQRS.Handlers
{
    public class GetAllStudentsQueryHandler:IRequestHandler<GetAllStudentsQuery,IEnumerable<GetAllStudentsQueryResponse>>
    {
        private readonly AppDbContext _appDbContext;

        public GetAllStudentsQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region Old Handle
        //public IEnumerable<GetAllStudentsQueryResponse> Handle(GetAllStudentsQuery query)
        //{
        //    var students = _appDbContext.Students.Select(x => new GetAllStudentsQueryResponse { Name = x.Name, Surname = x.Surname }).AsNoTracking().AsEnumerable();
        //    return students;

        //}
        #endregion

        public async Task<IEnumerable<GetAllStudentsQueryResponse>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students= await _appDbContext.Students.Select(x => new GetAllStudentsQueryResponse { Name = x.Name, Surname = x.Surname }).AsNoTracking().ToListAsync();
            return students;
        }
    }
}
