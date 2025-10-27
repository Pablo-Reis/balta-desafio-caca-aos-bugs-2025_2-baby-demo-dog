using BugStore.Endpoints.Customer;

namespace BugStore.Endpoints
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK" });

            endpoints.MapGroup("v1/customers")
                .WithTags("Customers")
                .MapEndpoint<GetCustomersEndpoint>()
                .MapEndpoint<GetCustomerByIdEndpoint>()
                .MapEndpoint<CreateCustomerEndpoint>()
                .MapEndpoint<UpdateCustomerEndpoint>()
                .MapEndpoint<DeleteCustomerEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
    
    }
