using CQRS_project.CQRS.Responces;
using MediatR;

namespace CQRS_project.CQRS.Queries
{
    public class GetByIdStudentQuery:IRequest<GetByIdStudentQueryResponse>
    {
        public int Id { get; set; }

        public GetByIdStudentQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
