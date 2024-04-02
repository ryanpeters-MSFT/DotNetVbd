namespace EndpointFilters
{
    public class EvenNumberFilter : IEndpointFilter
    {
        private readonly ILogger<EvenNumberFilter> logger;

        public EvenNumberFilter(ILogger<EvenNumberFilter> logger) => this.logger = logger;

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var x = context.GetArgument<int>(0);
            var y = context.GetArgument<int>(1);

            if (x % 2 == 1 || y % 2 == 1)
            {
                logger.LogWarning("Seems some odd numbers were used!");

                return Results.BadRequest("Oh, also, both numbers need to be even...");
            }

            return await next(context);
        }
    }
}
