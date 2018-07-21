using System.Collections.Generic;

namespace TelecomProviderApi.Models
{
    public class CustomerContactModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<ContactNumberModel> ContactNumbers { get; set; }

        public string GetFullName() => string.Join(" ", new List<string> { Title, FirstName, LastName });
    }
}
