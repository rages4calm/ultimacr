using ff14bot;
using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class WhiteMage
    {
        public override async Task<bool> Heal()
        {
            if (await Regen()) return true;
            if (await CureII()) return true;
            return await Cure();
        }
    }
}