namespace Interview_Test.Middlewares;

public class AuthenMiddleware : IMiddleware
{
    // text is satidsompradit
    private const string hashedKey = "b27309f46e30aee89c5cc0e22d1aa047a206c365385962a22f59c33d9b8632d57bf13c848cd140de5778cfe81d7bd1aa80f45a8fa09970538112bad273d67a98";
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var apiKeyHeader = context.Request.Headers["x-api-key"];
        if (string.IsNullOrEmpty(apiKeyHeader))
        {
            context.Response.StatusCode = 401;
            return context.Response.WriteAsync("API Key is missing");
        }

        using (var sha512 = System.Security.Cryptography.SHA512.Create())
        {
            var hashedApiKey = Convert.ToHexString(sha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(apiKeyHeader))).ToLower();
            if (hashedApiKey != hashedKey)
            {
                context.Response.StatusCode = 401;
                return context.Response.WriteAsync("Unauthorized: Invalid API Key");
            }
        }

        return next(context);
    }
}