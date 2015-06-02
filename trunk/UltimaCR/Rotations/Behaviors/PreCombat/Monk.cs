﻿using ff14bot;
using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Monk
    {
        public override async Task<bool> PreCombatBuff()
        {
            if (!Core.Player.IsMounted)
            {
                if (await Ultima.SummonChocobo()) return true;
                if (await FistsOfFire()) return true;
                if (await FistsOfWind()) return true;
                return await FistsOfEarth();
            }
            return false;
        }
    }
}