using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCampaigns.Model
{
    public class association
    {
        public string associationName { get; set; }
        public string email { get; set; }
        public string uri { get; set; }
        public string hashtag { get; set; }

        public int userId { get; set; }
    }
}
