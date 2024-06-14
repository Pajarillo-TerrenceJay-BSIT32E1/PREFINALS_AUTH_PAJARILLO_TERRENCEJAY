namespace ProtectedApi
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class ValueController : ControllerBase
    {
        private readonly string _owner = "Terrence Jay Pajarillo";

        [HttpGet("about/me")]
        public IActionResult AboutMe()
        {
            var random = new Random();
            var thingsAboutOwner = new[]
            {
                "Im currently pursuing Bachelor of Science in Information Technology in Lyceum of Alabang",
                "I love watching anime, playing online games and working on improving my design",
                "I like to ride my motorcycle and and enjoy the exhilarating experience"
            };
            var thing = thingsAboutOwner[random.Next(thingsAboutOwner.Length)];

            return Ok(thing);
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            return Ok(_owner);
        }

        [HttpPost("about")]
        public IActionResult About([FromBody] NameModel model)
        {
            return Ok($"Hi {model.Name} from {_owner}");
        }
    }

    public class NameModel
    {
        private string? _name = "Sr. Nino Francisco Alamo";
        public string? Name
        {
            get { return _name == "string" ? "Sr. Nino Francisco Alamo" : _name; }
            set { _name = value; }
        }
    }
}