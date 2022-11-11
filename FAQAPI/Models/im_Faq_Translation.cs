using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FAQAPI.Models
{
    public class im_Faq_Translation
    {
        [Key]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        [MaxLength(5)]
        public string Language { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        // Foreign Key
        [ForeignKey("Faq")]
        public int? FaqId { get; set; }
        public im_Faq Faq { get; set; }
    }
}