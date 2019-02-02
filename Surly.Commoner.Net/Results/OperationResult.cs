using System;
using System.Text;
using Surly.Commoner.Ext;

namespace Surly.Commoner.Results
{
    public class OperationResult : IOperationResult
    {
        public OperationResult(bool success, string msg)
        {
            IsSuccess = success;
            Message = msg;
        }

        public OperationResult()
            :this(true, String.Empty)
        {}

        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        
        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            string successTxt = IsSuccess ? "Succeeded" : "Failed";
            sb.AppendLine($"Result: {successTxt}");
            sb.AppendLine($"Message: {Message}");
            return sb.ToString();
        }

        public static OperationResult Success()
        {
            return new OperationResult(true, String.Empty);
        }

        public static OperationResult Fail(string msg)
        {
            return new OperationResult(false, msg);
        }

        public static OperationResult Fail(Exception ex)
        {
            return Fail(ex.BaseMessage());
        }

    }
}
