namespace TheGame.Core.Shared.Validation;

public class ValidationResult
{
    private readonly HashSet<ValidationError> _errors = new();

    public IEnumerable<ValidationError> Errors => _errors;

    public bool IsFailed => _errors.Any();

    public void AddError(string message, string propertyName, object? additionalInfo = null)
    {
        _errors.Add(new ValidationError(message, propertyName, additionalInfo));
    }

    public static ValidationResult Create()
    {
        return new ValidationResult();
    }
}