using CQRS_project.Context;
using CQRS_project.CQRS.Queries;
using CQRS_project.CQRS.Responces;
using Microsoft.EntityFrameworkCore;

namespace CQRS_project.CQRS.Handlers
{
    public class GetAllQueryHandler
    {
        private readonly AppDbContext _appDbContext;

        public GetAllQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<GetAllQueryResponse> Handle(GetAllQuery query)
        {
            var students = _appDbContext.Students.Select(x => new GetAllQueryResponse { Name = x.Name, Surname = x.Surname }).AsNoTracking().AsEnumerable();
            return students;

        }

    }
}
