using BuildingBlocks.Common.Results.Errors;

namespace BuildingBlocks.Common.Results;

public interface IResult
{
    bool IsSuccess { get; }
    List<Error>? Errors { get; }
}
