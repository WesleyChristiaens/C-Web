using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MVCVoertuig.ModelValidations
{
    public class BouwjaarValidation : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var cstMinValue=1900;
            int bouwjaar=0;

            var lst = new List<ModelValidationResult>();
            if (int.TryParse(context.Model.ToString(), out bouwjaar))
            {
                if (bouwjaar < cstMinValue || bouwjaar > DateTime.Now.Year)
                    lst.Add(new ModelValidationResult("", $"Bouwjaar moet liggen tussen {cstMinValue} en {DateTime.Now.Year}"));
            }
            else
            {
                lst.Add(new ModelValidationResult("", "Geen geldig bouwjaar!"));
            }
            return lst;
        }
    }
}