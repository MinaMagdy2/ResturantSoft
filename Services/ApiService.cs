using Refit;
using System.Text.Json;

public class ApiService
{
    public async Task<ApiResponse<T>> SafeCall<T>(Func<Task<T>> action)
    {
        try
        {
            var result = await action();
            return new ApiResponse<T>(result, null);
        }
        catch (ApiException ex)
        {
            var error = await ParseApiError(ex);
            return new ApiResponse<T>(default, error);
        }
        catch (Exception ex)
        {
            return new ApiResponse<T>(default, new ApiError
            {
                Message = "Unexpected error occurred",
                Errors = new() { { "General", new[] { ex.Message } } }
            });
        }
    }

    private async Task<ApiError> ParseApiError(ApiException ex)
    {
        try
        {
            var content = await ex.GetContentAsAsync<ApiError>();
            return content ?? new ApiError
            {
                Message = $"Server returned error ({ex.StatusCode})"
            };
        }
        catch
        {
            return new ApiError
            {
                Message = $"Server returned invalid response ({ex.StatusCode})"
            };
        }
    }
}

public class ApiResponse<T>
{
    public T? Data { get; }
    public ApiError? Error { get; }

    public bool HasError => Error != null;

    public ApiResponse(T? data, ApiError? error)
    {
        Data = data;
        Error = error;
    }
}

public class ApiError
{
    public string? Message { get; set; }
    public Dictionary<string, string[]>? Errors { get; set; }
}
