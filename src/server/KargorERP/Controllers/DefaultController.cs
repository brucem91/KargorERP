using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using KargorERP.ViewModels;

namespace KargorERP.Controllers
{
    public class DefaultController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ErrorViewModel Error()
        {
            return new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
        }
    }
}