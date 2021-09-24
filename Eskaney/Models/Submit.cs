using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Eskaney.Models
{
    public class Submit : ActionNameSelectorAttribute
    {
        public string Name { get; set; }
        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            var x = controllerContext.Controller.ValueProvider.GetValue(Name);
            if (x != null)
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