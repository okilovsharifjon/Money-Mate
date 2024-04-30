using DataAccess;


namespace BusinessLayer
{
    public record AccountDtoUpdate
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
