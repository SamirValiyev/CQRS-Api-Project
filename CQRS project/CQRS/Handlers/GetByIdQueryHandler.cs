﻿using CQRS_project.Context;
using CQRS_project.CQRS.Queries;
using CQRS_project.CQRS.Responces;
using CQRS_project.Data.Entities;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CQRS_project.CQRS.Handlers
{
    public class GetByIdQueryHandler:IRequestHandler<GetByIdQuery,GetByIdQueryResponse>
    {
        private readonly AppDbContext _appDbContext;
        public GetByIdQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<GetByIdQueryResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var student =await _appDbContext.Set<Student>().FindAsync(request.Id);
            return new GetByIdQueryResponse
            {
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age
            };
        }
        #region CQRShandle

        //public GetByIdQueryResponse Handle(GetByIdQuery query)
        //{
        //    var student = _appDbContext.Set<Student>().Find(query.Id);
        //    return new GetByIdQueryResponse
        //    {
        //        Name = student.Name,
        //        Surname = student.Surname,
        //        Age = student.Age
        //    };
        //}
        #endregion
    }
}
