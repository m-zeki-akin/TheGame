using TheGame.Core.Shared.Validation;

namespace TheGame.Core.Shared;

public class Result<T>
{
    private Result(bool isSuccess, T value, IEnumerable<ValidationError> errors)
    {
        IsSuccess = isSuccess;
        Value = value;
        Errors = errors;
    }

    public bool IsSuccess { get; }
    public T Value { get; }
    public IEnumerable<ValidationError> Errors { get; }

    public static Result<T> Success(T value)
    {
        return new Result<T>(true, value, Array.Empty<ValidationError>());
    }

    public static Result<T> Failure(ValidationResult validationResult)
    {
        return new Result<T>(false, default!, validationResult.Errors);
    }

    public static Result<T> Failure(ValidationError validationError)
    {
        return new Result<T>(false, default!, [validationError]);
    }
}