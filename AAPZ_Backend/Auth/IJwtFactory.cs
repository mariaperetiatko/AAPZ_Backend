using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;

namespace AAPZ_Backend.Auth
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id, IList<string> Roles);
    }
}
