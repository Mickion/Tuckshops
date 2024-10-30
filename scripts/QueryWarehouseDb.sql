SELECT m.Size, m.Type, pc.BuyingPrice, pc.SellingPrice, pr.Code, pr.Name, Pr.Color, br.Name, br.Address, q.*
  FROM [TuckShopWarehouseDb].[dbo].[Prices] pc
  inner join Products pr on pr.Id = pc.ProductId
  inner join Measurements m on m.Id = pc.MeasurementId
  inner join Brands br on br.Id = pr.BrandId
  inner join Quantities q on q.MeasurementId = m.Id
