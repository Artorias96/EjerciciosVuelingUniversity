namespace StarWarsWebApi.Models
{
    public class TotalTravelCostModel
    {
        public decimal TotalAmount { get; set; }
        public decimal PriecesPerLunarDay { get; set; }
        public TaxesModel taxes { get; set; }

    }

    public class TaxesModel
    {
        public decimal OriginDefenseCost { get; set; }
        public decimal DestinationDefenseCost { get; set; }
        public decimal EliteDefenseCost { get; set; }
    }
}
