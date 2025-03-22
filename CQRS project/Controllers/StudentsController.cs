using CQRS_project.Queries.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace CQRS_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly GetByIdQueryHandler _getByIdQueryHandler;
        public StudentsController(GetByIdQueryHandler getByIdQueryHandler)
        {
            _getByIdQueryHandler = getByIdQueryHandler;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _getByIdQueryHandler.Handle(new GetByIdQuery(id));
            return Ok(result);
        }
    }
}
