using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class ModelStateExtension
    {
        public static IEnumerable<Error> GetErrors(this ModelStateDictionary modelState)
        {
            var result = new List<Error>();
            var erroneousFields = modelState.Where(ms => ms.Value.Errors.Any())
                                            .Select(x => new { x.Key, x.Value.Errors });

            foreach (var erroneousField in erroneousFields)
            {
                var fieldKey = erroneousField.Key;
                var fieldErrors = erroneousField.Errors
                                   .Select(error => new Error(fieldKey, error.ErrorMessage));
                result.AddRange(fieldErrors);
            }

            return result;
        }

        /// <summary>
        /// Get model data validation error information
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static string GetErrorMessage(this ModelStateDictionary modelState)
        {
            string resultMessage = string.Empty;
            var result = new List<Error>();
            var erroneousFields = modelState.Where(ms => ms.Value.Errors.Any())
                                            .Select(x => new { x.Key, x.Value.Errors });

            foreach (var erroneousField in erroneousFields)
            {
                var fieldKey = erroneousField.Key;
                var fieldErrors = erroneousField.Errors
                                   .Select(error => new Error(fieldKey, error.ErrorMessage));
                result.AddRange(fieldErrors);
            }
            if (result.Any())
            {
                resultMessage = string.Join("; ", result.Select(x => x.Message).ToArray());
            }
            return resultMessage;
        }
    }
}
