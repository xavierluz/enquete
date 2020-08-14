using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_enquete.Domain
{
    public class Option
    {
        public Option()
        {

        }
        public int Id { get; set; }
        public string Description { get; set; }
        public int PollId { get; set; }
        public virtual Poll Poll { get; set; }
        public virtual Vote Vote { get; set; }

        public Option Get()
        {
            return new Option()
            {
                Description = this.Description,
                Id = this.Id,
                PollId = this.PollId
            };
        }
    }
}
