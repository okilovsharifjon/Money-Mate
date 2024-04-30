using DataAccess;


namespace BusinessLayer
{
    public record UserDtoUpdate
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
