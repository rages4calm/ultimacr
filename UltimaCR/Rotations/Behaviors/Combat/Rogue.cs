using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Rogue : Rotation
    {
        public override async Task<bool> CombatLvL1()
        {
            return await SpinningEdge();
        }

        public override async Task<bool> CombatLvL2()
        {
            return await CombatLvL1();
        }

        public override async Task<bool> CombatLvL4()
        {
            if (await GustSlash()) return true;
            return await SpinningEdge();
        }

        public override async Task<bool> CombatLvL6()
        {
            return await CombatLvL4();
        }

        public override async Task<bool> CombatLvL8()
        {
            if (await GustSlash()) return true;
            if (await Mutilate()) return true;
            return await SpinningEdge();
        }

        public override async Task<bool> CombatLvL10()
        {
            return await CombatLvL8();
        }

        public override async Task<bool> CombatLvL12()
        {
            if (await InternalRelease()) return true;
            if (await GustSlash()) return true;
            if (await Mutilate()) return true;
            if (await Assassinate()) return true;
            return await SpinningEdge();
        }

        public override async Task<bool> CombatLvL14()
        {
            return await CombatLvL12();
        }

        public override async Task<bool> CombatLvL15()
        {
            if (await InternalRelease()) return true;
            if (await GustSlash()) return true;
            if (await Mutilate()) return true;
            if (await Mug()) return true;
            if (await Assassinate()) return true;
            return await SpinningEdge();
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
            if (await Invigorate()) return true;
            if (await InternalRelease()) return true;
            if (await GustSlash()) return true;
            if (await Mutilate()) return true;
            if (await Mug()) return true;
            if (await Assassinate()) return true;
            return await SpinningEdge();
        }

        public override async Task<bool> CombatLvL24()
        {
            return await CombatLvL22();
        }

        public override async Task<bool> CombatLvL26()
        {
            if (await Invigorate()) return true;
            if (await InternalRelease()) return true;
            if (await AeolianEdge()) return true;
            if (await GustSlash()) return true;
            if (await Mutilate()) return true;
            if (await Mug()) return true;
            if (await Assassinate()) return true;
            return await SpinningEdge();
        }

        public override async Task<bool> CombatLvL28()
        {
            return await CombatLvL26();
        }

        public override async Task<bool> CombatLvL30()
        {
            return await CombatLvL26();
        }

        public override async Task<bool> CombatLvL32()
        {
            return await CombatLvL26();
        }

        public override async Task<bool> CombatLvL34()
        {
            if (await Invigorate()) return true;
            if (await InternalRelease()) return true;
            if (await BloodForBlood()) return true;
            if (await AeolianEdge()) return true;
            if (await GustSlash()) return true;
            if (await Mutilate()) return true;
            if (await Jugulate()) return true;
            if (await Mug()) return true;
            if (await Assassinate()) return true;
            return await SpinningEdge();
        }

        public override async Task<bool> CombatLvL36()
        {
            return await CombatLvL34();
        }

        public override async Task<bool> CombatLvL38()
        {
            if (await Invigorate()) return true;
            if (await InternalRelease()) return true;
            if (await BloodForBlood()) return true;
            if (await DancingEdge()) return true;
            if (await AeolianEdge()) return true;
            if (await GustSlash()) return true;
            if (await Mutilate()) return true;
            if (await Jugulate()) return true;
            if (await Mug()) return true;
            if (await Assassinate()) return true;
            return await SpinningEdge();
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
            if (await Invigorate()) return true;
            if (await InternalRelease()) return true;
            if (await BloodForBlood()) return true;
            if (await DancingEdge()) return true;
            if (await AeolianEdge()) return true;
            if (await ShadowFang()) return true;
            if (await GustSlash()) return true;
            if (await Mutilate()) return true;
            if (await Jugulate()) return true;
            if (await Mug()) return true;
            if (await Assassinate()) return true;
            return await SpinningEdge();
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