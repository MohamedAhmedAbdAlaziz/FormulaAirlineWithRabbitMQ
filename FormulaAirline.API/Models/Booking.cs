namespace FormulaAirline.API.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string PassengerName { get; set; } = "";
        public string PassportNb { get; set; } = "";
        public string Form { get; set; } = "";
        public string To { get; set; } = "";
        public int Status { get; set; }
    }
}
