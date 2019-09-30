using System.Collections.Generic;
using System.Threading.Tasks;
using TestBack.Models;

namespace TestBack.BL.Services.Abstraction
{
    public interface IWorkerService
    {
        Task<IEnumerable<Result>> RunProcess(IEnumerable<DataModel> data);
    }
}
