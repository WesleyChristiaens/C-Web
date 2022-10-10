using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Oef07_MVC_Custom_Model_Validation.CustomModelValidation
{
    public class CustomPostCode : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var lst = new List<ModelValidationResult>();
            string[] allowed = { "3500", "3600", "3990" };

            if (context.Model != null)
            {
                if (!allowed.Contains(context.Model.ToString()))
                {
                    lst.Add(new ModelValidationResult("", "Enkel postcodes 3500, 3600, 3990 zijn toegestaan."));
                }
            }
            else
            {
                lst.Add(new ModelValidationResult("", "Geef een postcode in."));
            }


            return lst;
        }
    }
}
