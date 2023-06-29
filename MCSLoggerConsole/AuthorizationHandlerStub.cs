using MCSLogger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSLoggerConsole
{
    public class AuthorizationHandlerStub : IAuthorizationHandler
    {
        public Task<string> GetIdToken()
        {
            return Task.FromResult("");
        }
    }
}
