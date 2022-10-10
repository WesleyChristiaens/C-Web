using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Xml.Linq;

namespace Oef07_MVC_Custom_Model_Validation.CustomModelValidation
{
    public class CustomNoNumbers : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            
            var lst = new List<ModelValidationResult>();

            if (string.IsNullOrEmpty(context.Model.ToString())) /*context.Model != null*/
            {
                foreach (var x in context.Model.ToString())
                {                  

                    if (char.IsNumber(x))
                    {
                        lst.Add(new ModelValidationResult("", "Cijfers in naam zijn niet toegestaan!"));
                        break;
                    }
                }
                
            }
            else
            {
                lst.Add(new ModelValidationResult("", "Geef een naam in."));
            }
                 
            return lst;
        }
    }
}
