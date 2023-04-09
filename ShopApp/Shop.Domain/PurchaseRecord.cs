﻿namespace Shops.Domain;
/// <summary>
/// PurchaseRecord - class describing purchase record
/// </summary>
public class PurchaseRecord
{
    public PurchaseRecord() { }
    public PurchaseRecord(int id, int shopId, int customerId, Customer customer, int productId, Product product, double quantity, DateTime dateSale)
    {
        Id = id;
        ShopId = shopId;
        CustomerId = customerId;
        Customer = customer;
        ProductId = productId;
        Product = product;
        Quantity = quantity;
        DateSale = dateSale;
        Sum = product.Price * quantity;
    }
    /// <summary>
    /// Id is used to store the ID.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Were bought
    /// </summary>
    public int ShopId { get; set; }
    /// <summary>
    /// Who bought (id)
    /// </summary>
    public int CustomerId { get; set; }
    /// <summary>
    /// Who bought 
    /// </summary>
    public Customer Customer { get; set; } = new Customer();
    /// <summary>
    /// What bought (barcode)
    /// </summary>
    public int ProductId { get; set; }
    /// <summary>
    /// What bought (barcode)
    /// </summary>
    public Product Product { get; set; } = new Product();
    /// <summary>
    /// How much bought
    /// </summary>
    public double Quantity { get; set; } = 0.0;
    /// <summary>
    /// When bought
    /// </summary>
    public DateTime DateSale { get; set; }
    /// <summary>
    /// Purchase amount
    /// </summary>
    public double Sum { get; set; } = 0.0;
}