using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pix.Application.ViewModels.BadRequest;
using Pix.Domain.DomainObjects;
using System;
using System.Net;

namespace API.Filters
{
    public class ApiExceptionFilter : Attribute, IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            if (!(context.Exception is Exception))
            {
                return;
            }

            switch (context.Exception)
            {

                case DomainException e:
                    context.Result = new ObjectResult(new BadRequest(e.Message)) { StatusCode = (int)HttpStatusCode.BadRequest };

                    break;

                case NotFoundException _:

                    context.Result = new ObjectResult("") { StatusCode = (int)HttpStatusCode.NotFound };

                    break;


                case Exception e:

                    context.Result = new ObjectResult(new { Message = $"Ocorreu uma instabilidade no sistema, mas já estamos resolvendo. {e.Message}" }) { StatusCode = (int)HttpStatusCode.InternalServerError };

                    break;
            }

            context.Exception = null;
        }
    }
}
