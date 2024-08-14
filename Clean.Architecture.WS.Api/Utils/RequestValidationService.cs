using Clean.Architecture.WS.Api.Requests;

namespace Clean.Architecture.WS.Api.Utils
{
    public class RequestValidationService
    {
        #region IdentityController
        public string GenerateTokenRequestValidation(GenerateTokenRequest request)
        {
            var errors = new List<string>();

            if (request.UserId == 0)
            {
                errors.Add("userId");
            }

            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                errors.Add("firstName");
            }

            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                errors.Add("lastName");
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                errors.Add("email");
            }

            if (errors.Count == 1)
            {
                return $"{errors[0]} is required!";
            }

            if (errors.Count == 2)
            {
                return $"{errors[0]} and {errors[1]} are required!";
            }

            if (errors.Count > 2)
            {
                var allErrors = "";

                foreach (var e in errors)
                {
                    if (e == errors.Last())
                    {
                        allErrors += $"and {e}";
                        break;
                    }

                    allErrors += $"{e}, ";
                }

                return $"{allErrors} are required!";
            }

            return Consts.Ok;
        }
        #endregion

        #region EmployeeController
        public string AddEmployeeRequestValidation(AddEmployeeRequest request)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                errors.Add("firstName");
            }

            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                errors.Add("lastName");
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                errors.Add("email");
            }

            if (string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                errors.Add("phoneNumber");
            }

            if (request.RoleId == 0)
            {
                errors.Add("roleId");
            }

            if (request.CompanyId == 0)
            {
                errors.Add("companyId");
            }

            if (errors.Count == 1)
            {
                return $"{errors[0]} is required!";
            }

            if (errors.Count == 2)
            {
                return $"{errors[0]} and {errors[1]} are required!";
            }

            if (errors.Count > 2)
            {
                var allErrors = "";

                foreach (var e in errors)
                {
                    if (e == errors.Last())
                    {
                        allErrors += $"and {e}";
                        break;
                    }

                    allErrors += $"{e}, ";
                }

                return $"{allErrors} are required!";
            }

            return Consts.Ok;
        }

        public string UpdateEmployeeRequestValidation(UpdateEmployeeRequest request)
        {
            var errors = new List<string>();

            if (request.EmployeeId == 0)
            {
                errors.Add("employeeId");
            }

            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                errors.Add("firstName");
            }

            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                errors.Add("lastName");
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                errors.Add("email");
            }

            if (string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                errors.Add("phoneNumber");
            }

            if (request.RoleId == 0)
            {
                errors.Add("roleId");
            }

            if (request.CompanyId == 0)
            {
                errors.Add("companyId");
            }

            if (errors.Count == 1)
            {
                return $"{errors[0]} is required!";
            }

            if (errors.Count == 2)
            {
                return $"{errors[0]} and {errors[1]} are required!";
            }

            if (errors.Count > 2)
            {
                var allErrors = "";

                foreach (var e in errors)
                {
                    if (e == errors.Last())
                    {
                        allErrors += $"and {e}";
                        break;
                    }

                    allErrors += $"{e}, ";
                }

                return $"{allErrors} are required!";
            }

            return Consts.Ok;
        }
        #endregion

        #region CompanyController
        public string AddCompanyRequestValidation(AddCompanyRequest request)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                errors.Add("name");
            }

            if (errors.Count == 1)
            {
                return $"{errors[0]} is required!";
            }

            if (errors.Count == 2)
            {
                return $"{errors[0]} and {errors[1]} are required!";
            }

            if (errors.Count > 2)
            {
                var allErrors = "";

                foreach (var e in errors)
                {
                    if (e == errors.Last())
                    {
                        allErrors += $"and {e}";
                        break;
                    }

                    allErrors += $"{e}, ";
                }

                return $"{allErrors} are required!";
            }

            return Consts.Ok;
        }

        public string UpdateCompanyRequestValidation(UpdateCompanyRequest request)
        {
            var errors = new List<string>();

            if (request.CompanyId == 0)
            {
                errors.Add("companyId");
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                errors.Add("name");
            }

            if (errors.Count == 1)
            {
                return $"{errors[0]} is required!";
            }

            if (errors.Count == 2)
            {
                return $"{errors[0]} and {errors[1]} are required!";
            }

            if (errors.Count > 2)
            {
                var allErrors = "";

                foreach (var e in errors)
                {
                    if (e == errors.Last())
                    {
                        allErrors += $"and {e}";
                        break;
                    }

                    allErrors += $"{e}, ";
                }

                return $"{allErrors} are required!";
            }

            return Consts.Ok;
        }
        #endregion

        #region RoleController
        public string AddRoleRequestValidation(AddRoleRequest request)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                errors.Add("name");
            }

            if (errors.Count == 1)
            {
                return $"{errors[0]} is required!";
            }

            if (errors.Count == 2)
            {
                return $"{errors[0]} and {errors[1]} are required!";
            }

            if (errors.Count > 2)
            {
                var allErrors = "";

                foreach (var e in errors)
                {
                    if (e == errors.Last())
                    {
                        allErrors += $"and {e}";
                        break;
                    }

                    allErrors += $"{e}, ";
                }

                return $"{allErrors} are required!";
            }

            return Consts.Ok;
        }

        public string UpdateRoleRequestValidation(UpdateRoleRequest request)
        {
            var errors = new List<string>();

            if (request.RoleId == 0)
            {
                errors.Add("roleId");
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                errors.Add("name");
            }

            if (errors.Count == 1)
            {
                return $"{errors[0]} is required!";
            }

            if (errors.Count == 2)
            {
                return $"{errors[0]} and {errors[1]} are required!";
            }

            if (errors.Count > 2)
            {
                var allErrors = "";

                foreach (var e in errors)
                {
                    if (e == errors.Last())
                    {
                        allErrors += $"and {e}";
                        break;
                    }

                    allErrors += $"{e}, ";
                }

                return $"{allErrors} are required!";
            }

            return Consts.Ok;
        }
        #endregion
    }
}
