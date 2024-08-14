using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LaManada_API_KeirynSandi.Attributes
{
    public class ApiKeyAttribute
    {
        private readonly string _apiKey = "ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Request.Headers.TryGetValue(_apiKey, out var ApiSalida))
            {

                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "LLAMADA AL API NO CONTIENE INFORMACIÓN DE SEGURIDAD"
                };
                return;
            }

            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var ApiKeyValue = appSettings.GetValue<string>(_apiKey);

            if (ApiKeyValue != null && !ApiKeyValue.Equals(ApiSalida))
            {

                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "EL VALOR DE LLAVE DE SEGURIDAD ES INCORRECTO"
                };
                return;
            }



        }

    }
}
    
