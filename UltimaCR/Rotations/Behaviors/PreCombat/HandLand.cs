﻿using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class HandLand
    {
        public override async Task<bool> PreCombatBuff()
        {
            return false;
        }
    }
}