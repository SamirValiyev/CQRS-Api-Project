using CQRS_project.CQRS.Responces;
using MediatR;

namespace CQRS_project.CQRS.Queries
{
    public class GetByIdQuery:IRequest<GetByIdQueryResponse>
    {
        public int Id { get; set; }

        public GetByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
