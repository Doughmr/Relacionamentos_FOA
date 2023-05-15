using Microsoft.Extensions.Hosting;

namespace Relacionamentos.Models
{
    public class BlogClass
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public virtual Uri SiteUri { get; set; }



        public ICollection<PostClass>? Posts { get; }
    }
}
