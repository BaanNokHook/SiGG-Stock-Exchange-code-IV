using System.Collections.Generic;
using System.Threading.Tasks;
using SiGGTransactionFinancial.Common.HttpModels.Authorization;

namespace SiGGTransactionFinancial.Client.Interfaces
{
    public interface IBodyGuardAuthorizationApiService
    {

        Task<GetRolesResponse> GetRoles();

        Task<CanResponse> Can(string id,
                              List<string> roles,
                              Dictionary<string, string> claims,
                              bool canAll);

        Task<ManageRoleResponse> AssignRole(string emailAddress,
                                            string role);

        Task<ManageRoleResponse> RevokeRole(string emailAddress,
                                            string role);

    }
}