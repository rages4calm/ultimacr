using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Paladin
    {
        public override async Task<bool> PullLvL1()
        {
            return await CombatLvL1();
        }

        public override async Task<bool> PullLvL2()
        {
            return await CombatLvL2();
        }

        public override async Task<bool> PullLvL4()
        {
            return await CombatLvL4();
        }

        public override async Task<bool> PullLvL6()
        {
            return await CombatLvL6();
        }

        public override async Task<bool> PullLvL8()
        {
            return await CombatLvL8();
        }

        public override async Task<bool> PullLvL10()
        {
            return await CombatLvL10();
        }

        public override async Task<bool> PullLvL12()
        {
            return await CombatLvL12();
        }

        public override async Task<bool> PullLvL14()
        {
            return await CombatLvL14();
        }

        public override async Task<bool> PullLvL15()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL15();
        }

        public override async Task<bool> PullLvL16()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL16();
        }

        public override async Task<bool> PullLvL18()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL18();
        }

        public override async Task<bool> PullLvL20()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL20();
        }

        public override async Task<bool> PullLvL22()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL22();
        }

        public override async Task<bool> PullLvL24()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL24();
        }

        public override async Task<bool> PullLvL26()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL26();
        }

        public override async Task<bool> PullLvL28()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL28();
        }

        public override async Task<bool> PullLvL30()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL30();
        }

        public override async Task<bool> PullLvL32()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL32();
        }

        public override async Task<bool> PullLvL34()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL34();
        }

        public override async Task<bool> PullLvL36()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL36();
        }

        public override async Task<bool> PullLvL38()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL38();
        }

        public override async Task<bool> PullLvL40()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL40();
        }

        public override async Task<bool> PullLvL42()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL42();
        }

        public override async Task<bool> PullLvL44()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL44();
        }

        public override async Task<bool> PullLvL46()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL46();
        }

        public override async Task<bool> PullLvL48()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL48();
        }

        public override async Task<bool> PullLvL50()
        {
            if (await ShieldLob()) return true;
            return await CombatLvL50();
        }
    }
}