using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Summoner
    {
        private SummonerSpells _mySpells;

        private SummonerSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new SummonerSpells()); }
        }

        public override float PullRange
        {
            get { return 25.0f; }
        }

        #region Class Spells

        private async Task<bool> Ruin()
        {
            return await MySpells.Ruin.Cast();
        }

        private async Task<bool> Bio()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Bio.Name, true, 4000))
            {
                return await MySpells.Bio.Cast();
            }
            return false;
        }

        private async Task<bool> Summon()
        {
            if (Core.Player.Pet == null &&
                Ultima.UltSettings.SummonerSummonPet &&
                Ultima.UltSettings.SummonerGaruda)
            {
                return await MySpells.Summon.Cast();
            }
            return false;
        }

        private async Task<bool> Physick()
        {
            if (Ultima.UltSettings.SummonerPhysick &&
                Core.Player.CurrentHealthPercent < 70)
            {
                return await MySpells.Physick.Cast();
            }
            return false;
        }

        private async Task<bool> Aetherflow()
        {
            if (!Core.Player.HasAura(MySpells.Aetherflow.Name))
            {
                return await MySpells.Aetherflow.Cast();
            }
            return false;
        }

        private async Task<bool> EnergyDrain()
        {
            if (Core.Player.CurrentHealthPercent <= 90 ||
                Core.Player.CurrentManaPercent <= 90)
            {
                if (Core.Player.ClassLevel < MySpells.Fester.Level)
                {
                    return await MySpells.EnergyDrain.Cast();
                }
                return false;
            }
            return false;
        }

        private async Task<bool> Miasma()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Miasma.Name, true, 5000))
            {
                return await MySpells.Miasma.Cast();
            }
            return false;
        }

        private async Task<bool> Virus()
        {
            return await MySpells.Virus.Cast();
        }

        private async Task<bool> SummonII()
        {
            if (Core.Player.Pet == null &&
                Ultima.UltSettings.SummonerSummonPet &&
                Ultima.UltSettings.SummonerTitan)
            {
                return await MySpells.SummonII.Cast();
            }
            return false;
        }

        private async Task<bool> Sustain()
        {
            if (Core.Player.Pet != null &&
                Core.Player.Pet.CurrentHealthPercent < 70 &&
                !Core.Player.Pet.HasAura(MySpells.Sustain.Name))
            {
                return await MySpells.Sustain.Cast();
            }
            return false;
        }

        private async Task<bool> Resurrection()
        {
            return await MySpells.Resurrection.Cast();
        }

        private async Task<bool> BioII()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.BioII.Name, true, 5000))
            {
                return await MySpells.BioII.Cast();
            }
            return false;
        }

        private async Task<bool> Bane()
        {
            return await MySpells.Bane.Cast();
        }

        private async Task<bool> EyeForAnEye()
        {
            return await MySpells.EyeForAnEye.Cast();
        }

        private async Task<bool> RuinII()
        {
            if (MovementManager.IsMoving ||
                Actionmanager.CanCast(MySpells.Aetherflow.Name, Core.Player) &&
                !Core.Player.HasAura(MySpells.Aetherflow.Name) ||
                Actionmanager.CanCast(MySpells.Fester.Name, Core.Player) ||
                Actionmanager.CanCast(MySpells.Rouse.Name, Core.Player) ||
                Actionmanager.CanCast(MySpells.Spur.Name, Core.Player) ||
                Actionmanager.CanCast(MySpells.Enkindle.Name, Core.Player))
            {
                return await MySpells.RuinII.Cast();
            }
            return false;
        }

        private async Task<bool> Rouse()
        {
            return await MySpells.Rouse.Cast();
        }

        private async Task<bool> MiasmaII()
        {
            return await MySpells.MiasmaII.Cast();
        }

        private async Task<bool> ShadowFlare()
        {
            if (!Core.Player.HasAura(MySpells.ShadowFlare.Name, true, 4000) &&
                Core.Player.HasTarget &&
                Core.Player.CurrentTarget.HasAura(MySpells.BioII.Name) &&
                Core.Player.CurrentTarget.HasAura(MySpells.Miasma.Name) &&
                Core.Player.CurrentTarget.HasAura(MySpells.Bio.Name))
            {
                if (Actionmanager.CanCast(MySpells.RuinII.Name, Core.Player) &&
                    Actionmanager.CanCast(MySpells.CrossClass.Swiftcast.Name, Core.Player))
                {
                    if (await MySpells.RuinII.Cast())
                    {
                        await Coroutine.Wait(5000, () => Actionmanager.CanCast(MySpells.CrossClass.Swiftcast.Name, Core.Player));
                    }
                }
                if (Actionmanager.CanCast(MySpells.CrossClass.Swiftcast.Name, Core.Player))
                {
                    if (await MySpells.CrossClass.Swiftcast.Cast())
                    {
                        await Coroutine.Wait(5000, () => Actionmanager.CanCast(MySpells.ShadowFlare.Name, Core.Player.CurrentTarget) &&
                                                         Core.Player.HasAura(MySpells.CrossClass.Swiftcast.Name));
                    }
                }
                return await MySpells.ShadowFlare.Cast();
            }
            return false;
        }

        #endregion

        #region Cross Class Spells

        #region Archer

        private async Task<bool> RagingStrikes()
        {
            if (Ultima.UltSettings.SummonerRagingStrikes)
            {
                if (!Core.Player.CurrentTarget.HasAura(MySpells.BioII.Name, true, 6000) ||
                    !Core.Player.CurrentTarget.HasAura(MySpells.Miasma.Name, true, 6000) ||
                    !Core.Player.CurrentTarget.HasAura(MySpells.Bio.Name, true, 5000))
                {
                    return await MySpells.CrossClass.RagingStrikes.Cast();
                }
                return false;
            }
            return false;
        }

        private async Task<bool> HawksEye()
        {
            if (Ultima.UltSettings.SummonerHawksEye)
            {
                return await MySpells.CrossClass.HawksEye.Cast();
            }
            return false;
        }

        private async Task<bool> QuellingStrikes()
        {
            if (Ultima.UltSettings.SummonerQuellingStrikes)
            {
                return await MySpells.CrossClass.QuellingStrikes.Cast();
            }
            return false;
        }

        #endregion

        #region Thaumaturge

        private async Task<bool> Surecast()
        {
            if (Ultima.UltSettings.SummonerSurecast)
            {
                return await MySpells.CrossClass.Surecast.Cast();
            }
            return false;
        }

        private async Task<bool> BlizzardII()
        {
            if (Ultima.UltSettings.SummonerBlizzardII)
            {
                return await MySpells.CrossClass.BlizzardII.Cast();
            }
            return false;
        }

        private async Task<bool> Swiftcast()
        {
            if (Ultima.UltSettings.SummonerSwiftcast)
            {
                return await MySpells.CrossClass.Swiftcast.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region Job Spells

        private async Task<bool> Shockwave()
        {
            return await MySpells.Shockwave.Cast();
        }

        private async Task<bool> MountainBuster()
        {
            return await MySpells.MountainBuster.Cast();
        }

        private async Task<bool> AerialSlash()
        {
            if (Core.Player.Pet != null &&
                Core.Player.Pet.Name == "Garuda-Egi")
            {
                return await MySpells.AerialSlash.Cast();
            }
            return false;
        }

        private async Task<bool> EarthenWard()
        {
            return await MySpells.EarthenWard.Cast();
        }

        private async Task<bool> SummonIII()
        {
            if (Core.Player.Pet == null &&
                Ultima.UltSettings.SummonerSummonPet &&
                Ultima.UltSettings.SummonerIfrit)
            {
                return await MySpells.SummonIII.Cast();
            }
            return false;
        }

        private async Task<bool> CrimsonCyclone()
        {
            return await MySpells.CrimsonCyclone.Cast();
        }

        private async Task<bool> RadiantShield()
        {
            return await MySpells.RadiantShield.Cast();
        }

        private async Task<bool> Contagion()
        {
            if (Core.Player.Pet != null &&
                Core.Player.Pet.Name == "Garuda-Egi" &&
                Core.Player.CurrentTarget.HasAura(MySpells.BioII.Name) &&
                Core.Player.CurrentTarget.HasAura(MySpells.Miasma.Name) &&
                Core.Player.CurrentTarget.HasAura(MySpells.Bio.Name))
            {
                return await MySpells.Contagion.Cast();
            }
            return false;
        }

        private async Task<bool> Landslide()
        {
            return await MySpells.Landslide.Cast();
        }

        private async Task<bool> FlamingCrush()
        {
            return await MySpells.FlamingCrush.Cast();
        }

        private async Task<bool> Fester()
        {
            if (Core.Player.CurrentTarget.HasAura(MySpells.BioII.Name) &&
                Core.Player.CurrentTarget.HasAura(MySpells.Miasma.Name) &&
                Core.Player.CurrentTarget.HasAura(MySpells.Bio.Name))
            {
                if (DataManager.GetSpellData(MySpells.Ruin.ID).Cooldown.TotalMilliseconds >= 1500 ||
                    Core.Player.ClassLevel < MySpells.RuinII.Level)
                {
                    return await MySpells.Fester.Cast();
                }
                return false;
            }
            return false;
        }

        private async Task<bool> TriDisaster()
        {
            return await MySpells.TriDisaster.Cast();
        }

        private async Task<bool> Spur()
        {
            return await MySpells.Spur.Cast();
        }

        private async Task<bool> Enkindle()
        {
            return await MySpells.Enkindle.Cast();
        }

        #endregion

        #region PvP Spells

        private async Task<bool> AethericBurst()
        {
            return await MySpells.PvP.AethericBurst.Cast();
        }

        private async Task<bool> Equanimity()
        {
            return await MySpells.PvP.Equanimity.Cast();
        }

        private async Task<bool> ManaDraw()
        {
            return await MySpells.PvP.ManaDraw.Cast();
        }

        private async Task<bool> MistyVeil()
        {
            return await MySpells.PvP.MistyVeil.Cast();
        }

        private async Task<bool> Purify()
        {
            return await MySpells.PvP.Purify.Cast();
        }

        private async Task<bool> Wither()
        {
            return await MySpells.PvP.Wither.Cast();
        }

        #endregion
    }
}