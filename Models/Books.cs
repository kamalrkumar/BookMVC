using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebAPI.Model
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter Book Name....!")]
        [DisplayName("Book Name")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Please enter Author Name....!")]
        [DisplayName("Author Name")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Please enter Time Stamp....!")]
        [DisplayName("Book Time Stamp")]
        public string RepTimeStamp { get; set; }

        [Required(ErrorMessage = "Please enter Book Category....!")]
        [DisplayName("Book Category")]
        public string BookCategory { get; set; }

        [Required(ErrorMessage = "Please enter Book Description....!")]
        [DisplayName("Book Description")]
        public string BookDescription { get; set; }

    }
}
