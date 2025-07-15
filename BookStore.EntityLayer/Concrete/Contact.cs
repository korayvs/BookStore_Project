using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityLayer.Concrete
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string AboutUs { get; set; }
        public string Email { get; set; }
        public string ContactAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string SocialMedia { get; set; }        
    }
}
