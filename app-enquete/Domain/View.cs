using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_enquete.Domain
{
    public class View
    {
        public int Id { get; set; }
        public int PollId { get; set; }
        public virtual Poll Poll { get; set; }

        public View Get()
        {
            return new View()
            {
                Id = this.Id,
                PollId = this.PollId
            };
        }
    }
}
