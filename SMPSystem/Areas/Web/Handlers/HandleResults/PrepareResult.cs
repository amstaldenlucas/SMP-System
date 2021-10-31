using System.Collections.Generic;

namespace SMPSystem.Areas.Web.Handlers.HandleResults
{
    public class PrepareResult
    {
        public bool HasErrors { get => Errors.Count > 0; }
        public List<KeyAndErrorMessage> Errors { get; set; }
            = new List<KeyAndErrorMessage>();

        public void AddError(string key, string message)
        {
            Errors.Add(new KeyAndErrorMessage
            {
                Key = key,
                Message = message,
            });
        }
    }
}
