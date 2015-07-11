﻿using ff14bot;
using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Scholar
    {
        public override async Task<bool> PreCombatBuff()
        {
            if (!Core.Player.IsMounted)
            {
                if (await Ultima.SummonChocobo()) return true;
                if (await SummonII()) return true;
                if (await Summon()) return true;
                if (await Protect()) return true;
                return await Stoneskin();
            }
            return false;
        }
    }
}