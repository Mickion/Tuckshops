using mickion.tuckshops.shared.domain.Contracts.Entities;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class Price: IAuditableEntity
    {
        /// <summary>
        /// Gets or sets the amount we buy the product for
        /// </summary>
        public decimal BuyingPrice { get; set; }

        /// <summary>
        /// Gets or sets the amount we sell the product for
        /// </summary>
        public decimal SellingPrice { get; set; }

        /// <summary>
        /// Each Price quantity belongs to Product + Measurement (i.e. 500mg bread)
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// Each Price quantity belongs to Product + Measurement (i.e. 500mg bread)
        /// </summary>
        public Measurement? Measurement { get; set; }

        #region IAuditableEntity
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        #endregion

    }
}
