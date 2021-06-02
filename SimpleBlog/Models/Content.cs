using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public Content Parent { get; set; }
        public int? ArticleId { get; set; }
        public Article Article { get; set; }
        public ICollection<Content> SubContents { get; set; }
    }
}
