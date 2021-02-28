namespace ExceptionsHomework.Models
{
    public class Phone
    {
        public string Model { get; set; }
        public OperationSystemType OperationSystemType { get; set; }
        public string MarketLaunchDate { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
        public int ShopId { get; set; }

        public override string ToString()
        {
            return $"{Model}({OperationSystemType}) {MarketLaunchDate} {Price}";
        }
    }
}