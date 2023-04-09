﻿namespace Shops.Domain;
/// <summary>
/// ProductQuantity - class describing quantity of products in stores
/// </summary>
public class ProductQuantity
{
    public ProductQuantity() { }
    public ProductQuantity(int id, int productId, int shopId, double quantity)
    {
        Id = id;
        ProductId = productId;
        ShopId = shopId;
        Quantity = quantity;
    }
    /// <summary>
    /// Id is used to store the ID.
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Product barcode
    /// </summary>
    public int ProductId { get; set; } = 0;
    /// <summary>
    /// Shop id
    /// </summary>
    public int ShopId { get; set; } = 0;
    /// <summary>
    /// Product quantity
    /// </summary>
    public double Quantity { get; set; } = 0.0;
}