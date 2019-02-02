using System;

namespace Surly.Commoner.Ext
{
    public static class ExceptionExtensions
    {
        public static string BaseMessage(this Exception ex)
        {
            var baseEx = ex.GetBaseException();
            return baseEx.Message;
        }
    }
}
