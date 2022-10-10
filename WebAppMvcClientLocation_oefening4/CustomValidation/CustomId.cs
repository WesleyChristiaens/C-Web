using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebAppMvcClientLocation_oefening4.CustomValidation
{
    public class CustomId : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            if (context.Model != null)
            {

            }
        }
    }
}
