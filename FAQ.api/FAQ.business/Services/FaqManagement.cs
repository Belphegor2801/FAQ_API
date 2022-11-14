using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FAQ.Data;
using FAQ.data.Entity;

namespace FAQ.business
{
    public class FaqManagement
    {
        private readonly FaqDBContext _dbcontext;

        public FaqManagement(FaqDBContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public IList<im_Faq> getFaqs()
        {
            IList<im_Faq> im_Faqs = _dbcontext.im_Faq.ToList<im_Faq>();
            return im_Faqs;
        }

        public im_Faq getFaq(int id)
        {
            return _dbcontext.im_Faq.Include(f => f.Translations).SingleOrDefault(i => i.Id == id);
        }

        public void putFaq(im_Faq im_Faq)
        {


            _dbcontext.Entry(im_Faq).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _dbcontext.SaveChangesAsync();
            }
            catch
            {
            }
        }

        public void postFaq(im_Faq im_Faq)
        {
            // Thời gian hiện taij
            im_Faq.CreatedDate = DateTime.Now;
            im_Faq.ModifiedDate = DateTime.Now;

            _dbcontext.im_Faq.Add(im_Faq);


            foreach (var item in im_Faq.Translations)
            {
                _dbcontext.im_Faq_Translation.Add(new im_Faq_Translation
                {
                    FaqId = im_Faq.Id,
                    Question = item.Question,
                    Answer = item.Answer,
                    Language = item.Language,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                });
            }

            _dbcontext.im_Faq_Translation.Add(new im_Faq_Translation
            {
                FaqId = im_Faq.Id,
                Question = im_Faq.Question,
                Answer = im_Faq.Answer,
                Language = im_Faq.Language,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            });

            _dbcontext.SaveChangesAsync();
        }

        public im_Faq deleteFaq(int id)
        {
            im_Faq im_Faq = _dbcontext.im_Faq.Find(id);
            if (im_Faq == null)
            {
                return null;
            }

            _dbcontext.im_Faq.Remove(im_Faq);
            _dbcontext.SaveChangesAsync();
            return im_Faq;
        }

    }
}
