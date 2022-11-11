using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FAQAPI.Models;
using FAQAPI.Data;

namespace FAQAPI.Controllers
{
    [Route("api/v1/faqs")]
    public class im_FaqController : ApiController
    {
        private FAQAPIContext db = new FAQAPIContext();

        // GET: api/im_Faq
        public IHttpActionResult Getim_Faq()
        {
            IList<im_Faq> im_Faqs = db.im_Faq.Include(f => f.Translations).ToList<im_Faq>();

            if (im_Faqs.Count == 0)
            {
                return NotFound();
            }

            return Ok(im_Faqs);
        }

        // GET: api/im_Faq/5
        [Route("api/v1/faqs/{id}")]
        [ResponseType(typeof(im_Faq))]
        public async Task<IHttpActionResult> Getim_Faq(int id)
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
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putim_Faq(int id, im_Faq im_Faq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != im_Faq.Id)
            {
                return BadRequest();
            }

            db.Entry(im_Faq).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!im_FaqExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/im_Faq
        [ResponseType(typeof(im_Faq))]
        public async Task<IHttpActionResult> Postim_Faq(im_Faq im_Faq)
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

            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = im_Faq.Id }, im_Faq);
        }

        // DELETE: api/im_Faq/5
        [Route("api/v1/faqs/{id}")]
        [ResponseType(typeof(im_Faq))]
        public async Task<IHttpActionResult> Deleteim_Faq(int id)
        {
            im_Faq im_Faq = await db.im_Faq.FindAsync(id);
            if (im_Faq == null)
            {
                return NotFound();
            }

            db.im_Faq.Remove(im_Faq);
            await db.SaveChangesAsync();

            return Ok(im_Faq);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool im_FaqExists(int id)
        {
            return db.im_Faq.Count(e => e.Id == id) > 0;
        }
    }
}