using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Conjurer
    {
        private ConjurerSpells _mySpells;

        private ConjurerSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new ConjurerSpells()); }
        }

        public override float PullRange
        {
            get { return 25.0f; }
        }

        #region Class Spells

        private async Task<bool> Stone()
        {
            return await MySpells.Stone.Cast();
        }

        private async Task<bool> Cure()
        {
            if (Ultima.UltSettings.ConjurerCure &&
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
            if (!Core.Player.HasAura(MySpells.ClericStance.Name))
            {
                return await MySpells.ClericStance.Cast();
            }
            return false;
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
            if (Core.Player.Distance(Core.Player.CurrentTarget) <= 5)
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
            if (Core.Player.CurrentHealthPercent < 70)
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
            if (Ultima.UltSettings.ConjurerRuin)
            {
                return await MySpells.CrossClass.Ruin.Cast();
            }
            return false;
        }

        private async Task<bool> Physick()
        {
            if (Ultima.UltSettings.ConjurerPhysick)
            {
                return await MySpells.CrossClass.Physick.Cast();
            }
            return false;
        }

        private async Task<bool> Virus()
        {
            if (Ultima.UltSettings.ConjurerVirus)
            {
                return await MySpells.CrossClass.Virus.Cast();
            }
            return false;
        }

        private async Task<bool> EyeForAnEye()
        {
            if (Ultima.UltSettings.ConjurerEyeForAnEye)
            {
                return await MySpells.CrossClass.EyeForAnEye.Cast();
            }
            return false;
        }

        #endregion

        #region Archer

        private async Task<bool> RagingStrikes()
        {
            if (Ultima.UltSettings.ConjurerRagingStrikes)
            {
                return await MySpells.CrossClass.RagingStrikes.Cast();
            }
            return false;
        }

        private async Task<bool> HawksEye()
        {
            if (Ultima.UltSettings.ConjurerHawksEye)
            {
                return await MySpells.CrossClass.HawksEye.Cast();
            }
            return false;
        }

        private async Task<bool> QuellingStrikes()
        {
            if (Ultima.UltSettings.ConjurerQuellingStrikes)
            {
                return await MySpells.CrossClass.QuellingStrikes.Cast();
            }
            return false;
        }

        #endregion

        #region Gladiator

        private async Task<bool> Flash()
        {
            if (Ultima.UltSettings.ConjurerFlash)
            {
                return await MySpells.CrossClass.Flash.Cast();
            }
            return false;
        }

        private async Task<bool> Convalescence()
        {
            if (Ultima.UltSettings.ConjurerConvalescence)
            {
                return await MySpells.CrossClass.Convalescence.Cast();
            }
            return false;
        }

        private async Task<bool> Provoke()
        {
            if (Ultima.UltSettings.ConjurerProvoke)
            {
                return await MySpells.CrossClass.Provoke.Cast();
            }
            return false;
        }

        private async Task<bool> Awareness()
        {
            if (Ultima.UltSettings.ConjurerAwareness)
            {
                return await MySpells.CrossClass.Awareness.Cast();
            }
            return false;
        }

        #endregion

        #region Lancer

        private async Task<bool> KeenFlurry()
        {
            if (Ultima.UltSettings.ConjurerKeenFlurry)
            {
                return await MySpells.CrossClass.KeenFlurry.Cast();
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (Ultima.UltSettings.ConjurerInvigorate)
            {
                return await MySpells.CrossClass.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> BloodForBlood()
        {
            if (Ultima.UltSettings.ConjurerBloodForBlood)
            {
                return await MySpells.CrossClass.BloodForBlood.Cast();
            }
            return false;
        }

        #endregion

        #region Marauder

        private async Task<bool> Foresight()
        {
            if (Ultima.UltSettings.ConjurerForesight)
            {
                return await MySpells.CrossClass.Foresight.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            if (Ultima.UltSettings.ConjurerBloodbath)
            {
                return await MySpells.CrossClass.Bloodbath.Cast();
            }
            return false;
        }

        private async Task<bool> MercyStroke()
        {
            if (Ultima.UltSettings.ConjurerMercyStroke)
            {
                return await MySpells.CrossClass.MercyStroke.Cast();
            }
            return false;
        }

        #endregion

        #region Pugilist

        private async Task<bool> Featherfoot()
        {
            if (Ultima.UltSettings.ConjurerFeatherfoot)
            {
                return await MySpells.CrossClass.Featherfoot.Cast();
            }
            return false;
        }

        private async Task<bool> SecondWind()
        {
            if (Ultima.UltSettings.ConjurerSecondWind)
            {
                return await MySpells.CrossClass.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> InternalRelease()
        {
            if (Ultima.UltSettings.ConjurerInternalRelease)
            {
                return await MySpells.CrossClass.InternalRelease.Cast();
            }
            return false;
        }

        private async Task<bool> Mantra()
        {
            if (Ultima.UltSettings.ConjurerMantra)
            {
                return await MySpells.CrossClass.Mantra.Cast();
            }
            return false;
        }

        #endregion

        #region Thaumaturge

        private async Task<bool> Surecast()
        {
            if (Ultima.UltSettings.ConjurerSurecast)
            {
                return await MySpells.CrossClass.Surecast.Cast();
            }
            return false;
        }

        private async Task<bool> Swiftcast()
        {
            if (Ultima.UltSettings.ConjurerSwiftcast)
            {
                return await MySpells.CrossClass.Swiftcast.Cast();
            }
            return false;
        }

        #endregion

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