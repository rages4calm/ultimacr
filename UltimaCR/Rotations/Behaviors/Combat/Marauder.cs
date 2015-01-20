using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Marauder : Rotation
    {
        public override async Task<bool> CombatLvL1()
        {
            return await HeavySwing();
        }

        public override async Task<bool> CombatLvL2()
        {
            return await CombatLvL1();
        }

        public override async Task<bool> CombatLvL4()
        {
            if (await SkullSunder()) return true;
            return await HeavySwing();
        }

        public override async Task<bool> CombatLvL6()
        {
            if (await SkullSunder()) return true;
            if (await Fracture()) return true;
            return await HeavySwing();
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
            if (await Maim()) return true;
            if (await SkullSunder()) return true;
            if (await Fracture()) return true;
            return await HeavySwing();
        }

        public override async Task<bool> CombatLvL20()
        {
            return await CombatLvL18();
        }

        public override async Task<bool> CombatLvL22()
        {
            return await CombatLvL18();
        }

        public override async Task<bool> CombatLvL24()
        {
            return await CombatLvL18();
        }

        public override async Task<bool> CombatLvL26()
        {
            return await CombatLvL18();
        }

        public override async Task<bool> CombatLvL28()
        {
            return await CombatLvL18();
        }

        public override async Task<bool> CombatLvL30()
        {
            if (await Maim()) return true;
            if (await ButchersBlock()) return true;
            if (await SkullSunder()) return true;
            if (await Fracture()) return true;
            return await HeavySwing();
        }

        public override async Task<bool> CombatLvL32()
        {
            return await CombatLvL18();
        }

        public override async Task<bool> CombatLvL34()
        {
            return await CombatLvL18();
        }

        public override async Task<bool> CombatLvL36()
        {
            return await CombatLvL18();
        }

        public override async Task<bool> CombatLvL38()
        {
            if (await StormsPath()) return true;
            if (await Maim()) return true;
            if (await ButchersBlock()) return true;
            if (await SkullSunder()) return true;
            if (await Fracture()) return true;
            return await HeavySwing();
        }

        public override async Task<bool> CombatLvL40()
        {
            return await CombatLvL38();
        }

        public override async Task<bool> CombatLvL42()
        {
            return await CombatLvL38();
        }

        public override async Task<bool> CombatLvL44()
        {
            return await CombatLvL38();
        }

        public override async Task<bool> CombatLvL46()
        {
            return await CombatLvL38();
        }

        public override async Task<bool> CombatLvL48()
        {
            return await CombatLvL38();
        }

        public override async Task<bool> CombatLvL50()
        {
            //if (await StormsEye()) return true;
            if (await StormsPath()) return true;
            if (await Maim()) return true;
            if (await ButchersBlock()) return true;
            if (await SkullSunder()) return true;
            if (await Fracture()) return true;
            return await HeavySwing();
        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}