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
        var query = 
            (from shop in _shopFixtture.Shops
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

    }
   
}