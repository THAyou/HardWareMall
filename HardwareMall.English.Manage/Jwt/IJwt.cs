using System.Collections.Generic;

namespace HardwareMall.Manage
{
    public interface IJwt
    {
        string CreateToken(Dictionary<string, string> Claims);

        bool IsToken(string Token, out Dictionary<string, string> Clims);
    }
}
