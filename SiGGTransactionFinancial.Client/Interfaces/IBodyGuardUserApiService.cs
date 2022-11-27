using System.Collections.Generic;
using System.Threading.Tasks;
using SiGGTransactionFinancial.Client.Models.Lists;
using SiGGTransactionFinancial.Common.HttpModels.Authentication;
using SiGGTransactionFinancial.Common.Models;

namespace SiGGTransactionFinancial.Client.Interfaces
{
    public interface IBodyGuardUserApiService
    {

        public Task<List<User>> GetUsers();

        public Task<User> GetUser(string id);

        public Task<UserUpdateResponse> UpdateUser(User user);

        public Task<UserDeleteResponse> DeleteUser(string id);

    }
}