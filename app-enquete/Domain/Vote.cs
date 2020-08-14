using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_enquete.Domain
{
    public class Vote
    {
        public int PollId { get; set; }
        public int OptionId { get; set; }
        public virtual Poll Poll { get; set; }
        public virtual Option Option { get; set; }
       
        public Vote Get()
        {
            return new Vote()
            {
                PollId = this.PollId,
                OptionId = this.OptionId
            };
        }
    }
}
