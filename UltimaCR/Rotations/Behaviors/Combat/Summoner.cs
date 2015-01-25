using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Summoner : Rotation
    {
        public override async Task<bool> CombatLvL1()
        {
            return await Ruin();
        }

        public override async Task<bool> CombatLvL2()
        {
            if (await Bio()) return true;
            return await Ruin();
        }

        public override async Task<bool> CombatLvL4()
        {
            if (await RagingStrikes()) return true;
            if (await Bio()) return true;
            return await Ruin();
        }

        public override async Task<bool> CombatLvL6()
        {
            if (await RagingStrikes()) return true;
            if (await Bio()) return true;
            if (await Aetherflow()) return true;
            return await Ruin();
        }

        public override async Task<bool> CombatLvL8()
        {
            if (await RagingStrikes()) return true;
            if (await Bio()) return true;
            if (await Aetherflow()) return true;
            if (await EnergyDrain()) return true;
            return await Ruin();
        }

        public override async Task<bool> CombatLvL10()
        {
            if (await RagingStrikes()) return true;
            if (await Miasma()) return true;
            if (await Bio()) return true;
            if (await Aetherflow()) return true;
            if (await EnergyDrain()) return true;
            return await Ruin();
        }

        public override async Task<bool> CombatLvL12()
        {
            return await CombatLvL10();
        }

        public override async Task<bool> CombatLvL14()
        {
            return await CombatLvL10();
        }

        public override async Task<bool> CombatLvL15()
        {
            return await CombatLvL10();
        }

        public override async Task<bool> CombatLvL16()
        {
            return await CombatLvL10();
        }

        public override async Task<bool> CombatLvL18()
        {
            return await CombatLvL10();
        }

        public override async Task<bool> CombatLvL20()
        {
            return await CombatLvL10();
        }

        public override async Task<bool> CombatLvL22()
        {
            return await CombatLvL10();
        }

        public override async Task<bool> CombatLvL24()
        {
            return await CombatLvL10();
        }

        public override async Task<bool> CombatLvL26()
        {
            if (await RagingStrikes()) return true;
            if (await BioII()) return true;
            if (await Miasma()) return true;
            if (await Bio()) return true;
            if (await Aetherflow()) return true;
            if (await EnergyDrain()) return true;
            return await Ruin();
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
            if (await RagingStrikes()) return true;
            if (await BioII()) return true;
            if (await Miasma()) return true;
            if (await Bio()) return true;
            if (await Aetherflow()) return true;
            if (await Fester()) return true;
            if (await EnergyDrain()) return true;
            return await Ruin();
        }

        public override async Task<bool> CombatLvL36()
        {
            return await CombatLvL34();
        }

        public override async Task<bool> CombatLvL38()
        {
            if (await RagingStrikes()) return true;
            if (await BioII()) return true;
            if (await Miasma()) return true;
            if (await Bio()) return true;
            if (await Aetherflow()) return true;
            if (await EnergyDrain()) return true;
            if (await Fester()) return true;
            if (await RuinII()) return true;
            return await Ruin();
        }

        public override async Task<bool> CombatLvL40()
        {
            return await CombatLvL38();
        }

        public override async Task<bool> CombatLvL42()
        {
            if (await RagingStrikes()) return true;
            if (await BioII()) return true;
            if (await Miasma()) return true;
            if (await Bio()) return true;
            if (await Aetherflow()) return true;
            if (await EnergyDrain()) return true;
            if (await Fester()) return true;
            if (await Rouse()) return true;
            if (await RuinII()) return true;
            return await Ruin();
        }

        public override async Task<bool> CombatLvL44()
        {
            if (await RagingStrikes()) return true;
            if (await BioII()) return true;
            if (await Miasma()) return true;
            if (await Bio()) return true;
            if (await Aetherflow()) return true;
            if (await EnergyDrain()) return true;
            if (await Fester()) return true;
            if (await Rouse()) return true;
            if (await Spur()) return true;
            if (await RuinII()) return true;
            return await Ruin();
        }

        public override async Task<bool> CombatLvL46()
        {
            return await CombatLvL44();
        }

        public override async Task<bool> CombatLvL48()
        {
            return await CombatLvL44();
        }

        public override async Task<bool> CombatLvL50()
        {
            if (await RagingStrikes()) return true;
            if (await BioII()) return true;
            if (await Miasma()) return true;
            if (await Bio()) return true;
            if (await Aetherflow()) return true;
            if (await EnergyDrain()) return true;
            if (await Fester()) return true;
            if (await ShadowFlare()) return true;
            if (await Contagion()) return true;
            if (await Rouse()) return true;
            if (await Spur()) return true;
            if (await Enkindle()) return true;
            if (await AerialSlash()) return true;
            if (await RuinII()) return true;
            return await Ruin();
        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}