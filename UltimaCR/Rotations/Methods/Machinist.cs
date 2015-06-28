﻿using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Machinist
    {
        private MachinistSpells _mySpells;

        private MachinistSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new MachinistSpells()); }
        }

        public override float PullRange
        {
            get { return 25.0f; }
        }

        #region Job Spells

        private async Task<bool> SplitShot()
        {
            return await MySpells.SplitShot.Cast();
        }
        private async Task<bool> SlugShot()
        {
            if (Core.Player.HasAura(856))
            {
                return await MySpells.SlugShot.Cast();
            }
            return false;
        }
        private async Task<bool> Reload()
        {
            if (Ultima.LastSpell.Name != MySpells.QuickReload.Name &&
                !Core.Player.HasAura(862) &&
                Core.Player.HasAura(MySpells.HotShot.Name, true, 6000) &&
                Core.Player.CurrentTarget.HasAura(MySpells.LeadShot.Name, true, 6000))
            {
                return await MySpells.Reload.Cast();
            }
            return false;
        }
        private async Task<bool> LeadShot()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.LeadShot.Name, true, 4000))
            {
                return await MySpells.LeadShot.Cast();
            }
            return false;
        }
        private async Task<bool> Heartbreak()
        {
            if (Ultima.UltSettings.MachinistHeartbreak)
            {
                return await MySpells.Heartbreak.Cast();
            }
            return false;
        }
        private async Task<bool> LegGraze()
        {
            return await MySpells.LegGraze.Cast();
        }
        private async Task<bool> Reassemble()
        {
            if (Core.Player.HasAura(862))
            {
                if (Core.Player.HasAura(857) ||
                    !Actionmanager.HasSpell(MySpells.CleanShot.Name) &&
                    Core.Player.HasAura(856))
                {
                    return await MySpells.Reassemble.Cast();
                }
            }
            return false;
        }
        private async Task<bool> Blank()
        {
            if (Ultima.UltSettings.MachinistBlank &&
                Core.Player.TargetDistance(5, false))
            {
                return await MySpells.Blank.Cast();
            }
            return false;
        }
        private async Task<bool> SpreadShot()
        {
            return await MySpells.SpreadShot.Cast();
        }
        private async Task<bool> FootGraze()
        {
            return await MySpells.FootGraze.Cast();
        }
        private async Task<bool> QuickReload()
        {
            if (Ultima.LastSpell.Name != MySpells.Reload.Name &&
                !Core.Player.HasAura(862) &&
                Core.Player.HasAura(MySpells.HotShot.Name, true, 6000) &&
                Core.Player.CurrentTarget.HasAura(MySpells.LeadShot.Name, true, 6000))
            {
                return await MySpells.QuickReload.Cast();
            }
            return false;
        }
        private async Task<bool> HotShot()
        {
            if (!Core.Player.HasAura(MySpells.HotShot.Name, true, 4000))
            {
                return await MySpells.HotShot.Cast();
            }
            return false;
        }
        private async Task<bool> RapidFire()
        {
            if (Core.Player.HasAura(MySpells.CrossClass.HawksEye.Name))
            {
                return await MySpells.RapidFire.Cast();
            }
            return false;
        }
        private async Task<bool> HeadGraze()
        {
            if (Ultima.UltSettings.MachinistHeadGraze)
            {
                return await MySpells.HeadGraze.Cast();
            }
            return false;
        }
        private async Task<bool> CleanShot()
        {
            if (Core.Player.HasAura(857))
            {
                return await MySpells.CleanShot.Cast();
            }
            return false;
        }
        private async Task<bool> Wildfire()
        {
            if (Core.Player.HasAura(MySpells.CrossClass.HawksEye.Name))
            {
                return await MySpells.Wildfire.Cast();
            }
            return false;
        }
        private async Task<bool> RookAutoturret()
        {
            if (Core.Player.Pet == null &&
                Ultima.UltSettings.MachinistSummonTurret)
            {
                if (Ultima.UltSettings.MachinistRook ||
                    !Actionmanager.HasSpell(MySpells.BishopAutoturret.Name))
                {
                    return await MySpells.RookAutoturret.Cast();
                }
            }
            return false;
        }
        private async Task<bool> TurretRetrieval()
        {
            return await MySpells.TurretRetrieval.Cast();
        }
        private async Task<bool> Promotion()
        {
            return await MySpells.Promotion.Cast();
        }
        private async Task<bool> SuppressiveFire()
        {
            return await MySpells.SuppressiveFire.Cast();
        }
        private async Task<bool> GrenadoShot()
        {
            return await MySpells.GrenadoShot.Cast();
        }
        private async Task<bool> BishopAutoturret()
        {
            if (Core.Player.Pet == null &&
                Ultima.UltSettings.MachinistSummonTurret &&
                Ultima.UltSettings.MachinistBishop)
            {
                return await MySpells.BishopAutoturret.Cast();
            }
            return false;
        }
        private async Task<bool> Dismantle()
        {
            return await MySpells.Dismantle.Cast();
        }
        private async Task<bool> GaussBarrel()
        {
            if (Core.Player.HasAura(MySpells.GaussBarrel.Name) &&
                !Actionmanager.CanCast(MySpells.Ricochet.Name, Core.Player.CurrentTarget) &&
                !Actionmanager.CanCast(MySpells.GaussRound.Name, Core.Player.CurrentTarget))
            {
                return await MySpells.GaussBarrel.Cast();
            }
            if (!Core.Player.HasAura(MySpells.GaussBarrel.Name))
            {
                if (DataManager.GetSpellData(2874).Cooldown.TotalMilliseconds == 0 ||
                DataManager.GetSpellData(2890).Cooldown.TotalMilliseconds == 0)
                {
                    return await MySpells.GaussBarrel.Cast();
                }
            }
            return false;
        }
        private async Task<bool> GaussRound()
        {
            return await MySpells.GaussRound.Cast();
        }
        private async Task<bool> RendMind()
        {
            return await MySpells.RendMind.Cast();
        }
        private async Task<bool> Hypercharge()
        {
            if (Ultima.UltSettings.MachinistHypercharge)
            {
                return await MySpells.Hypercharge.Cast();
            }
            return false;
        }
        private async Task<bool> Ricochet()
        {
            return await MySpells.Ricochet.Cast();
        }

        #endregion

        #region Cross Class Spells

        #region Archer

        private async Task<bool> RagingStrikes()
        {
            if (Ultima.UltSettings.MachinistRagingStrikes &&
                Core.Player.HasAura(MySpells.CrossClass.HawksEye.Name))
            {
                return await MySpells.CrossClass.RagingStrikes.Cast();
            }
            return false;
        }

        private async Task<bool> HawksEye()
        {
            if (Ultima.UltSettings.MachinistHawksEye)
            {
                return await MySpells.CrossClass.HawksEye.Cast();
            }
            return false;
        }

        private async Task<bool> QuellingStrikes()
        {
            if (Ultima.UltSettings.MachinistQuellingStrikes)
            {
                return await MySpells.CrossClass.QuellingStrikes.Cast();
            }
            return false;
        }

        #endregion

        #region Lancer

        private async Task<bool> Feint()
        {
            if (Ultima.UltSettings.MachinistFeint)
            {
                return await MySpells.CrossClass.Feint.Cast();
            }
            return false;
        }

        private async Task<bool> KeenFlurry()
        {
            if (Ultima.UltSettings.MachinistKeenFlurry)
            {
                return await MySpells.CrossClass.KeenFlurry.Cast();
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (Ultima.UltSettings.MachinistInvigorate &&
                Core.Player.CurrentTP <= 540)
            {
                return await MySpells.CrossClass.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> BloodForBlood()
        {
            if (Ultima.UltSettings.MachinistBloodForBlood &&
                Core.Player.HasAura(MySpells.CrossClass.HawksEye.Name))
            {
                return await MySpells.CrossClass.BloodForBlood.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region PvP Spells



        #endregion
    }
}