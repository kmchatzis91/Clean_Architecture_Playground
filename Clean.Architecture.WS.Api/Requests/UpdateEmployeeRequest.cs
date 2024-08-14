namespace Clean.Architecture.WS.Api.Requests
{
    public class UpdateEmployeeRequest
    {
        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public long RoleId { get; set; }
        public long CompanyId { get; set; }
    }
}
