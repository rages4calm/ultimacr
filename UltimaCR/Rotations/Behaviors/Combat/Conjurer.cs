using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Conjurer : Rotation
    {
        public override async Task<bool> CombatLvL1()
        {
            return await Stone();
        }

        public override async Task<bool> CombatLvL2()
        {
            return await CombatLvL1();
        }

        public override async Task<bool> CombatLvL4()
        {
            if (await Aero()) return true;
            return await Stone();
        }

        public override async Task<bool> CombatLvL6()
        {
            return await CombatLvL4();
        }

        public override async Task<bool> CombatLvL8()
        {
            return await CombatLvL4();
        }

        public override async Task<bool> CombatLvL10()
        {
            return await CombatLvL4();
        }

        public override async Task<bool> CombatLvL12()
        {
            return await CombatLvL4();
        }

        public override async Task<bool> CombatLvL14()
        {
            return await CombatLvL4();
        }

        public override async Task<bool> CombatLvL15()
        {
            if (await FluidAura()) return true;
            if (await Aero()) return true;
            return await Stone();
        }

        public override async Task<bool> CombatLvL16()
        {
            return await CombatLvL15();
        }

        public override async Task<bool> CombatLvL18()
        {
            return await CombatLvL15();
        }

        public override async Task<bool> CombatLvL20()
        {
            return await CombatLvL15();
        }

        public override async Task<bool> CombatLvL22()
        {
            if (await FluidAura()) return true;
            if (await Aero()) return true;
            return await StoneII();
        }

        public override async Task<bool> CombatLvL24()
        {
            return await CombatLvL22();
        }

        public override async Task<bool> CombatLvL26()
        {
            return await CombatLvL22();
        }

        public override async Task<bool> CombatLvL28()
        {
            return await CombatLvL22();
        }

        public override async Task<bool> CombatLvL30()
        {
            return await CombatLvL22();
        }

        public override async Task<bool> CombatLvL32()
        {
            return await CombatLvL22();
        }

        public override async Task<bool> CombatLvL34()
        {
            return await CombatLvL22();
        }

        public override async Task<bool> CombatLvL36()
        {
            return await CombatLvL22();
        }

        public override async Task<bool> CombatLvL38()
        {
            return await CombatLvL22();
        }

        public override async Task<bool> CombatLvL40()
        {
            return await CombatLvL22();
        }

        public override async Task<bool> CombatLvL42()
        {
            return await CombatLvL22();
        }

        public override async Task<bool> CombatLvL44()
        {
            return await CombatLvL22();
        }

        public override async Task<bool> CombatLvL46()
        {
            if (await FluidAura()) return true;
            if (await AeroII()) return true;
            if (await Aero()) return true;
            return await StoneII();
        }

        public override async Task<bool> CombatLvL48()
        {
            return await CombatLvL46();
        }

        public override async Task<bool> CombatLvL50()
        {
            return await CombatLvL46();
        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}