
using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace mickion.tuckshops.shared.api.DependencyInjections
{
    public static class ConfigureApiVersioning
    {
        public static IServiceCollection AddApplicationVersioning(this IServiceCollection services, int defaultApiVersion = 1)
        {
            services.AddApiVersioning(option =>
            {
                //This ensures if client doesn't specify an API version. The default version should be considered. 
                option.AssumeDefaultVersionWhenUnspecified = true; 
                option.DefaultApiVersion = new ApiVersion(defaultApiVersion, 0); //This we set the default API version
                //The allow the API Version information to be reported in the client  in the response header. This will be useful for the client to understand the version of the API they are interacting with.
                option.ReportApiVersions = true;

                //This says how the API version should be read from the client's request, 3 options are enabled 1.Querystring, 2.Header, 3.MediaType. 
                //"api-version", "X-Version" and "ver" are parameter name to be set with version number in client before request the endpoints.
                //option.ApiVersionReader = ApiVersionReader.Combine(
                //    new QueryStringApiVersionReader("api-version"),
                //    new HeaderApiVersionReader("X-Version"),
                //    new MediaTypeApiVersionReader("ver")); 
                option.ApiVersionReader = new UrlSegmentApiVersionReader();

            }).AddApiExplorer(options => {
                options.GroupNameFormat = "'v'VVV"; //The say our format of our version number “‘v’major[.minor][-status]”
                options.SubstituteApiVersionInUrl = true; //This will help us to resolve the ambiguity when there is a routing conflict due to routing template one or more end points are same.
            });

            return services;
        }
    }
}
