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
            var message = "This message was retrieved from the server.";
            return Json(message);
        }
    }
}