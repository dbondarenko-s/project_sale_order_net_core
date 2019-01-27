using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Ciam.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static ModelStateDictionary ResetRequiredFieldForModel<T>(this ModelStateDictionary modelState, string nameModel)
        {
            var fieilds = typeof(T).GetProperties().Select(prop => prop.Name).ToList();
            fieilds.ForEach(x => modelState[String.Format("{0}.{1}", nameModel, x)]?.Errors.Clear());
            return modelState;
        }

        public static IEnumerable Errors(this ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                return modelState.ToDictionary(kvp => kvp.Key, 
                                               kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray())
                                               .Where(m => m.Value.Any());
            }
            return null;
        }
    }
}