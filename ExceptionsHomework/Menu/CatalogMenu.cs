using System;
using System.Collections.Generic;
using ExceptionsHomework.Catalog;
using ExceptionsHomework.Exceptions;
using ExceptionsHomework.Models;
using log4net;

namespace ExceptionsHomework.Menu
{
    public class CatalogMenu
    {
        private static readonly ILog _log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private PhoneCatalog _phoneCatalog;

        public CatalogMenu(PhoneCatalog phoneCatalog)
        {
            _phoneCatalog = phoneCatalog;
        }

        public void PrintShopsInfo()
        {
            foreach (var shop in _phoneCatalog.GetShops())
            {
                _log.Info($"Information about shop {shop.Name}({shop.Id}) {shop.Description}.");
                var numberOfAndroid = shop.NumberOfAvailablePhones(OperationSystemType.Android);
                var numberOfIOS = shop.NumberOfAvailablePhones(OperationSystemType.IOS);
                _log.Info($"Number of Android phones is {numberOfAndroid}.");
                _log.Info($"Number of IOS phones is {numberOfIOS}.");
            }
        }

        public List<Phone> ChoosePhoneMenu()
        {
            _log.Info("Какой телефон Bы желаете приобрести? ");
            bool isSuccess = false;
            List<Phone> phones = null;
            while (!isSuccess)
            {
                var desiredPhoneModel = Console.ReadLine();
                try
                {
                    phones = _phoneCatalog.FindPhone(desiredPhoneModel);
                    isSuccess = true;
                }
                catch (PhoneNotFoundException exp)
                {
                    _log.Error("Введенный Вами товар не найден. Попробуйте выбрать другой товар.");
                }
                catch (PhoneUnavailableException exp)
                {
                    _log.Error("Данный товар отсутствует на складе. Попробуйте выбрать другой товар.");
                }
            }

            return phones;
        }

        public void PrintPhonesInfo(List<Phone> phones)
        {
            foreach (var phone in phones)
            {
                _log.Info($"{phone.Model} - {_phoneCatalog.GetShopById(phone.ShopId).Name}");
            }
        }

        public void OrderPhone(List<Phone> phones)
        {
            _log.Info($"В каком магазине Bы хотите приобрести {phones[0].Model} ?");
            bool isSuccess = false;
            while (!isSuccess)
            {
                var shopName = Console.ReadLine();
                try
                {
                    var orderedPhone = _phoneCatalog.OrderPhone(phones, shopName);
                    _log.Info($"Заказ {orderedPhone.Model} на сумму {orderedPhone.Price} успешно оформлен! ");
                    isSuccess = true;
                }
                catch (ShopNotFoundException exp)
                {
                    _log.Error("Введенного Вами магазина не существует. Попробуйте ввести название магазина заново.");
                }
            }
        }
    }
}