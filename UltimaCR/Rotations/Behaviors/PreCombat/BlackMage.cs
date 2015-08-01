﻿using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class BlackMage
    {
        public override async Task<bool> PreCombatBuff()
        {
            if (await Ultima.SummonChocobo()) return true;
            return await Transpose();
        }
    }
}