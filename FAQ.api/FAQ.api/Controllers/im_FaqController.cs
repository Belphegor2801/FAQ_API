using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using FAQ.data.Entity;
using FAQ.business;

namespace FAQ.api.Controllers
{
    [Route("api/v1/faqs")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class im_FaqController : ControllerBase
    {
        private readonly FaqManagement _faqManagement;
        public im_FaqController(FaqManagement faqManagement)
        {
            _faqManagement = faqManagement;
        }

        [Route("api/v1/faqs")]
        [HttpGet]
        public ActionResult GetFaq()
        {
            IList<im_Faq> faqs = _faqManagement.getFaqs();
            return Ok(faqs);
        }

        // GET: api/im_Faq/5
        [Route("api/v1/faqs/{id}")]
        [HttpGet]
        public ActionResult Getim_Faq(int id)
        {
            im_Faq im_Faq = _faqManagement.getFaq(id);
            if (im_Faq == null) return NotFound();

            return Ok(im_Faq);
        }

        // PUT: api/im_Faq/5
        [Route("api/v1/faqs/{id}")]
        [HttpPut]
        public ActionResult Putim_Faq(int id, im_Faq im_Faq)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != im_Faq.Id) return BadRequest();

            _faqManagement.putFaq(im_Faq);

            return BadRequest();
        }

        // POST: api/im_Faq
        [HttpPost]
        public ActionResult Postim_Faq(im_Faq im_Faq)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            _faqManagement.postFaq(im_Faq);

            return CreatedAtRoute("DefaultApi", new { id = im_Faq.Id }, im_Faq);
        }

        // DELETE: api/im_Faq/5
        [Route("api/v1/faqs/{id}")]
        [HttpPost]
        public ActionResult Deleteim_Faq(int id)
        {
            im_Faq im_Faq = _faqManagement.deleteFaq(id);
            if (im_Faq == null) return NotFound();
            return Ok(im_Faq);
        }
    }
}
