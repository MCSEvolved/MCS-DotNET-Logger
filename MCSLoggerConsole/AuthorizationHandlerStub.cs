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
            return Task.FromResult("eyJhbGciOiJSUzI1NiIsImtpZCI6ImY5N2U3ZWVlY2YwMWM4MDhiZjRhYjkzOTczNDBiZmIyOTgyZTg0NzUiLCJ0eXAiOiJKV1QifQ.eyJyb2xlIjoiaXNTZXJ2aWNlIiwiaXNzIjoiaHR0cHM6Ly9zZWN1cmV0b2tlbi5nb29nbGUuY29tL21jc3luZXJneS01NTg3OCIsImF1ZCI6Im1jc3luZXJneS01NTg3OCIsImF1dGhfdGltZSI6MTY4ODAwMjIxNSwidXNlcl9pZCI6IlRFU1RJTkciLCJzdWIiOiJURVNUSU5HIiwiaWF0IjoxNjg4MDAyMjE1LCJleHAiOjE2ODgwMDU4MTUsImZpcmViYXNlIjp7ImlkZW50aXRpZXMiOnt9LCJzaWduX2luX3Byb3ZpZGVyIjoiY3VzdG9tIn19.CxITM9LS1OQhi4Dxag9w7ro9xdKwJi8aLGothq2VsVIOgk-bKUTaJedX_Tj_lYhBYlCxRf4oqvTT9gGznKbfvv4Ss5U1akEfLUyNI9yTXBezwDl02veqALtsVf_6R43NdbBA6awOsgXVrT1_jnbKMXNJ8WbLB73y-WSNKKr_P6zvqqDE1lEhlyop9MbZQgjOHwB03Lz67U3-rqc25V_StjDdZuLBhJz1mhvUaw4JGMBt73LtNy1SLwxG1LgtBU0NrywjM9askZfy267gJJyCp_2-GJzdss0pldg43QR7MmQ5qL22f9XwA8FkelaTa7XcKy_ji3h1-DuuI6iPhNptCA");
        }
    }
}
