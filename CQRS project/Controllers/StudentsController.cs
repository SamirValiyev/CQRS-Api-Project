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
        public async Task<IActionResult> GetByIdStudent(int id)
        {
            var result = await _mediator.Send(new GetByIdQuery(id));
            return Ok(result);
        }


    }
}
