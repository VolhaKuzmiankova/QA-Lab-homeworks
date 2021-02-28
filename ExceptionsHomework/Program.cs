using System;
using System.IO;
using ExceptionsHomework.Catalog;
using ExceptionsHomework.Menu;
using ExceptionsHomework.Models;
using log4net;
using log4net.Config;
using Newtonsoft.Json;

namespace ExceptionsHomework
{
    class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            BasicConfigurator.Configure();

            //deserialize
            ShopList shopList;
            try
            {
                var str = File.ReadAllText("appsettings.json");
                shopList = JsonConvert.DeserializeObject<ShopList>(str);
            }
            catch (Exception exp)
            {
                _log.Error($"Exception - {exp.Message} during deserialization...\n Finishing the program");
                return;
            }

            var phoneCatalog = new PhoneCatalog(shopList);
            var catalogMenu = new CatalogMenu(phoneCatalog);

            catalogMenu.PrintShopsInfo();
            var phones = catalogMenu.ChoosePhoneMenu();
            catalogMenu.PrintPhonesInfo(phones);
            catalogMenu.OrderPhone(phones);
        }
    }
}