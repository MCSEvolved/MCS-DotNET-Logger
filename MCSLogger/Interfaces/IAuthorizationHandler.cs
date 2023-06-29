using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSLogger.Interfaces
{
    public interface IAuthorizationHandler
    {
        Task<string> GetIdToken();
    }
}
