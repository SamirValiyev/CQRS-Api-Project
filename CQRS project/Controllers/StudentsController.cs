using CQRS_project.CQRS.Commands.Create;
using CQRS_project.CQRS.Commands.Delete;
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
        private readonly DeleteStudentCommandHandler _deleteStudentCommandHandler;

        public StudentsController(GetByIdQueryHandler getByIdQueryHandler, GetAllQueryHandler getAllResponseQueryHandler, CreateStudentCommandHandler createStudentCommandHandler, DeleteStudentCommandHandler deleteStudentCommandHandler)
        {
            _getByIdQueryHandler = getByIdQueryHandler;
            _getAllResponseQueryHandler = getAllResponseQueryHandler;
            _createStudentCommandHandler = createStudentCommandHandler;
            _deleteStudentCommandHandler = deleteStudentCommandHandler;
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
            return Created("",command.Name);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _deleteStudentCommandHandler.Handle(new DeleteStudentCommand(id));
            return NoContent();
        }
    }
}
