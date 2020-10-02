using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Errors
{
    public class ValidationResultModel
    {
        public List<string> Error { get; }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            var internalErrors = modelState.Keys.SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage))).ToList();

            Error = internalErrors.Select(x => x.Message).ToList();
        }
    }
}