﻿using ff14bot;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class WhiteMage
    {
        private WhiteMageSpells _mySpells;

        private WhiteMageSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new WhiteMageSpells()); }
        }

        #region Class Spells

        private async Task<bool> Stone()
        {
            return await MySpells.Stone.Cast();
        }

        private async Task<bool> Cure()
        {
            if (Ultima.UltSettings.WhiteMageCure &&
                Core.Player.CurrentHealthPercent < 70)
            {
                return await MySpells.Cure.Cast();
            }
            return false;
        }

        private async Task<bool> Aero()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Aero.Name, true, 4000))
            {
                return await MySpells.Aero.Cast();
            }
            return false;
        }

        private async Task<bool> ClericStance()
        {
            return await MySpells.ClericStance.Cast();
        }

        private async Task<bool> Protect()
        {
            if (!Core.Player.HasAura(MySpells.Protect.Name))
            {
                return await MySpells.Protect.Cast();
            }
            return false;
        }

        private async Task<bool> Medica()
        {
            return await MySpells.Medica.Cast();
        }

        private async Task<bool> Raise()
        {
            return await MySpells.Raise.Cast();
        }

        private async Task<bool> FluidAura()
        {
            if (Core.Player.TargetDistance(5, false))
            {
                return await MySpells.FluidAura.Cast();
            }
            return false;
        }

        private async Task<bool> Esuna()
        {
            return await MySpells.Esuna.Cast();
        }

        private async Task<bool> StoneII()
        {
            return await MySpells.StoneII.Cast();
        }

        private async Task<bool> Repose()
        {
            return await MySpells.Repose.Cast();
        }

        private async Task<bool> CureII()
        {
            if (Ultima.UltSettings.WhiteMageCureII &&
                Core.Player.CurrentHealthPercent < 50)
            {
                return await MySpells.CureII.Cast();
            }
            return false;
        }

        private async Task<bool> Stoneskin()
        {
            if (!Core.Player.HasAura(MySpells.Stoneskin.Name))
            {
                return await MySpells.Stoneskin.Cast();
            }
            return false;
        }

        private async Task<bool> ShroudOfSaints()
        {
            if (Core.Player.CurrentManaPercent <= 50)
            {
                return await MySpells.ShroudOfSaints.Cast();
            }
            return false;
        }

        private async Task<bool> CureIII()
        {
            return await MySpells.CureIII.Cast();
        }

        private async Task<bool> AeroII()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.AeroII.Name, true, 4000))
            {
                return await MySpells.AeroII.Cast();
            }
            return false;
        }

        private async Task<bool> MedicaII()
        {
            return await MySpells.MedicaII.Cast();
        }

        #endregion

        #region Cross Class Spells

        #region Arcanist

        private async Task<bool> Ruin()
        {
            if (Ultima.UltSettings.WhiteMageRuin)
            {
                return await MySpells.CrossClass.Ruin.Cast();
            }
            return false;
        }

        private async Task<bool> Physick()
        {
            if (Ultima.UltSettings.WhiteMagePhysick)
            {
                return await MySpells.CrossClass.Physick.Cast();
            }
            return false;
        }

        private async Task<bool> Virus()
        {
            if (Ultima.UltSettings.WhiteMageVirus)
            {
                return await MySpells.CrossClass.Virus.Cast();
            }
            return false;
        }

        private async Task<bool> EyeForAnEye()
        {
            if (Ultima.UltSettings.WhiteMageEyeForAnEye)
            {
                return await MySpells.CrossClass.EyeForAnEye.Cast();
            }
            return false;
        }

        #endregion

        #region Thaumaturge

        private async Task<bool> BlizzardII()
        {
            if (Ultima.UltSettings.WhiteMageBlizzardII)
            {
                return await MySpells.CrossClass.BlizzardII.Cast();
            }
            return false;
        }

        private async Task<bool> Surecast()
        {
            if (Ultima.UltSettings.WhiteMageSurecast)
            {
                return await MySpells.CrossClass.Surecast.Cast();
            }
            return false;
        }

        private async Task<bool> Swiftcast()
        {
            if (Ultima.UltSettings.WhiteMageSwiftcast)
            {
                return await MySpells.CrossClass.Swiftcast.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region Job Spells

        private async Task<bool> PresenceOfMind()
        {
            return await MySpells.PresenceOfMind.Cast();
        }

        private async Task<bool> Regen()
        {
            if (Ultima.UltSettings.WhiteMageRegen &&
                Core.Player.CurrentHealthPercent < 90 &&
                !Core.Player.HasAura(MySpells.Regen.Name))
            {
                return await MySpells.Regen.Cast();
            }
            return false;
        }

        private async Task<bool> DivineSeal()
        {
            return await MySpells.DivineSeal.Cast();
        }

        private async Task<bool> Holy()
        {
            return await MySpells.Holy.Cast();
        }

        private async Task<bool> Benediction()
        {
            return await MySpells.Benediction.Cast();
        }

        #endregion

        #region PvP Spells

        private async Task<bool> AethericBurst()
        {
            return await MySpells.PvP.AethericBurst.Cast();
        }

        private async Task<bool> Attunement()
        {
            return await MySpells.PvP.Attunement.Cast();
        }

        private async Task<bool> DivineBreath()
        {
            return await MySpells.PvP.DivineBreath.Cast();
        }

        private async Task<bool> Equanimity()
        {
            return await MySpells.PvP.Equanimity.Cast();
        }

        private async Task<bool> Focalization()
        {
            return await MySpells.PvP.Focalization.Cast();
        }

        private async Task<bool> ManaDraw()
        {
            return await MySpells.PvP.ManaDraw.Cast();
        }

        private async Task<bool> Purify()
        {
            return await MySpells.PvP.Purify.Cast();
        }

        private async Task<bool> SacredPrism()
        {
            return await MySpells.PvP.SacredPrism.Cast();
        }

        #endregion
    }
}