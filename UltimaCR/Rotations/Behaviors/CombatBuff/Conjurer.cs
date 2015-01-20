using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Conjurer
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
            if (await ClericStance()) return true;
            return await Ultima.SummonChocobo();
        }

        public override async Task<bool> CombatBuffLvL8()
        {
            return await CombatBuffLvL6();
        }

        public override async Task<bool> CombatBuffLvL10()
        {
            return await CombatBuffLvL6();
        }

        public override async Task<bool> CombatBuffLvL12()
        {
            return await CombatBuffLvL6();
        }

        public override async Task<bool> CombatBuffLvL14()
        {
            return await CombatBuffLvL6();
        }

        public override async Task<bool> CombatBuffLvL15()
        {
            return await CombatBuffLvL6();
        }

        public override async Task<bool> CombatBuffLvL16()
        {
            return await CombatBuffLvL6();
        }

        public override async Task<bool> CombatBuffLvL18()
        {
            return await CombatBuffLvL6();
        }

        public override async Task<bool> CombatBuffLvL20()
        {
            return await CombatBuffLvL6();
        }

        public override async Task<bool> CombatBuffLvL22()
        {
            return await CombatBuffLvL6();
        }

        public override async Task<bool> CombatBuffLvL24()
        {
            return await CombatBuffLvL6();
        }

        public override async Task<bool> CombatBuffLvL26()
        {
            return await CombatBuffLvL6();
        }

        public override async Task<bool> CombatBuffLvL28()
        {
            return await CombatBuffLvL6();
        }

        public override async Task<bool> CombatBuffLvL30()
        {
            return await CombatBuffLvL6();
        }

        public override async Task<bool> CombatBuffLvL32()
        {
            return await CombatBuffLvL6();
        }

        public override async Task<bool> CombatBuffLvL34()
        {
            return await CombatBuffLvL6();
        }

        public override async Task<bool> CombatBuffLvL36()
        {
            return await CombatBuffLvL6();
        }

        public override async Task<bool> CombatBuffLvL38()
        {
            if (await ClericStance()) return true;
            if (await ShroudOfSaints()) return true;
            return await Ultima.SummonChocobo();
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
            return await CombatBuffLvL38();
        }

        public override async Task<bool> CombatBuffLvL48()
        {
            return await CombatBuffLvL38();
        }

        public override async Task<bool> CombatBuffLvL50()
        {
            return await CombatBuffLvL38();
        }
    }
}