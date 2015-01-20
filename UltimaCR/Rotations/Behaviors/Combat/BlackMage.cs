using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class BlackMage : Rotation
    {
        public override async Task<bool> CombatLvL1()
        {
            return await Blizzard();
        }

        public override async Task<bool> CombatLvL2()
        {
            if (await Blizzard()) return true;
            return await Fire();
        }

        public override async Task<bool> CombatLvL4()
        {
            return await CombatLvL2();
        }

        public override async Task<bool> CombatLvL6()
        {
            if (await Thunder()) return true;
            if (await Blizzard()) return true;
            return await Fire();
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
            if (await Scathe()) return true;
            if (await Thunder()) return true;
            if (await Blizzard()) return true;
            return await Fire();
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
            if (await Scathe()) return true;
            if (await ThunderII()) return true;
            if (await Blizzard()) return true;
            return await Fire();
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
            if (await Scathe()) return true;
            if (await ThunderII()) return true;
            if (await Blizzard()) return true;
            if (await FireIII()) return true;
            return await Fire();
        }

        public override async Task<bool> CombatLvL36()
        {
            return await CombatLvL34();
        }

        public override async Task<bool> CombatLvL38()
        {
            if (await Scathe()) return true;
            if (await ThunderII()) return true;
            if (await BlizzardIII()) return true;
            if (await Blizzard()) return true;
            if (await FireIII()) return true;
            return await Fire();
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
            if (await Scathe()) return true;
            if (await ThunderIII()) return true;
            if (await ThunderII()) return true;
            if (await BlizzardIII()) return true;
            if (await Blizzard()) return true;
            if (await FireIII()) return true;
            return await Fire();
        }

        public override async Task<bool> CombatLvL48()
        {
            return await CombatLvL46();
        }

        public override async Task<bool> CombatLvL50()
        {
            if (await Convert()) return true;
            if (await Flare()) return true;
            if (await Swiftcast()) return true;
            if (await Scathe()) return true;
            if (await ThunderIII()) return true;
            if (await ThunderII()) return true;
            if (await BlizzardIII()) return true;
            if (await Blizzard()) return true;
            if (await FireIII()) return true;
            return await Fire();
        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}