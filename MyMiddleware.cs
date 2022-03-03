using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace firstWebApp
{
    public class MyMiddleware
    {

        private readonly RequestDelegate _next;
        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            
            Console.Write("\n----------------- Aperte qualquer tecla para prosseguir:  ---------------\n");
            string aperteTecla = Console.ReadLine();

            await _next(context);

            Console.WriteLine("\n---------------------------- Processo Finalizado! --------------------------\n");
        }
    }

    public static class MyMiddlewareExtensions 
    {
        // Extension method
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }
}
