using System.Collections.Generic;
using System.Linq;
using Cryptocop.Software.API.Exceptions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cryptocop.Software.API.Helpers
{
    public static class ErrorHandler
    {
        public static void GetModelErrors(ModelStateDictionary model)
        {
            throw new ModelFormatException(string.Join("\n", (
                from modelState in model.Values
                from error in modelState.Errors 
                select error.ErrorMessage).ToArray()));
        }
    }
}