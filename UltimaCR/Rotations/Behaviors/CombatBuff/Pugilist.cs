using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Pugilist
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
            return await CombatBuffLvL1();
        }

        public override async Task<bool> CombatBuffLvL6()
        {
            return await CombatBuffLvL1();
        }

        public override async Task<bool> CombatBuffLvL8()
        {
            return await CombatBuffLvL1();
        }

        public override async Task<bool> CombatBuffLvL10()
        {
            if (await Ultima.SummonChocobo()) return true;
            return await Haymaker();
        }

        public override async Task<bool> CombatBuffLvL12()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await InternalRelease()) return true;
            return await Haymaker();
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
            if (await Ultima.SummonChocobo()) return true;
            if (await Invigorate()) return true;
            if (await InternalRelease()) return true;
            return await Haymaker();
        }

        public override async Task<bool> CombatBuffLvL24()
        {
            return await CombatBuffLvL22();
        }

        public override async Task<bool> CombatBuffLvL26()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await Invigorate()) return true;
            if (await InternalRelease()) return true;
            if (await Haymaker()) return true;
            return await MercyStroke();
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
            if (await Ultima.SummonChocobo()) return true;
            if (await Invigorate()) return true;
            if (await InternalRelease()) return true;
            if (await BloodForBlood()) return true;
            if (await Haymaker()) return true;
            return await MercyStroke();
        }

        public override async Task<bool> CombatBuffLvL36()
        {
            return await CombatBuffLvL34();
        }

        public override async Task<bool> CombatBuffLvL38()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await Invigorate()) return true;
            if (await InternalRelease()) return true;
            if (await BloodForBlood()) return true;
            if (await SteelPeak()) return true;
            if (await Haymaker()) return true;
            return await MercyStroke();
        }

        public override async Task<bool> CombatBuffLvL40()
        {
            return await CombatBuffLvL38();
        }

        public override async Task<bool> CombatBuffLvL42()
        {
            return await CombatBuffLvL38();
        }

        public override async Task<bool> CombatBuffLvL44()
        {
            return await CombatBuffLvL38();
        }

        public override async Task<bool> CombatBuffLvL46()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await Invigorate()) return true;
            if (await InternalRelease()) return true;
            if (await BloodForBlood()) return true;
            if (await HowlingFist()) return true;
            if (await SteelPeak()) return true;
            if (await Haymaker()) return true;
            return await MercyStroke();
        }

        public override async Task<bool> CombatBuffLvL48()
        {
            return await CombatBuffLvL46();
        }

        public override async Task<bool> CombatBuffLvL50()
        {
            return await CombatBuffLvL46();
        }
    }
}