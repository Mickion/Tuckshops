using mickion.tuckshops.shared.domain.Contracts.Entities;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class MeasurementProduct: IEntity
    {
        #region IEntity
        public Guid Id { get; set; }
        #endregion

        /// <summary>
        /// Gets or sets MeasurementsId
        /// </summary>
        public Guid MeasurementsId { get; set; }

        /// <summary>
        /// Gets or sets ProductsId
        /// </summary>
        public Guid ProductsId { get; set; }
        
    }
}
