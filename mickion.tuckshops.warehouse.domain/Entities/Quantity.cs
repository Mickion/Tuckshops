﻿using mickion.tuckshops.shared.domain.Contracts.Entities;
using mickion.tuckshops.shared.domain.Entities;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class Quantity: IAuditableEntity
    {

        /// <summary>
        /// Gets or sets Product Measurement StockOnHand
        /// </summary>
        public int StockOnHand { get; set; }

        /// <summary>
        /// Gets or sets Product Measurement StockOnOrder
        /// </summary>
        public int StockOnOrder { get; set; }

        /// <summary>
        /// Each stock quantity belongs to Product + Measurement (i.e. 500mg bread)
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// Each stock quantity belongs to Product + Measurement (i.e. 500mg bread)
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
