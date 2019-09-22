using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestLocalization.Pages
{
    public class LanguageModel : PageModel
    {
        public RedirectResult OnGet(string culture, string returnUrl)
        {
            HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture == "en" ? "ar" : "en")),
                // making cookie valid for the actual app root path (which is not necessarily "/" e.g. if we're behind a reverse proxy)
                new CookieOptions { Path = Url.Content("~/") });

            return Redirect(returnUrl);
        }
    }
}