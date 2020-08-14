using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_enquete.Domain
{
    public class Poll
    {
        public Poll()
        {
            this.Options = new List<Option>();
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Option> Options { get; set; }
        public virtual Vote Vote { get; set; }
        public virtual View View { get; set; }
        public Poll Get()
        {
            return new Poll
            {
                Description = this.Description,
                Id = this.Id,
                Options = this.Options != null ? this.Options.ToList().ConvertAll(new Converter<Option, Option>(x=> x.Get())) : null,
                Vote = this.Vote !=null ? this.Vote.Get() : null,
                View = this.View != null ? this.View.Get() : null
            };
        }
    }
}
