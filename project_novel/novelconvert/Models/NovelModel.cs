using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace novelconvert.Models
{
    [Table("Novels")]
    public class NovelModel
    {
        [Display(Name = "Novel Id")]
        [Key]
        public string Id { get; set;  }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Link { get; set; }

        [StringLength(100)]
        public string Author { get; set; }
        
        public int Chap_number { get; set; }
        public int Rating { get; set; }
        public int Viewer { get; set; }
        public int Voting { get; set; }
        public int Recommandation { get; set; }
        public string Image_link { get; set; }
    }
}