using MediatR;
using Microsoft.AspNetCore.Mvc;
using YourProjectName.Application.APIResponse;

namespace YourProjectName.API
{
    public class BaseAPIController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public BaseAPIController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
