using System.Threading.Tasks;
using ff14bot;

namespace UltimaCR.Rotations
{
    public sealed partial class Lancer
    {
        public override async Task<bool> PreCombatBuff()
        {
            if (!Core.Player.IsMounted)
            {
                return await Ultima.SummonChocobo();
            }
            return false;
        }
    }
}