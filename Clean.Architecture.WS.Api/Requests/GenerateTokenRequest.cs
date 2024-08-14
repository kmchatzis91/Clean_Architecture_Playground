namespace Clean.Architecture.WS.Api.Requests
{
    public class GenerateTokenRequest
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
