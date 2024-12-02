﻿using MediatR;
using OsonCommerce.Application.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsonCommerce.Application.Common.Behavior
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest 
        : IRequest<TResponse>
    {
        ICurrentUserService _currentUserService;
        public LoggingBehavior(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
        public async Task<TResponse> Handle(TRequest request, 
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId;

            Log.Information("Notes Request: {Name} {@UserId} {@Request}",
                requestName, userId, request);

            var response = await next();

            return response;
        }
    }
}
