using System.Collections.Generic;
using System.Reflection;
using ExceptionsHomework.Exceptions;
using ExceptionsHomework.Models;
using log4net;

namespace ExceptionsHomework.Catalog
{
    public class PhoneCatalog
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Dictionary<int, Shop> _shops;
        private readonly List<Phone> _allPhones;
        private List<Phone> _filteredPhones;

        public PhoneCatalog(ShopList shopList)
        {
            _shops = new Dictionary<int, Shop>();
            foreach (var shop in shopList.Shops)
            {
                _shops.Add(shop.Id, shop);
            }

            _allPhones = new List<Phone>();
            foreach (var shop in _shops.Values)
            {
                _allPhones.AddRange(shop.Phones);
            }

            _filteredPhones = new List<Phone>(_allPhones);
        }

        public void FilterPhonesByModel(string desiredModel)
        {
            var appropriatedPhones = new List<Phone>();
            var isUnavailable = false;
            foreach (var phone in _allPhones)
            {
                if (phone.Model == desiredModel)
                {
                    if (phone.IsAvailable)
                    {
                        appropriatedPhones.Add(phone);
                    }
                    else
                    {
                        isUnavailable = true;
                    }
                }
            }

            if (appropriatedPhones.Count > 0)
            {
                _filteredPhones = new List<Phone>(appropriatedPhones);
            }
            else if (isUnavailable)
            {
                throw new PhoneUnavailableException(
                    "Данный товар отсутствует на складе. Попробуйте выбрать другой товар.");
            }
            else
            {
                throw new PhoneNotFoundException("Введенный Вами товар не найден. Попробуйте выбрать другой товар.");
            }
        }

        public Phone OrderPhone(string shopName)
        {
            foreach (var phone in _filteredPhones)
            {
                if (_shops[phone.ShopId].Name == shopName)
                {
                    return phone;
                }
            }

            throw new ShopNotFoundException(
                "Введенного Вами магазина не существует. Попробуйте ввести название магазина заново.");
        }

        public int GetNumberOfAvailablePhones(Shop shop, OperationSystemType type)
        {
            var result = 0;
            var phones = shop.Phones;
            foreach (var phone in phones)
            {
                if (phone.OperationSystemType == type && phone.IsAvailable)
                {
                    result++;
                }
            }

            return result;
        }

        public IEnumerable<Shop> GetShops()
        {
            return _shops.Values;
        }

        public Shop GetShopById(int id)
        {
            return _shops[id];
        }

        public List<Phone> getPhones()
        {
            return _filteredPhones;
        }
    }
}