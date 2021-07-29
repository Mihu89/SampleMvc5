using SampleMvc5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleMvc5.CustomAttributes
{
    public class Min18YearsForAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId < 4)
            {
                return ValidationResult.Success;
            }
            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required!");
            }
            var age = DateTime.Today.Year - customer.BirthDate.Year;

            return (age > 17) ? ValidationResult.Success : new ValidationResult("Customer should have at least 18 years");
        }
    }
}