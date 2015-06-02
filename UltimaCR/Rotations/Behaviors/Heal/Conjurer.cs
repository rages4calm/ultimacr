using ff14bot;
using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Conjurer
    {
        public override async Task<bool> Heal()
        {
            if (await CureII()) return true;
            return await Cure();
        }
    }
}