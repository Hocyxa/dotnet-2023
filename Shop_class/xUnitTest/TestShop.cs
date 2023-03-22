using Shop_class;

namespace xUnitTest;

public class TestShop : IClassFixture<ShopFixtture>
{
    private readonly ShopFixtture _shopFixtture;
    public TestShop(ShopFixtture shopFixtture) 
    {
        _shopFixtture = shopFixtture;
    }


    /// <summary>
    /// 1) ������� �������� � ���� ������� � �������� ��������.
    /// </summary>
    [Fact]
    public void Test1()
    {
        var fixtureShop = _shopFixtture.Shops.ToList();
        var query = 
            (from shop in fixtureShop
             where shop.ShopId == 1
            select shop.Products).ToList()[0];
        Assert.Equal(7, query.Count());
    }

    /// <summary>
    /// 2) ��� ��������� ������ ������� ������ ���������, � ������� �� ��������� � �������.
    /// </summary>
    [Fact]
    public void Test2()
    {
        var fixtureShop = _shopFixtture.Shops.ToList();
        var query =
            (from shop in fixtureShop
             from Products in shop.Products
             where Products.Barcode == "1"
             select shop).ToList();
        Assert.Equal(2, query.Count());  
    }
    /// <summary>
    /// 3) ������� ���������� � ������� ��������� ������� ������ �������� ������ ��� ������� ��������. 
    /// </summary>
    [Fact]
    public void Test3() 
    {
        var fixtureShop = _shopFixtture.Shops.ToList();
        var productList = _shopFixtture.Products.ToList();
        var prodectinshop = 
            (from shop in fixtureShop
            from products in shop.Products
            select products).ToList();

        var result =
            (from ps in prodectinshop
             join p in productList on ps.Barcode equals p.Barcode
             join s in fixtureShop on ps.ShopId equals s.ShopId
             group new { p, s } by new { p.PoductGroupCode, s.ShopId } into grp
             select new
             {
                 ShopId = grp.Key.ShopId,
                 PoductGroup = grp.Key.PoductGroupCode,
                 AvgPrice = grp.Average(x => x.p.Price)
             }
            ).ToList();
        Assert.Equal(16,result.Count());
        Assert.Contains(result, x => x.ShopId == 1 && x.PoductGroup == 1 && x.AvgPrice == 75.0);
        Assert.Contains(result, x => x.ShopId == 3 && x.PoductGroup == 2 && x.AvgPrice == 224.5);
    }

    /// <summary>
    /// 4) ������� ��� 5 ������� �� ����� ����� �������.
    /// </summary>
    [Fact]
    public void Test4()
    {

    }
   
}