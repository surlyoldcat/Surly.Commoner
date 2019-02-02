using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surly.Commoner.Results
{
    public class AggregateOperationResult : IOperationResult
    {
        public bool IsSuccess
        {
            get { return ChildResults.All(r => r.IsSuccess); }
        }

        public string Message
        {
            get
            {
                return this.IsSuccess
                    ? String.Empty
                    : "One or more child results indicate failure.";
            }
        }
        public List<IOperationResult> ChildResults { get; }

        public AggregateOperationResult()
        {
            ChildResults = new List<IOperationResult>();
        }

        public void AddResult(IOperationResult result)
        {
            ChildResults.Add(result);
        }

        public void AddResults(IEnumerable<IOperationResult> results)
        {
            ChildResults.AddRange(results);
        }

        public string PrettyPrint()
        {
            if (IsSuccess)
            {
                return "Overall result: Succeeded";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Overall result: Failure");
                sb.AppendLine("Failed child results:");
                foreach (var fail in ChildResults.Where(r => !r.IsSuccess))
                {
                    sb.AppendLine(fail.PrettyPrint());
                }

                return sb.ToString();
            }
        }
    }
}
