using mickion.tuckshops.shared.domain.Entities;

namespace mickion.tuckshops.identity.domain.Entities
{
    public class User: BaseEntity
    {
        public string UserId { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
