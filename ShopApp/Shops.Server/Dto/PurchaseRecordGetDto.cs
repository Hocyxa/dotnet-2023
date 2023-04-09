﻿
namespace Shops.Server.Dto;
/// <summary>
/// Class PurchaseRecordGetDto is used to make HTTP GET request.
/// </summary>
public class PurchaseRecordGetDto
{
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
    /// What bought (barcode)
    /// </summary>
    public int ProductId { get; set; }
    /// <summary>
    /// What bought (barcode)
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
