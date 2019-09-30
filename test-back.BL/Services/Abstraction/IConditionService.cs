using System.Collections.Generic;
using TestBack.Models.Rules;

namespace TestBack.BL.Services.Abstraction
{
    interface IConditionService<in T>
    {
       List<bool> Build<T>(T item, List<ConditionModel> conditions);
    }
}
