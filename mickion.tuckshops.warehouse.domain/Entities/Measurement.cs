using mickion.tuckshops.shared.domain.Contracts.Entities;
using mickion.tuckshops.shared.domain.Entities;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class Measurement: IAuditableEntity
    {
        /// <summary>
        /// Gets or sets 500 ml, 2.5kg etc
        /// </summary>
        public double Size { get; set; }

        /// <summary>
        /// Gets or sets kg, mg, litre
        /// </summary>
        public string Type { get; set; } = string.Empty;
                
        /// <summary>
        /// A Measurement, e.g. 1 litre can belong to many products
        /// </summary>
        public ICollection<Product>? Products { get; set; }

        #region IAuditableEntity
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedByUserId { get; set; }

        #endregion

    }
}
