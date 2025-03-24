using CQRS_project.CQRS.Commands.Create;
using CQRS_project.CQRS.Commands.Delete;
using CQRS_project.CQRS.Commands.Update;
using CQRS_project.CQRS.Handlers;
using CQRS_project.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #region CQRS

        //private readonly GetByIdQueryHandler _getByIdQueryHandler;
        //private readonly GetAllQueryHandler _getAllResponseQueryHandler;
        //private readonly CreateStudentCommandHandler _createStudentCommandHandler;
        //private readonly DeleteStudentCommandHandler _deleteStudentCommandHandler;
        //private readonly UpdateStudentCommandHandler _updateStudentCommandHandler;

        //public StudentsController(GetByIdQueryHandler getByIdQueryHandler, GetAllQueryHandler getAllResponseQueryHandler, CreateStudentCommandHandler createStudentCommandHandler, DeleteStudentCommandHandler deleteStudentCommandHandler, UpdateStudentCommandHandler updateStudentCommandHandler)
        //{
        //    _getByIdQueryHandler = getByIdQueryHandler;
        //    _getAllResponseQueryHandler = getAllResponseQueryHandler;
        //    _createStudentCommandHandler = createStudentCommandHandler;
        //    _deleteStudentCommandHandler = deleteStudentCommandHandler;
        //    _updateStudentCommandHandler = updateStudentCommandHandler;
        //}
        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var result = _getByIdQueryHandler.Handle(new GetByIdQuery(id));
        //    return Ok(result);
        //}

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var result = _getAllResponseQueryHandler.Handle(new GetAllQuery());
        //    return Ok(result);
        //}
        //[HttpPost]
        //public IActionResult Add(CreateStudentCommand command)
        //{
        //    _createStudentCommandHandler.Handle(command);
        //    return Created("",command.Name);
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _deleteStudentCommandHandler.Handle(new DeleteStudentCommand(id));
        //    return NoContent();
        //}

        //[HttpPut]
        //public IActionResult Update(UpdateStudentCommand command)
        //{
        //    _updateStudentCommandHandler.Handle(command);
        //    return NoContent();
        //}
        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetByIdStudentQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentCommand command)
        {
            var updateStudent = await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteStudent = await _mediator.Send(new DeleteStudentCommand(id));
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateStudentCommand command)
        {
            var createStudent = await _mediator.Send(command);
            return Created("", command.Name);

        }
    }
}
