using System.Reflection.Metadata;

namespace Relacionamentos.Models
{
    public class PostClass
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishedOn { get; set; }

        public bool Archived { get; set; }
        public int BlogId { get; set; }

        public BlogClass? Blog { get; set; }
    }
}
