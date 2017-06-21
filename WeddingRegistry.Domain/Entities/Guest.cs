using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRegistry.Domain.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AdditionalGuest { get; set; }
        public int ConfirmedGuests { get; set; }
        public string Code { get; set; }
        public DateTime? RSVPDate { get; set; }
        public string Note { get; set; }
        public int EventId { get; set; }
        public int? ParentId { get; set; }
        public int? AddressId { get; set; }
        public bool Attending { get; set; }
    }
}
