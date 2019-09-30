using System.Collections.Generic;
using TestBack.Models;
using TestBack.Models.Rules;

namespace TestBack.BL.Services.Abstraction
{
    interface IRuleService
    {
        IEnumerable<DataModel> GetValidRules(IEnumerable<DataModel> data);
        IEnumerable<EffectModel> GetEffects();
    }
}
