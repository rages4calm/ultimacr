﻿using ff14bot;
using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Conjurer
    {
        public override async Task<bool> PreCombatBuff()
        {
            if (!Core.Player.IsMounted)
            {
                if (await Ultima.SummonChocobo()) return true;
                if (await Protect()) return true;
                if (await StoneskinII()) return true;
                return await Stoneskin();
            }
            return false;
        }
    }
}