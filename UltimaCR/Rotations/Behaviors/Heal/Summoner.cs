using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Summoner
    {
        public override async Task<bool> HealLvL1()
        {
            return false;
        }

        public override async Task<bool> HealLvL2()
        {
            return false;
        }

        public override async Task<bool> HealLvL4()
        {
            return await Physick();
        }

        public override async Task<bool> HealLvL6()
        {
            return await HealLvL4();
        }

        public override async Task<bool> HealLvL8()
        {
            return await HealLvL4();
        }

        public override async Task<bool> HealLvL10()
        {
            return await HealLvL4();
        }

        public override async Task<bool> HealLvL12()
        {
            return await HealLvL4();
        }

        public override async Task<bool> HealLvL14()
        {
            return await HealLvL4();
        }

        public override async Task<bool> HealLvL15()
        {
            return await HealLvL4();
        }

        public override async Task<bool> HealLvL16()
        {
            return await HealLvL4();
        }

        public override async Task<bool> HealLvL18()
        {
            if (await Sustain()) return true;
            return await Physick();
        }

        public override async Task<bool> HealLvL20()
        {
            return await HealLvL18();
        }

        public override async Task<bool> HealLvL22()
        {
            return await HealLvL18();
        }

        public override async Task<bool> HealLvL24()
        {
            return await HealLvL18();
        }

        public override async Task<bool> HealLvL26()
        {
            return await HealLvL18();
        }

        public override async Task<bool> HealLvL28()
        {
            return await HealLvL18();
        }

        public override async Task<bool> HealLvL30()
        {
            return await HealLvL18();
        }

        public override async Task<bool> HealLvL32()
        {
            return await HealLvL18();
        }

        public override async Task<bool> HealLvL34()
        {
            return await HealLvL18();
        }

        public override async Task<bool> HealLvL36()
        {
            return await HealLvL18();
        }

        public override async Task<bool> HealLvL38()
        {
            return await HealLvL18();
        }

        public override async Task<bool> HealLvL40()
        {
            return await HealLvL18();
        }

        public override async Task<bool> HealLvL42()
        {
            return await HealLvL18();
        }

        public override async Task<bool> HealLvL44()
        {
            return await HealLvL18();
        }

        public override async Task<bool> HealLvL46()
        {
            return await HealLvL18();
        }

        public override async Task<bool> HealLvL48()
        {
            return await HealLvL18();
        }

        public override async Task<bool> HealLvL50()
        {
            return await HealLvL18();
        }
    }
}