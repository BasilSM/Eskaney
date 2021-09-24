using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Eskaney.Models
{
    public class MultiSubmit : ActionNameSelectorAttribute
    {
        public string Submit { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            var Check = controllerContext.Controller.ValueProvider.GetValue(Submit);
           
            if (Check != null)
                return true;
            else
                return false;
        }
    }
}