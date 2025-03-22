using CQRS_project.Context;
using CQRS_project.CQRS.Queries;
using CQRS_project.CQRS.Responces;
using CQRS_project.Data.Entities;

namespace CQRS_project.CQRS.Handlers
{
    public class GetByIdQueryHandler
    {
        private readonly AppDbContext _appDbContext;
        public GetByIdQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public GetByIdQueryResponse Handle(GetByIdQuery query)
        {
            var student = _appDbContext.Set<Student>().Find(query.Id);
            return new GetByIdQueryResponse
            {
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age
            };
        }
    }
}
