using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Net;
using FAQ.Data;
using FAQ.data.Entity;

namespace FAQ.api.Controllers
{
    [Route("api/v1/faqs")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class im_FaqController : ControllerBase
    {
        private readonly FaqDBContext db;

        public im_FaqController(FaqDBContext dbContext)
        {
            db = dbContext;
        }

        [Route("get")]
        [HttpGet]
        public ActionResult GetFaq()
        {
            IList<im_Faq> im_Faqs = db.im_Faq.ToList<im_Faq>();

            if (im_Faqs.Count == 0)
            {
                return NotFound();
            }

            return Ok(im_Faqs);
        }

        // GET: api/im_Faq/5
        [Route("api/v1/faqs/{id}")]
        [HttpGet]
        public ActionResult Getim_Faq(int id)
        {
            im_Faq im_Faq = db.im_Faq.Include(f => f.Translations).SingleOrDefault(i => i.Id == id);
            if (im_Faq == null)
            {
                return NotFound();
            }

            return Ok(im_Faq);
        }

        // PUT: api/im_Faq/5
        [Route("api/v1/faqs/{id}")]
        [HttpPut]
        public ActionResult Putim_Faq(int id, im_Faq im_Faq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != im_Faq.Id)
            {
                return BadRequest();
            }

            db.Entry(im_Faq).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                db.SaveChangesAsync();
            }
            catch
            {
            }
            return BadRequest();
        }

        // POST: api/im_Faq
        [HttpPost]
        public ActionResult Postim_Faq(im_Faq im_Faq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Thời gian hiện taij
            im_Faq.CreatedDate = DateTime.Now;
            im_Faq.ModifiedDate = DateTime.Now;

            db.im_Faq.Add(im_Faq);


            foreach (var item in im_Faq.Translations)
            {
                db.im_Faq_Translation.Add(new im_Faq_Translation
                {
                    FaqId = im_Faq.Id,
                    Question = item.Question,
                    Answer = item.Answer,
                    Language = item.Language,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                });
            }

            db.im_Faq_Translation.Add(new im_Faq_Translation
            {
                FaqId = im_Faq.Id,
                Question = im_Faq.Question,
                Answer = im_Faq.Answer,
                Language = im_Faq.Language,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            });

            db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = im_Faq.Id }, im_Faq);
        }

        // DELETE: api/im_Faq/5
        [Route("api/v1/faqs/{id}")]
        [HttpPost]
        public ActionResult Deleteim_Faq(int id)
        {
            im_Faq im_Faq = db.im_Faq.Find(id);
            if (im_Faq == null)
            {
                return NotFound();
            }

            db.im_Faq.Remove(im_Faq);
            db.SaveChangesAsync();

            return Ok(im_Faq);
        }
    }
}
