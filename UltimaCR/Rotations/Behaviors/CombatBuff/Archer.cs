using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Archer
    {
        public override async Task<bool> CombatBuffLvL1()
        {
            return await Ultima.SummonChocobo();
        }

        public override async Task<bool> CombatBuffLvL2()
        {
            return await CombatBuffLvL1();
        }

        public override async Task<bool> CombatBuffLvL4()
        {
            if (await RagingStrikes()) return true;
            return await Ultima.SummonChocobo();
        }

        public override async Task<bool> CombatBuffLvL6()
        {
            return await CombatBuffLvL4();
        }

        public override async Task<bool> CombatBuffLvL8()
        {
            if (await RagingStrikes()) return true;
            if (await MiserysEnd()) return true;
            return await Ultima.SummonChocobo();
        }

        public override async Task<bool> CombatBuffLvL10()
        {
            return await CombatBuffLvL8();
        }

        public override async Task<bool> CombatBuffLvL12()
        {
            if (await RagingStrikes()) return true;
            if (await InternalRelease()) return true;
            if (await MiserysEnd()) return true;
            if (await Bloodletter()) return true;
            return await Ultima.SummonChocobo();
        }

        public override async Task<bool> CombatBuffLvL14()
        {
            return await CombatBuffLvL12();
        }

        public override async Task<bool> CombatBuffLvL15()
        {
            return await CombatBuffLvL12();
        }

        public override async Task<bool> CombatBuffLvL16()
        {
            return await CombatBuffLvL12();
        }

        public override async Task<bool> CombatBuffLvL18()
        {
            return await CombatBuffLvL12();
        }

        public override async Task<bool> CombatBuffLvL20()
        {
            return await CombatBuffLvL12();
        }

        public override async Task<bool> CombatBuffLvL22()
        {
            if (await Invigorate()) return true;
            if (await RagingStrikes()) return true;
            if (await InternalRelease()) return true;
            if (await HawksEye()) return true;
            if (await MiserysEnd()) return true;
            if (await Bloodletter()) return true;
            return await Ultima.SummonChocobo();
        }

        public override async Task<bool> CombatBuffLvL24()
        {
            return await CombatBuffLvL22();
        }

        public override async Task<bool> CombatBuffLvL26()
        {
            if (await Invigorate()) return true;
            if (await RagingStrikes()) return true;
            if (await InternalRelease()) return true;
            if (await HawksEye()) return true;
            if (await MiserysEnd()) return true;
            if (await Bloodletter()) return true;
            return await Ultima.SummonChocobo();
        }

        public override async Task<bool> CombatBuffLvL28()
        {
            return await CombatBuffLvL26();
        }

        public override async Task<bool> CombatBuffLvL30()
        {
            return await CombatBuffLvL26();
        }

        public override async Task<bool> CombatBuffLvL32()
        {
            return await CombatBuffLvL26();
        }

        public override async Task<bool> CombatBuffLvL34()
        {
            if (await Invigorate()) return true;
            if (await RagingStrikes()) return true;
            if (await InternalRelease()) return true;
            if (await BloodForBlood()) return true;
            if (await HawksEye()) return true;
            if (await MiserysEnd()) return true;
            if (await Bloodletter()) return true;
            return await Ultima.SummonChocobo();
        }

        public override async Task<bool> CombatBuffLvL36()
        {
            return await CombatBuffLvL34();
        }

        public override async Task<bool> CombatBuffLvL38()
        {
            if (await Invigorate()) return true;
            if (await RagingStrikes()) return true;
            if (await InternalRelease()) return true;
            if (await BloodForBlood()) return true;
            if (await HawksEye()) return true;
            if (await Barrage()) return true;
            if (await MiserysEnd()) return true;
            if (await Bloodletter()) return true;
            return await Ultima.SummonChocobo();
        }

        public override async Task<bool> CombatBuffLvL40()
        {
            return await CombatBuffLvL38();
        }

        public override async Task<bool> CombatBuffLvL42()
        {
            if (await Invigorate()) return true;
            if (await RagingStrikes()) return true;
            if (await InternalRelease()) return true;
            if (await BloodForBlood()) return true;
            if (await HawksEye()) return true;
            if (await Barrage()) return true;
            if (await BluntArrow()) return true;
            if (await MiserysEnd()) return true;
            if (await Bloodletter()) return true;
            return await Ultima.SummonChocobo();
        }

        public override async Task<bool> CombatBuffLvL44()
        {
            return await CombatBuffLvL42();
        }

        public override async Task<bool> CombatBuffLvL46()
        {
            return await CombatBuffLvL42();
        }

        public override async Task<bool> CombatBuffLvL48()
        {
            return await CombatBuffLvL42();
        }

        public override async Task<bool> CombatBuffLvL50()
        {
            return await CombatBuffLvL42();
        }
    }
}