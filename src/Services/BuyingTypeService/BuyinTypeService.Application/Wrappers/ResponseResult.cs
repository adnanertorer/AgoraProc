namespace BuyingTypeService.Application.Wrappers;

public class ResponseResult<T>
{
    public bool Succeeded { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public List<string>? Errors { get; set; }

    public static ResponseResult<T> Success(T data, string? message = null)
        => new() { Succeeded = true, Data = data, Message = message };

    public static ResponseResult<T> Fail(string message, List<string>? errors = null)
        => new() { Succeeded = false, Message = message, Errors = errors };
}
