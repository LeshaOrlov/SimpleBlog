using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Text { get; set; }
        public bool IsPublic { get; set; }
        public int? AuthorId { get; set; }
        public User Author { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateLastChange { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
