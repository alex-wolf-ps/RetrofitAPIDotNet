using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace IdeaAPI.Controllers
{
    [Route("messages")]
    public class MessagesController : Controller
    {
        public IActionResult Get()
        {
            var message = "Thanks for visiting the app! Our next hackathon is scheduled for the end of Q3. We hope to see you there, be sure to add your ideas to the app.";
            return Json(message);
        }
    }
}