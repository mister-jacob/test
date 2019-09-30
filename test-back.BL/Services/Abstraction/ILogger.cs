using System.Collections.Generic;
using System.Threading.Tasks;
using TestBack.Models;

namespace TestBack.BL.Services.Abstraction
{
    public interface ILogger
    {
        Task Log(string message);

        Task Log(Result result);
    }
}
