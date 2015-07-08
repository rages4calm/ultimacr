using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class WhiteMage
    {
        public override async Task<bool> CombatBuff()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await PresenceOfMind()) return true;
            if (await DivineSeal()) return true;
            return await ShroudOfSaints();
        }
    }
}