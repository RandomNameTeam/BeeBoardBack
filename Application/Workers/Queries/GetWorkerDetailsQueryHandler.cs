﻿using Application.Common.Expetions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Workers.Queries
{
    internal class GetWorkerDetailsQueryHandler : IRequestHandler<GetWorkerDetailsQuery, WorkerDetailsVm>
    {
        private readonly IUserDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetWorkerDetailsQueryHandler(IUserDbContext dbContext,
                                            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WorkerDetailsVm> Handle(GetWorkerDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.Find(request.UserId);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            var worker = _dbContext.Workers.Where(worker => worker.User == user).First();
            if (worker == null)
            {
                throw new NotFoundException(nameof(Worker), request.UserId);
            }

            return _mapper.Map<WorkerDetailsVm>(worker);
        }
    }
}
