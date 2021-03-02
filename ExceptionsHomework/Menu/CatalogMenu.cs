using System;
using System.Reflection;
using ExceptionsHomework.Catalog;
using ExceptionsHomework.Exceptions;
using ExceptionsHomework.Models;
using log4net;

namespace ExceptionsHomework.Menu
{
    public class CatalogMenu
    {
        private static readonly ILog _log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly PhoneCatalog _phoneCatalog;
        private string _desiredPhoneModel;

        public CatalogMenu(PhoneCatalog phoneCatalog)
        {
            _phoneCatalog = phoneCatalog;
        }

        public void PrintShopsInfo()
        {
            _log.Info("=====Print Shops information with available phones=====");
            var shops = _phoneCatalog.GetShops();
            foreach (var shop in shops)
            {
                _log.Info($"Information about shop {shop.Name}({shop.Id}) {shop.Description}.");
                var numberOfAndroid = _phoneCatalog.GetNumberOfAvailablePhones(shop, OperationSystemType.Android);
                var numberOfIOS = _phoneCatalog.GetNumberOfAvailablePhones(shop, OperationSystemType.IOS);
                _log.Info($"Number of Android phones is {numberOfAndroid}.");
                _log.Info($"Number of IOS phones is {numberOfIOS}.");
            }
        }

        public void PrintPhonesInfo()
        {
            _log.Info("=====Print phone info=====");
            foreach (var phone in _phoneCatalog.getPhones())
            {
                _log.Info($"{phone.Model} - {_phoneCatalog.GetShopById(phone.ShopId).Name}");
            }
        }

        public void FilterPhonesByModel()
        {
            _log.Info("Какой телефон Bы желаете приобрести? ");
            var isSuccess = false;
            while (!isSuccess)
            {
                _desiredPhoneModel = Console.ReadLine();
                try
                {
                    _phoneCatalog.FilterPhonesByModel(_desiredPhoneModel);
                    isSuccess = true;
                }
                catch (PhoneNotFoundException exp)
                {
                    _log.Error(exp.Message);
                }
                catch (PhoneUnavailableException exp)
                {
                    _log.Error(exp.Message);
                }
            }
        }

        public void OrderPhone()
        {
            _log.Info($"В каком магазине Bы хотите приобрести {_desiredPhoneModel} ?");
            var isSuccess = false;
            while (!isSuccess)
            {
                var shopName = Console.ReadLine();
                try
                {
                    var orderedPhone = _phoneCatalog.OrderPhone(shopName);
                    _log.Info($"Заказ {orderedPhone.Model} на сумму {orderedPhone.Price} успешно оформлен! ");
                    isSuccess = true;
                }
                catch (ShopNotFoundException exp)
                {
                    _log.Error(exp.Message);
                }
            }
        }
    }
}