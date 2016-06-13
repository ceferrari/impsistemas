﻿using System;
using System.Globalization;
using System.Web.Mvc;

namespace TrabalhoPO.Shared
{
    public class IntegerModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            ModelState modelState = new ModelState { Value = valueProviderResult };

            object actualValue = null;

            if (!String.IsNullOrWhiteSpace(valueProviderResult.AttemptedValue))
            {
                try
                {
                    actualValue = int.Parse(valueProviderResult.AttemptedValue, NumberStyles.AllowThousands, CultureInfo.CurrentCulture);
                }
                catch (FormatException ex)
                {
                    modelState.Errors.Add(ex);
                }
            }

            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);

            return actualValue;
        }
    }
}