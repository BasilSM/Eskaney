using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eskaney.CoustomValidation
{
    public class LisDateAttribute : ValidationAttribute
    {
        public LisDateAttribute() : base("{0} Date Shoud Lis Than Courunt Date")
        {

        }

        public override bool IsValid(object value)
        {
            DateTime propValue = Convert.ToDateTime(value);
            if (propValue <= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}