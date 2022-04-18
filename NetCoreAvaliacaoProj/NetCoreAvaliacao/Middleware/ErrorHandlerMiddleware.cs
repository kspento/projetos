﻿using Microsoft.AspNetCore.Http;
using NetCoreAvaliacao.Application.Helpers;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetCoreAvaliacao.Api.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception error)
			{
				var response = context.Response;
				response.ContentType = "application/json";

				switch (error)
				{
					case AppException e:
						response.StatusCode = (int)HttpStatusCode.BadRequest;
						break;
					default:
						response.StatusCode = (int)HttpStatusCode.InternalServerError;
						break;
				}

				var result = JsonSerializer.Serialize(new { message = error?.Message });
				await response.WriteAsync(result);
			}
		}
	}
}
