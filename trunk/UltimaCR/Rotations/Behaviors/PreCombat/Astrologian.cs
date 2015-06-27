using ff14bot;
using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Astrologian
    {
        public override async Task<bool> PreCombatBuff()
        {
            if (!Core.Player.IsMounted)
            {
                if (await Ultima.SummonChocobo()) return true;
                if (await DiurnalSect()) return true;
                if (await Protect()) return true;
                return await Stoneskin();
            }
            return false;
        }
    }
}