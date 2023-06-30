using Hostel.Extensibility.Extensions;

namespace Hostel.Domain.Models.Response;

public record OperationResponse
{
    public IReadOnlyCollection<ValidationResult> ValidationResults { get; }

    public bool IsValid => ValidationResults.All(x => x.Level is not MessageLevel.Error);

    public OperationResponse()
    {
        ValidationResults = new List<ValidationResult>();
    }

    public OperationResponse(MessageLevel level, string message)
    {
        ValidationResults = new ValidationResult(level, message).AsList();
    }

    public OperationResponse(IReadOnlyCollection<ValidationResult> validationResults)
    {
        ValidationResults = validationResults;
    }
}

public record OperationResponse<TValue> : OperationResponse
{
    public TValue Result { get; }

    public OperationResponse(TValue result)
        : base()
    {
        Result = result;
    }

    public OperationResponse(MessageLevel level, string message)
        : base(level, message)
    {
    }

    public OperationResponse(TValue result, IReadOnlyCollection<ValidationResult> validationResults)
        : base(validationResults)
    {
        Result = result;
    }
}