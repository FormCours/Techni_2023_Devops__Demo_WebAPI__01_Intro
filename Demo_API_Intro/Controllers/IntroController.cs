using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Demo_API_Intro.Controllers
{
    // Model pour l'intro (Best pratice: Move in other file)
    public class WelcomeMessage
    {
        public string Message { get; set; }
    }

    // Controller de l'API
    [Route("api/[controller]")]
    [ApiController]
    public class IntroController : ControllerBase
    {
        // Envoi de réponse avec un type "string"
        [HttpGet]
        [Route("Hello")]
        public string Hello()
        {
            return "Hello techni";
        }

        [HttpGet("HelloJSON")]
        public string HelloJSON()
        {
            WelcomeMessage msg = new WelcomeMessage()
            {
                Message = "Hello en JSON 😲"
            };

            return JsonSerializer.Serialize(msg);
        }


        // Envoi de réponse avec un type "WelcomeMessage"
        [HttpGet("HelloType")]
        public WelcomeMessage HelloType()
        {
            WelcomeMessage msg = new WelcomeMessage()
            {
                Message = "Hello type WelcomeMessage"
            };

            return msg; // L'objet est automatique sérialisé
        }

        // Envoi de réponse via "IActionResult"
        [HttpGet("HelloAction")]
        public IActionResult HelloAction()
        {
            WelcomeMessage msg = new WelcomeMessage()
            {
                Message = "Hello IActionResult"
            };

            // Envoi d'un réponse de requete (Status + contenu)
            return Ok(msg);
        }


        // Final Example for intro
        [HttpGet("Final")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WelcomeMessage))]
        [Produces("application/json", "application/xml")]
        public IActionResult Final()
        {
            WelcomeMessage msg = new WelcomeMessage()
            {
                Message = "Ceci est la derniere demo de l'intro O_o"
            };

            return Ok(msg);
        }
    }
}
