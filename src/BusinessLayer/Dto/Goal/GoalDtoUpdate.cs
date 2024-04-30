

namespace BusinessLayer
{
    public record GoalDtoUpdate
    {
        public string Name { get; set; }
        public decimal AmountOfMoney { get; set; }
        public DateTime Term { get; set; }
    }
}
