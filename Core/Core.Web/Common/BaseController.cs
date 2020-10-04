namespace Core.Web.Common
{
    using System.Threading.Tasks;
    using global::Common.Application;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    public class BaseController : Controller
    {
        public const string PathSeparator = "/";
        public const string Id = "{id}";

        private IMediator? mediator;

        protected IMediator Mediator
            => this.mediator ??= this.HttpContext
                .RequestServices
                .GetService<IMediator>();

        protected Task<ActionResult<TResult>> Send<TResult>(IRequest<TResult> request)
            => this.Mediator.Send(request).ToActionResult();

        protected Task<ActionResult> Send(IRequest<Result> request)
            => this.Mediator.Send(request).ToActionResult();

        protected Task<ActionResult<TResult>> Send<TResult>(IRequest<Result<TResult>> request)
            => this.Mediator.Send(request).ToActionResult();
    }
}
