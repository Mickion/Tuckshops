namespace mickion.tuckshops.shared.domain.Entities
{
    public class UserEntity: BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
    }
}
