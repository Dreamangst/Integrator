using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Helpers.ConditionalValidation.Validation
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        private readonly string _objetivePropertyName;
        private readonly Object _objectToCompare;
        private readonly string _errorMessage;

        public RequiredIfAttribute(string objetivePropertyName, Object objectToCompare, string errorMessage)
        {
            /*
            [Required]
                public PromoEnum promoType { get; set; }
            [RequiredIf("promoType", PromoEnum.PromoNx1, "Si la promocion es orientda a 2x1 o similar, se debe especificar la cantidad.")]
                public int qtty { get; set; }
             */
            /*
            [Required]
                public <Enum> <targetProperty> { get; set; }
            [RequiredIf("<targetProperty>", <concreteEnum>, "Si la promocion es orientda a 2x1 o similar, se debe especificar la cantidad.")]
                public int qtty { get; set; }
             * 
             * si objetivePropertyName  es objectToCompare soy necesario.
             */
            _objetivePropertyName = objetivePropertyName;
            _objectToCompare = objectToCompare;
            _errorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (_objetivePropertyName == null || _objectToCompare == null) //verifica la validez de lo recibido por la anotacion
            {
                return new ValidationResult(string.Format("Unknown property: {0}", _objetivePropertyName));
            }
            else
            {
                var property = validationContext.ObjectType.GetProperty(_objetivePropertyName);  //adquiero la propiedad, como objeto, a la cual se hace referencia


                if (!object.Equals(property, _objectToCompare))
                {
                    // here we are verifying whether the 2 values are equal
                    // but you could do any custom validation you like
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }

                return null;//
              }  
                
                
                /*
                var otherValue = property.GetValue(validationContext.ObjectInstance, null);

                // at this stage you have "value" and "otherValue" pointing
                // to the value of the property on which this attribute
                // is applied and the value of the other property respectively
                // => you could do some checks
                if (!object.Equals(value, otherValue))
                {
                    // here we are verifying whether the 2 values are equal
                    // but you could do any custom validation you like
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }
                return null;*/




            


            
        }
    }
}
