using Microsoft.Extensions.Primitives;

namespace Clean.Architecture.WS.Api.Response
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public int ExpirationSeconds { get; set; }
    }
}
