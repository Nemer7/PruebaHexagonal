using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Supplier : BaseEntity<string>
    {
        public string NIT { get; set; }
        public string  BusinessName { get; set; }
        public string  Email { get; set; }
        public Location Location { get; set; }
        public ContactInformation ContactInformation { get; set; }


        public Supplier(string nit, string businessName, string email, Location location, ContactInformation contactInformation)
        {
            NIT = nit;
            BusinessName = businessName;
            Email = email;
            Location = location;
            ContactInformation = contactInformation;
        }

        

    }
}
