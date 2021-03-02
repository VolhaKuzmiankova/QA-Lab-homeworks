using ExceptionsHomework.Catalog;
using ExceptionsHomework.Menu;
using ExceptionsHomework.Readers;
using log4net.Config;

namespace ExceptionsHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicConfigurator.Configure();

            //deserialize
            var shopList = ShopDataReader.readData("appsettings.json");

            if (shopList != null)
            {
                var phoneCatalog = new PhoneCatalog(shopList);
                var catalogMenu = new CatalogMenu(phoneCatalog);

                catalogMenu.PrintShopsInfo();
                catalogMenu.PrintPhonesInfo();
                catalogMenu.FilterPhonesByModel();
                catalogMenu.PrintPhonesInfo();
                catalogMenu.OrderPhone();
            }
        }
    }
}