namespace BuildingBlocks.Common.Results;

//Marker Structs (For HTTP Status Context)
public static class Result
{

    public static Success Success => default;
    public static Created Created => default;
    public static Deleted Deleted => default;
    public static Updated Updated => default;
}
public sealed class Result<TValue> : IResult<TValue>
{
    private readonly TValue? _value = default;
    private readonly List<Error>? _errors = null;

    public bool IsError => !IsSuccess;

    public List<Error> Errors => IsError ? _errors! : [];

    public TValue Value => IsSuccess ? _value! : default!;

    public Error TopError => (_errors?.Count > 0) ? _errors[0] : default;

    // Private constructors - prevent direct instantiation
    private Result(TValue value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }
        _value = value;
        IsSuccess = true;
    }

    private Result(List<Error> errors)
    {
        if (errors is null || errors.Count == 0)
        {
            throw new ArgumentNullException(nameof(errors), "Errors cannot be null or empty.");
        }
        _errors = errors;
        IsSuccess = false;
    }

    private Result(Error error)
    {
        if (error is null)
        {
            throw new ArgumentNullException(nameof(error));
        }
        _errors = new List<Error> { error };
        IsSuccess = false;
    }
    // Public static factory methods - the ONLY way to create instances
    public List<Error> Errors => IsError ? _errors! : [];

    public TValue Value => IsSuccess ? _value! : default!;

    public Error TopError => (_errors?.Count > 0) ? _errors[0] : default;

    //implicit operator to convert TValue to Result<TValue>

    public TNextValue Match<TNextValue>(Func<TValue, TNextValue> onValue, Func<List<Error>, TNextValue> onError)
    => IsSuccess ? onValue(Value!) : onError(Errors);

    public static implicit operator Result<TValue>(TValue value)
        => new(value);

    public static implicit operator Result<TValue>(Error error)
        => new(error);

    public static implicit operator Result<TValue>(List<Error> errors)
        => new(errors);
    [JsonConstructor]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("For serializer only.", true)]
    public Result(TValue? value, List<Error>? errors, bool isSuccess)
    {
        if (isSuccess)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
            _errors = [];
            IsSuccess = true;
        }
        else
        {
            if (errors == null || errors.Count == 0)
            {
                throw new ArgumentException("Provide at least one error.", nameof(errors));
            }

            _errors = errors;
            _value = default!;
            IsSuccess = false;
        }
    }

}
//just a marker for success result
public readonly record struct Success;
public readonly record struct Created;
public readonly record struct Deleted;
public readonly record struct Updated;
