﻿using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Conjurer : Rotation
    {
        public override async Task<bool> Combat()
        {
            if (await FluidAura()) return true;
            if (await AeroII()) return true;
            if (await Aero()) return true;
            if (await StoneII()) return true;
            return await Stone();
        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}