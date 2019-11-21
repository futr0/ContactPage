using System.Collections.Generic;

namespace ContactPage.Models
{
    public partial class MessagesAreaOfInterest
    {
        public MessagesAreaOfInterest()
        {
            ContactMessages = new HashSet<ContactMessages>();
        }

        public int Id { get; set; }
        public string AreaOfInterest { get; set; }

        public virtual ICollection<ContactMessages> ContactMessages { get; set; }
    }
}
