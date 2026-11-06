var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext context) =>
{
    //context.Request.Headers["Content-type"] = "text/html";
    if (context.Request.Method == "GET" && context.Request.Path == "/")
    {
        int firstNumber = 0, LastNumber = 0;
        string? operation = null;
        long? result = null;

        if (context.Request.Query.ContainsKey("firstNumber") && context.Request.Query.ContainsKey("LastNumber") && context.Request.Query.ContainsKey("Operation"))
        {
            string firstnumstring = context.Request.Query["firstNumber"][0];
            string secondnumstring = context.Request.Query["LastNumber"][0];
            string operationstring = context.Request.Query["Operation"][0];
            if (!string.IsNullOrEmpty(firstnumstring) && (!string.IsNullOrEmpty(secondnumstring)) && (!string.IsNullOrEmpty(operationstring)))
            {
                 firstNumber = Convert.ToInt32(firstnumstring);
                 LastNumber = Convert.ToInt32(secondnumstring);
                 operation = Convert.ToString(operationstring);

                switch (operation)
                {
                    case "add": result = firstNumber + LastNumber; break;
                    case "subtract": result = firstNumber - LastNumber; break;
                    case "multiply": result = firstNumber * LastNumber; break;
                    case "divide": result = (LastNumber != 0) ? firstNumber / LastNumber : 0; break; //avoid DivideByZeroException, if secondNuber is 0 (zero)
                    case "mod": result = (LastNumber != 0) ? firstNumber % LastNumber : 0; break; //avoid DivideByZeroException, if secondNuber is 0 (zero)
                }

                if (result.HasValue)
                {
                    await context.Response.WriteAsync(result.Value.ToString());
                }
            }
            else
            {
                await context.Response.WriteAsync("Invalid input values provided'\n");
            }

              
        }
        else
        {
            await context.Response.WriteAsync("Invalid querystring'\n");
        }
    }
});
app.Run();
