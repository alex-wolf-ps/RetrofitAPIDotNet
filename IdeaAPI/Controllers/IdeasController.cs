using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading;

namespace IdeaAPI.Controllers
{
    [Route("[controller]")]
    public class IdeasController : Controller
    {
        private static List<Idea> ideas = new List<Idea>()
            {
                new Idea()
                {
                    Id = 1,
                    Name = "Hello from the server!",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan quis justo quis hendrerit. Curabitur a ante neque. Fusce nec mauris sodales, auctor sem at, luctus eros. Praesent aliquam nibh neque. Duis ut suscipit justo, id consectetur orci. Curabitur ultricies nunc eu enim dignissim, sed laoreet odio blandit.",
                    Status = "idea",
                    Owner = "Jim"
                },
                new Idea()
                {
                    Id = 2,
                    Name = "Migrate to the Cloud",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan quis justo quis hendrerit. Curabitur a ante neque. Fusce nec mauris sodales, auctor sem at, luctus eros. Praesent aliquam nibh neque. Duis ut suscipit justo, id consectetur orci. Curabitur ultricies nunc eu enim dignissim, sed laoreet odio blandit.",
                    Status = "Started",
                    Owner = "Jim"
                },
                new Idea()
                {
                    Id = 3,
                    Name = "Implement Automated Testing",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan quis justo quis hendrerit. Curabitur a ante neque. Fusce nec mauris sodales, auctor sem at, luctus eros. Praesent aliquam nibh neque. Duis ut suscipit justo, id consectetur orci. Curabitur ultricies nunc eu enim dignissim, sed laoreet odio blandit.",
                    Status = "Mind Mapped",
                    Owner = "Jim"
                },
                new Idea()
                {
                    Id = 4,
                    Name = "Improve CI/CD",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan quis justo quis hendrerit. Curabitur a ante neque. Fusce nec mauris sodales, auctor sem at, luctus eros. Praesent aliquam nibh neque. Duis ut suscipit justo, id consectetur orci. Curabitur ultricies nunc eu enim dignissim, sed laoreet odio blandit.",
                    Status = "POC",
                    Owner = "Dave"
                },
                new Idea()
                {
                    Id = 5,
                    Name = "Modify Change Control Process",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan quis justo quis hendrerit. Curabitur a ante neque. Fusce nec mauris sodales, auctor sem at, luctus eros. Praesent aliquam nibh neque. Duis ut suscipit justo, id consectetur orci. Curabitur ultricies nunc eu enim dignissim, sed laoreet odio blandit.",
                    Status = "Exploratory",
                    Owner = "Larry"
                }
            };

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ideas);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var idea = ideas.FirstOrDefault(x => x.Id == id);

            if(idea != null)
            {
                return Ok(idea);
            }

            return NotFound();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Idea newIdea)
        {
            var newMaxId = ideas.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            
            newIdea.Id = newMaxId;
            ideas.Add(newIdea);
            return CreatedAtAction("Get", new { id = newIdea.Id }, newIdea);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm]Idea updateIdea)
        {
            var idea = ideas.FirstOrDefault(x => x.Id == id);
            if(idea == null)
            {
                return NotFound();
            }

            idea.Name = updateIdea.Name;
            idea.Owner = updateIdea.Owner;
            idea.Status = updateIdea.Status;
            idea.Description = updateIdea.Description;

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var idea = ideas.FirstOrDefault(x => x.Id == id);
            if(idea == null)
            {
                return NotFound();
            }

            ideas.Remove(idea);
            return StatusCode(204);
        }
    }
}
