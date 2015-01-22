using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Paladin
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
            if (await Ultima.SummonChocobo()) return true;
            return await FightOrFlight();
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
            if (await Ultima.SummonChocobo()) return true;
            if (await FightOrFlight()) return true;
            return await MercyStroke();
        }

        public override async Task<bool> CombatBuffLvL28()
        {
            return await CombatBuffLvL26();
        }

        public override async Task<bool> CombatBuffLvL30()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await FightOrFlight()) return true;
            if (await ShieldSwipe()) return true;
            return await MercyStroke();
        }

        public override async Task<bool> CombatBuffLvL32()
        {
            return await CombatBuffLvL30();
        }

        public override async Task<bool> CombatBuffLvL34()
        {
            return await CombatBuffLvL30();
        }

        public override async Task<bool> CombatBuffLvL36()
        {
            return await CombatBuffLvL30();
        }

        public override async Task<bool> CombatBuffLvL38()
        {
            return await CombatBuffLvL30();
        }

        public override async Task<bool> CombatBuffLvL40()
        {
            return await CombatBuffLvL30();
        }

        public override async Task<bool> CombatBuffLvL42()
        {
            return await CombatBuffLvL30();
        }

        public override async Task<bool> CombatBuffLvL44()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await FightOrFlight()) return true;
            if (await ShieldSwipe()) return true;
            if (await SpiritsWithin()) return true;
            return await MercyStroke();
        }

        public override async Task<bool> CombatBuffLvL46()
        {
            return await CombatBuffLvL44();
        }

        public override async Task<bool> CombatBuffLvL48()
        {
            return await CombatBuffLvL44();
        }

        public override async Task<bool> CombatBuffLvL50()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await FightOrFlight()) return true;
            if (await ShieldSwipe()) return true;
            if (await CircleOfScorn()) return true;
            if (await SpiritsWithin()) return true;
            return await MercyStroke();
        }
    }
}