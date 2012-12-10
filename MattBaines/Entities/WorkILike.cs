using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

    public class WorkILike
    {
        [Key]
        public Guid Id { get; set; }

        public string Type { get; set; }
        [Required]
        public string Title { get; set; }
        public string Course { get; set; }
        public string Year { get; set; }
        [Required]
        [UIHint("tinymce_jquery_simple"), AllowHtml]
        [DataType(DataType.Html)]
        public string Summary { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public WorkILike()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
    }