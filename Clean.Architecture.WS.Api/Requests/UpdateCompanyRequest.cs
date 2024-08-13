namespace Clean.Architecture.WS.Api.Requests
{
    public class UpdateCompanyRequest
    {
        public long CompanyId { get; set; }
        public string Name { get; set; }
    }
}
