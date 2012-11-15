using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

    public class AdvertisingCreativeObject
    {
        [Key]
        public virtual Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [UIHint("tinymce_jquery_simple"), AllowHtml]
        [DataType(DataType.Html)]
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string ImagePath { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
        public virtual AdvertisingCreativeCategory Category { get; set; }

        [NotMapped]
        public List<AdvertisingCreativeCategory> CategoryList { get; set; }

        public AdvertisingCreativeObject()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
    }