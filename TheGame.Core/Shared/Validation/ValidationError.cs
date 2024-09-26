namespace TheGame.Core.Shared.Validation;

public class ValidationError(string errorMessage, string? field = null, object? details = null)
{
    public string ErrorMessage { get; } = errorMessage;
    public string? Hint { get; } = field;
    public object? Details { get; } = details;

    public override string ToString()
    {
        return $"{Hint}: {ErrorMessage} Details: {Details}";
    }
}