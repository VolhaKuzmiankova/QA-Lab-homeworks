using System;
using System.Collections.Generic;
using System.IO;
using ExceptionsHomework.Models;
using log4net;
using Newtonsoft.Json;

namespace ExceptionsHomework.Readers
{
    public static class ShopDataReader
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(ShopDataReader));

        public static ShopList readData(string filePath)
        {
            ShopList shopList;
            try
            {
                var str = File.ReadAllText(filePath);
                shopList = JsonConvert.DeserializeObject<ShopList>(str);
            }
            catch (Exception exp)
            {
                _log.Error($"Exception - {exp.Message} during deserialization...\n Finishing the program");
                return null;
            }

            return shopList;
        } 
    }
}