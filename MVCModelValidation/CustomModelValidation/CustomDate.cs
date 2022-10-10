using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MVCModelValidation.CustomModelValidation
{
    public class CustomDate:Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var dtm = DateTime.Now;
            var lst = new List<ModelValidationResult>();


            if (DateTime.TryParse(context.Model.ToString(),out dtm))
            {
                if (dtm > DateTime.Now)
                    lst.Add(new ModelValidationResult("", "Date of Birth cannot be in the future"));
                else if (dtm < new DateTime(1900, 1, 1))                
                    lst.Add(new ModelValidationResult("", "Date of Birth should not be before 1900"));
            }
            else
            {
                lst.Add(new ModelValidationResult("", "Not a valid date!"));
            }

            return lst;       

        }
}
}
