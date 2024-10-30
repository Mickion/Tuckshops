SELECT ms.Size, ms.Type, pr.BuyingPrice, pr.SellingPrice, p.Code, p.Color, p.Name
  FROM [TuckShopWarehouseDb].[dbo].[Measurements] ms
  inner join Prices pr on pr.MeasurementId = ms.Id
  inner join Products p on pr.ProductId = p.Id
order by ms.Type
