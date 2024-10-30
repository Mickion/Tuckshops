using mickion.tuckshops.shared.domain.Contracts.Entities;
using mickion.tuckshops.shared.domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class Brand: BaseEntity, IEntity
    {
        /// <summary>
        /// Gets or sets brand name
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets brand Address
        /// </summary>
        public string Address { get; set; } = string.Empty;
#warning Extract to Address Entity

        /// <summary>
        /// A brand can have many products, i.e. Apple has iPhones, iPads etc..
        /// </summary>
        public IEnumerable<Product> Products { get; set; } = [];
    }
}
