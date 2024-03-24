using Microsoft.AspNetCore.Mvc;

namespace AspMvcWelcomeApp
{
    public class HomeResult : IActionResult
    {
        string layout;

        public HomeResult(string layout)
        {
            this.layout = layout;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            string code = @$"<html>
                                <head><title>Home result</title><meta charset=utf-8/></head>
                                <body>
                                    <h1>Hello world</h1>
                                    <h2>Hello {layout}</h2>
                                </body>
                            </html>";
            return context.HttpContext.Response.WriteAsync(code);
        }
    }
}
