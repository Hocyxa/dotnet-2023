﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopsDomain;
using ShopsServer.Dto;

namespace ShopsServer.Controllers;
/// <summary>
/// Analytics controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<AnalyticsController> _logger;
    /// <summary>
    /// Used to store factory context
    /// </summary>
    private readonly IDbContextFactory<ShopsContext> _dbContextFactory;
    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Controller constructor 
    /// </summary>
    public AnalyticsController(ILogger<AnalyticsController> logger, IDbContextFactory<ShopsContext> dbContextFactory, IMapper mapper)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Display information about all products in a given shop.
    /// </summary>
    /// <param name="id"> Id of shop.</param>
    /// <returns>Ok(information about all products in shop by id)</returns>
    [HttpGet("information-product-in-shop")]
    public async Task<ActionResult<ProductQuantityGetDto>> Get(int id)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();
        var foundShop = await ctx.Shops.FirstOrDefaultAsync(fShop => fShop.Id == id);
        if (foundShop == null)
            return NotFound();
        _logger.LogInformation("Get list of products in shop");
        var query = await
            (from shop in ctx.Shops
             where shop.Id == id
             select shop.Products).ToListAsync();
        if (query[0].Count == 0)
        {
            return NotFound();
        }
        else
        {
            var result = _mapper.Map<IEnumerable<ProductQuantity>, IEnumerable<ProductQuantityGetDto>>(query[0]);
            return Ok(result);
        }

    }
    /// <summary>
    /// For a given product, display a list of stores in which it is available.
    /// </summary>
    /// <param name="id"> Id of product.</param>
    /// <returns>Ok(information about all products in shop by id)</returns>
    [HttpGet("shops-with-product")]
    public async Task<ActionResult> GetProductAvailable(int id)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();
        var foundProduct = await ctx.Products.FirstOrDefaultAsync(fProduct => fProduct.Id == id);
        if (foundProduct == null)
            return NotFound();
        _logger.LogInformation("Get list of shop with product");
        var query = await
            (from shop in ctx.Shops
             from products in shop.Products
             where products.ProductId == id
             select shop).ToListAsync();
        if (query.Count == 0)
        {
            return NotFound();
        }
        var result = _mapper.Map<IEnumerable<Shop>, IEnumerable<ShopGetDto>>(query);
        return Ok(result);
    }
    /// <summary>
    /// Output the average cost products groups in shops
    /// </summary>
    /// <returns>Ok(the average cost products groups in shops)</returns>
    [HttpGet("average-price-product-groups")]
    public async Task<ActionResult> GetAvgPriceProductGroup()
    {
        _logger.LogInformation("Get list of avg price ");
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();
        var productInShop = await
            (from shop in ctx.Shops
             from products in shop.Products
             select products).ToListAsync();

        var result =
            (from productShop in productInShop
             join products in ctx.Products on productShop.ProductId equals products.Id
             join shops in ctx.Shops on productShop.ShopId equals shops.Id
             group new { products, shops } by new { products.ProductGroupId, shops.Id } into grp
             select new
             {
                 ShopId = grp.Key.Id,
                 PoductGroup = grp.Key.ProductGroupId,
                 AvgPrice = grp.Average(x => x.products.Price)
             }
            ).ToList();
        return Ok(result);
    }
    /// <summary>
    /// Output the top 5 purchases.
    /// </summary>
    /// <returns>Ok(information about top 5 purchases)</returns>
    [HttpGet("top-5-purchases")]
    public async Task<ActionResult<IEnumerable<PurchaseRecordGetDto>>> GetTop5Purchases()
    {
        _logger.LogInformation("Get list of top 5 purchases");
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();
        var topPurch = await
            (from shop in ctx.Shops
             from purchaseRecords in shop.PurchaseRecords
             orderby purchaseRecords.Sum descending
             select purchaseRecords
            ).Take(5).ToListAsync();
        var result = _mapper.Map<IEnumerable<PurchaseRecord>, IEnumerable<PurchaseRecordGetDto>>(topPurch);

        return Ok(result);
    }
    /// <summary>
    /// Display all information about goods exceeding the storage limit date.
    /// </summary>
    /// <returns>Ok(information about goods exceeding the storage limit date)</returns>
    [HttpGet("product-delay")]
    public async Task<ActionResult> GetProductDelay()
    {
        _logger.LogInformation("Get list of product delay");
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();
        var productInShop = await
            (from shop in ctx.Shops
             from products in shop.Products
             select products).ToListAsync();
        var expiredProduct =
            (from productShop in productInShop
             join products in ctx.Products on productShop.ProductId equals products.Id
             join shops in ctx.Shops on productShop.ShopId equals shops.Id
             where products.StorageLimitDate < DateTime.Now
             select new
             {
                 ShopId = shops.Id,
                 ProductId = products.Id,
                 StorageLimitDate = products.StorageLimitDate,
             }
            ).ToList();
        return Ok(expiredProduct);
    }
    /// <summary>
    /// Display a list of stores in which goods were sold for a month in excess of the specified amount.
    /// </summary>
    /// <param name="amount">Specified amount.</param>
    /// <param name="beginDate">The number from which the month is counted.</param>
    /// <returns>Ok(stores in which goods were sold for a month in excess of the specified amount)</returns>
    [HttpGet("shop-earned-more")]
    public async Task<ActionResult> GetShopEarnedMore(double amount, DateTime beginDate)
    {
        _logger.LogInformation("Get list of stores in which goods were sold for a month in excess of the specified amount");
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();
        var purchases = await
           (from shop in ctx.Shops
            from purchaseRecords in shop.PurchaseRecords
            select new
            {
                Shop = shop,
                DateSale = purchaseRecords.DateSale,
                Sale = purchaseRecords.Sum
            }
            ).ToListAsync();
        var result =
           (from purchase in purchases
            where purchase.DateSale >= beginDate && purchase.DateSale <= beginDate.AddMonths(1)
            group purchase by purchase.Shop into shopGrp
            select new
            {
                ShopId = shopGrp.Key.Id,
                SumSale = shopGrp.Sum(purchase => purchase.Sale)
            } into shopSales
            where shopSales.SumSale >= amount
            select new
            {
                ShopId = shopSales.ShopId,
                SumSale = shopSales.SumSale,
            }
            ).ToList();

        return Ok(result);
    }

}
