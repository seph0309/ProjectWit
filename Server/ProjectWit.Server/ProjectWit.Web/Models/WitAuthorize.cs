using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectWit.Web.Models
{
    public class WitAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            //TODO: ADD unauthorized page here
            //filterContext.Result = new RedirectResult("/Home");
        }
    }
}