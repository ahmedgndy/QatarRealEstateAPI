namespace BuildingBlocks.Common.Results.Abstractions;

public interface IResult<out TValue> : IResult
{
    TValue Value { get; }
}