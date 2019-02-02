using System;
using Surly.Commoner.Ext;

namespace Surly.Commoner.Results
{
    public class OperationResult<T> : OperationResult
    {
        public T Data { get; set; }

        public OperationResult(bool success, string msg, T data) : base(success, msg)
        {
            Data = data;
        }

        public static OperationResult<T> Success(T data)
        {
            return new OperationResult<T>(true, String.Empty, data);
        }

        public static OperationResult<T> Fail(string msg, T data = default(T))
        {
            return new OperationResult<T>(false, msg, data);
        }

        public static OperationResult<T> Fail(Exception ex, T data = default(T))
        {
            return new OperationResult<T>(false, ex.BaseMessage(), data);
        }
    }
}
