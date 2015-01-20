using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Lancer : Rotation
    {
        public override async Task<bool> CombatLvL1()
        {
            return await TrueThrust();
        }

        public override async Task<bool> CombatLvL2()
        {
            return await CombatLvL1();
        }

        public override async Task<bool> CombatLvL4()
        {
            if (await VorpalThrust()) return true;
            return await TrueThrust();
        }

        public override async Task<bool> CombatLvL6()
        {
            return await CombatLvL4();
        }

        public override async Task<bool> CombatLvL8()
        {
            return await CombatLvL4();
        }

        public override async Task<bool> CombatLvL10()
        {
            return await CombatLvL4();
        }

        public override async Task<bool> CombatLvL12()
        {
            if (await VorpalThrust()) return true;
            if (await HeavyThrust()) return true;
            return await TrueThrust();
        }

        public override async Task<bool> CombatLvL14()
        {
            return await CombatLvL12();
        }

        public override async Task<bool> CombatLvL15()
        {
            return await CombatLvL12();
        }

        public override async Task<bool> CombatLvL16()
        {
            return await CombatLvL12();
        }

        public override async Task<bool> CombatLvL18()
        {
            if (await LifeSurge()) return true;
            if (await VorpalThrust()) return true;
            if (await HeavyThrust()) return true;
            return await TrueThrust();
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
            if (await FullThrust()) return true;
            if (await VorpalThrust()) return true;
            if (await HeavyThrust()) return true;
            return await TrueThrust();
        }

        public override async Task<bool> CombatLvL28()
        {
            return await CombatLvL26();
        }

        public override async Task<bool> CombatLvL30()
        {
            if (await FullThrust()) return true;
            if (await VorpalThrust()) return true;
            if (await HeavyThrust()) return true;
            if (await Phlebotomize()) return true;
            return await TrueThrust();
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
            if (await FullThrust()) return true;
            if (await VorpalThrust()) return true;
            if (await Disembowel()) return true;
            if (await HeavyThrust()) return true;
            if (await Phlebotomize()) return true;
            if (await ImpulseDrive()) return true;
            return await TrueThrust();
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
            if (await FullThrust()) return true;
            if (await VorpalThrust()) return true;
            if (await ChaosThrust()) return true;
            if (await Disembowel()) return true;
            if (await HeavyThrust()) return true;
            if (await Phlebotomize()) return true;
            if (await ImpulseDrive()) return true;
            return await TrueThrust();
        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}