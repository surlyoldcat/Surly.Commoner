using System;

namespace Surly.Commoner.Results
{
    public interface IOperationResult
    {
        bool IsSuccess { get; }
        string Message { get; }
        string PrettyPrint();
    }
}
