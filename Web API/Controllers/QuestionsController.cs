using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {
            private readonly QuestionsContext db;
            public QuestionsController(QuestionsContext context)
            {
                this.db = context;
                if (!db.Questions.Any())
                {
                    db.Questions.Add(new Question { QuestionText = "Чем меряются⁣ ⁣между ⁣собой любители армрестлинга?", Answers =  "Силой рук || Остротой зубов || Быстротой ног || Размерами животов" });
                    db.SaveChanges();
                }
            }

            // GET: api/<controller>
            [HttpGet]
            public IEnumerable<Question> Get()
            {
                return db.Questions.ToList();
            }

            // GET api/<controller>/5
            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                Question question = db.Questions.FirstOrDefault(x => x.Id == id);
                if (question == null)
                    return NotFound();
                return new ObjectResult(question);
            }

            // POST api/<controller>
            [HttpPost]
            public IActionResult Post([FromBody]Question question)
            {
                if (question == null)
                {
                    return BadRequest();
                }

                db.Questions.Add(question);
                db.SaveChanges();
                return Ok(question);
            }

            // PUT api/<controller>/
            [HttpPut]
            public IActionResult Put([FromBody]Question question)
            {
                if (question == null)
                {
                    return BadRequest();
                }
                if (!db.Questions.Any(x => x.Id == question.Id))
                {
                    return NotFound();
                }

                db.Update(question);
                db.SaveChanges();
                return Ok(question);
            }

            // DELETE api/<controller>/5
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                Question question = db.Questions.FirstOrDefault(x => x.Id == id);
                if (question == null)
                {
                    return NotFound();
                }
                db.Questions.Remove(question);
                db.SaveChanges();
                return Ok(question);
            }
    }
}
