using System.Collections.Generic;

namespace ExceptionsHomework.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Phone> Phones { get; set; }

        public int NumberOfAvailablePhones(OperationSystemType type)
        {
            var result = 0;
            foreach (var phone in Phones)
            {
                if (phone.OperationSystemType == type && phone.IsAvailable)
                {
                    result++;
                }
            }

            return result;
        }

        public override string ToString()
        {
            return $"{Name}({Id}) - {Description}";
        }
    }
}