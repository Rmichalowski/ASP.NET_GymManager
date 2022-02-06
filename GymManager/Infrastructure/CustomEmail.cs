using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GymManager.Infrastructure
{
    public class CustomEmail : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {

            if (context.Model == ("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$") )
                return new List<ModelValidationResult> {
                    new ModelValidationResult("", "This E-mail doesn't exist")
                };
            else
                return Enumerable.Empty<ModelValidationResult>();
        }
    }
}