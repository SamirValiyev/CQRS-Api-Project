using CQRS_project.CQRS.Responces;
using MediatR;

namespace CQRS_project.CQRS.Queries
{
    public class GetAllStudentsQuery:IRequest<IEnumerable<GetAllStudentsQueryResponse>>
    {

    }
}
