using CQRS_project.CQRS.Commands.Create;
using CQRS_project.CQRS.Handlers;
using CQRS_project.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly GetByIdQueryHandler _getByIdQueryHandler;
        private readonly GetAllQueryHandler _getAllResponseQueryHandler;
        private readonly CreateStudentCommandHandler _createStudentCommandHandler;

        public StudentsController(GetByIdQueryHandler getByIdQueryHandler, GetAllQueryHandler getAllResponseQueryHandler, CreateStudentCommandHandler createStudentCommandHandler)
        {
            _getByIdQueryHandler = getByIdQueryHandler;
            _getAllResponseQueryHandler = getAllResponseQueryHandler;
            _createStudentCommandHandler = createStudentCommandHandler;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _getByIdQueryHandler.Handle(new GetByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _getAllResponseQueryHandler.Handle(new GetAllQuery());
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Add(CreateStudentCommand command)
        {
            _createStudentCommandHandler.Handle(command);
            return Ok();
        }
    }
}
