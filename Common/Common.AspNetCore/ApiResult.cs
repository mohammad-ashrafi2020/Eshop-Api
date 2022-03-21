namespace Common.AspNetCore;

public class ApiResult
{
    public bool IsSuccess { get; set; }
    public MetaData MetaData { get; set; }= new();
}
public class ApiResult<TData>
{
    public bool IsSuccess { get; set; }
    public TData Data { get; set; }
    public MetaData MetaData { get; set; } = new();
}

public class MetaData
{
    public string? Message { get; set; }
    public AppStatusCode AppStatusCode { get; set; }
}

public enum AppStatusCode
{
    Success=1,
    LogicError=2,
    NotFound=3,
    UnAuthorize=4,
    BadRequest = 5,
}