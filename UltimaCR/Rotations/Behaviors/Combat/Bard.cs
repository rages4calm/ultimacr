using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Bard : Rotation
    {
        public override async Task<bool> CombatLvL1()
        {
            return await HeavyShot();
        }

        public override async Task<bool> CombatLvL2()
        {
            if (await StraightShot()) return true;
            return await HeavyShot();
        }

        public override async Task<bool> CombatLvL4()
        {
            return await CombatLvL2();
        }

        public override async Task<bool> CombatLvL6()
        {
            if (await StraightShot()) return true;
            if (await VenomousBite()) return true;
            return await HeavyShot();
        }

        public override async Task<bool> CombatLvL8()
        {
            return await CombatLvL6();
        }

        public override async Task<bool> CombatLvL10()
        {
            return await CombatLvL6();
        }

        public override async Task<bool> CombatLvL12()
        {
            return await CombatLvL6();
        }

        public override async Task<bool> CombatLvL14()
        {
            return await CombatLvL6();
        }

        public override async Task<bool> CombatLvL15()
        {
            return await CombatLvL6();
        }

        public override async Task<bool> CombatLvL16()
        {
            return await CombatLvL6();
        }

        public override async Task<bool> CombatLvL18()
        {
            return await CombatLvL6();
        }

        public override async Task<bool> CombatLvL20()
        {
            return await CombatLvL6();
        }

        public override async Task<bool> CombatLvL22()
        {
            return await CombatLvL6();
        }

        public override async Task<bool> CombatLvL24()
        {
            return await CombatLvL6();
        }

        public override async Task<bool> CombatLvL26()
        {
            return await CombatLvL6();
        }

        public override async Task<bool> CombatLvL28()
        {
            return await CombatLvL6();
        }

        public override async Task<bool> CombatLvL30()
        {
            if (await StraightShot()) return true;
            if (await Windbite()) return true;
            if (await VenomousBite()) return true;
            return await HeavyShot();
        }

        public override async Task<bool> CombatLvL32()
        {
            return await CombatLvL30();
        }

        public override async Task<bool> CombatLvL34()
        {
            return await CombatLvL30();
        }

        public override async Task<bool> CombatLvL36()
        {
            return await CombatLvL30();
        }

        public override async Task<bool> CombatLvL38()
        {
            return await CombatLvL30();
        }

        public override async Task<bool> CombatLvL40()
        {
            return await CombatLvL30();
        }

        public override async Task<bool> CombatLvL42()
        {
            return await CombatLvL30();
        }

        public override async Task<bool> CombatLvL44()
        {
            return await CombatLvL30();
        }

        public override async Task<bool> CombatLvL46()
        {
            if (await StraightShot()) return true;
            if (await Windbite()) return true;
            if (await VenomousBite()) return true;
            if (await FlamingArrow()) return true;
            return await HeavyShot();
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