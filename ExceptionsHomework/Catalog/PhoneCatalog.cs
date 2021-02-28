using System;
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
        
        private Dictionary<int, Shop> _shops;
        private List<Phone> _phones;

        public IEnumerable<Shop> GetShops()
        {
            return _shops.Values;
        }
        
        public PhoneCatalog(ShopList shopList)
        {
            _shops = new Dictionary<int, Shop>();
            foreach (var shop in shopList.Shops)
            {
                _shops.Add(shop.Id, shop);
            }
            _phones = new List<Phone>();
            foreach (var shop in _shops.Values)
            {
                _phones.AddRange(shop.Phones);
            }
        }

        public List<Phone> FindPhone(string desiredModel)
        {
            var phones = new List<Phone>();
            var isUnavailable = false;
            foreach (var phone in _phones)
            {
                if (phone.Model == desiredModel)
                {
                    if (phone.IsAvailable)
                    {
                        phones.Add(phone);
                    }
                    else
                    {
                        isUnavailable = true;
                    }
                }
            }

            if (phones.Count > 0)
            {
                return phones;
            } else if (isUnavailable)
            {
                throw new PhoneUnavailableException();
            }
            else
            {
                throw new PhoneNotFoundException();
            }
        }

        public Phone OrderPhone(List<Phone> phones, string shopName)
        {
            foreach (var phone in phones)
            {
                if (_shops[phone.ShopId].Name == shopName)
                {
                    return phone;
                }
            }

            throw new ShopNotFoundException();
        }

        public Shop GetShopById(int id)
        {
            return _shops[id];
        }
    }
}