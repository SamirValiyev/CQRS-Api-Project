﻿using CQRS_project.CQRS.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly GetByIdQueryHandler _getByIdQueryHandler;
        private readonly GetAllQueryHandler _getAllResponseQueryHandler;

        public StudentsController(GetByIdQueryHandler getByIdQueryHandler, GetAllQueryHandler getAllResponseQueryHandler)
        {
            _getByIdQueryHandler = getByIdQueryHandler;
            _getAllResponseQueryHandler = getAllResponseQueryHandler;
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
    }
}
