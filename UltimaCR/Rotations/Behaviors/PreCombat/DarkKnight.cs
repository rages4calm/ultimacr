using ff14bot;
using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class DarkKnight
    {
        public override async Task<bool> PreCombatBuff()
        {
            if (!Core.Player.IsMounted)
            {
                if (await Ultima.SummonChocobo()) return true;
                return await Darkside();
            }
            return false;
        }
    }
}