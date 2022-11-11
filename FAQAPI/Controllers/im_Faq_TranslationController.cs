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
    public class im_Faq_TranslationController : ApiController
    {
        private FAQAPIContext db = new FAQAPIContext();

        // GET: api/im_Faq_Translation
        public IQueryable<im_Faq_Translation> Getim_Faq_Translation()
        {
            return db.im_Faq_Translation;
        }

        // GET: api/im_Faq_Translation/5
        [ResponseType(typeof(im_Faq_Translation))]
        public async Task<IHttpActionResult> Getim_Faq_Translation(int id)
        {
            im_Faq_Translation im_Faq_Translation = await db.im_Faq_Translation.FindAsync(id);
            if (im_Faq_Translation == null)
            {
                return NotFound();
            }

            return Ok(im_Faq_Translation);
        }

        // PUT: api/im_Faq_Translation/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putim_Faq_Translation(int id, im_Faq_Translation im_Faq_Translation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != im_Faq_Translation.Id)
            {
                return BadRequest();
            }

            db.Entry(im_Faq_Translation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!im_Faq_TranslationExists(id))
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

        // POST: api/im_Faq_Translation
        [ResponseType(typeof(im_Faq_Translation))]
        public async Task<IHttpActionResult> Postim_Faq_Translation(im_Faq_Translation im_Faq_Translation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.im_Faq_Translation.Add(im_Faq_Translation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = im_Faq_Translation.Id }, im_Faq_Translation);
        }

        // DELETE: api/im_Faq_Translation/5
        [ResponseType(typeof(im_Faq_Translation))]
        public async Task<IHttpActionResult> Deleteim_Faq_Translation(int id)
        {
            im_Faq_Translation im_Faq_Translation = await db.im_Faq_Translation.FindAsync(id);
            if (im_Faq_Translation == null)
            {
                return NotFound();
            }

            db.im_Faq_Translation.Remove(im_Faq_Translation);
            await db.SaveChangesAsync();

            return Ok(im_Faq_Translation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool im_Faq_TranslationExists(int id)
        {
            return db.im_Faq_Translation.Count(e => e.Id == id) > 0;
        }
    }
}