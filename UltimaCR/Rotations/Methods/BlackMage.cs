using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class BlackMage
    {
        private BlackMageSpells _mySpells;

        private BlackMageSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new BlackMageSpells()); }
        }

        public override float PullRange
        {
            get { return 25.0f; }
        }

        #region Class Spells

        private async Task<bool> Blizzard()
        {
            if (!UmbralAura &&
                LowMP)
            {
                return await MySpells.Blizzard.Cast();
            }
            if (UmbralAura &&
                Core.Player.CurrentManaPercent <= 90)
            {
                if (Core.Player.ClassLevel < MySpells.BlizzardIII.Level ||
                    Ultima.LastSpell.Name != MySpells.Blizzard.Name &&
                    Ultima.LastSpell.Name != MySpells.ThunderII.Name &&
                    Ultima.LastSpell.Name != MySpells.Scathe.Name)
                {
                    return await MySpells.Blizzard.Cast();
                }
                return false;
            }
            return false;
        }

        private async Task<bool> Fire()
        {
            if (AstralAura ||
                Core.Player.ClassLevel < MySpells.FireIII.Level)
            {
                return await MySpells.Fire.Cast();
            }
            return false;
        }

        private async Task<bool> Transpose()
        {
            if (!Core.Player.InCombat &&
                AstralAura &&
                LowMP ||
                Core.Player.HasAura("Firestarter") &&
                UmbralAura &&
                Core.Player.CurrentManaPercent == 100)
            {
                return await MySpells.Transpose.Cast();
            }
            return false;
        }

        private async Task<bool> Thunder()
        {
            if (UmbralAura &&
                !Core.Player.CurrentTarget.HasAura("Thunder", true, 10000) &&
                Core.Player.CurrentManaPercent <= 90)
            {
                return await MySpells.Thunder.Cast();
            }
            return false;
        }

        private async Task<bool> Surecast()
        {
            return await MySpells.Surecast.Cast();
        }

        private async Task<bool> Sleep()
        {
            return await MySpells.Sleep.Cast();
        }

        private async Task<bool> BlizzardII()
        {
            return await MySpells.BlizzardII.Cast();
        }

        private async Task<bool> Scathe()
        {
            if (MovementManager.IsMoving)
            {
                return await MySpells.Scathe.Cast();
            }
            if (UmbralAura &&
                Core.Player.CurrentManaPercent < 100)
            {
                if (Ultima.LastSpell.Name == MySpells.Blizzard.Name ||
                    Ultima.LastSpell.Name == MySpells.ThunderII.Name)
                {
                    return await MySpells.Scathe.Cast();
                }
                return false;
            }
            return false;
        }

        private async Task<bool> FireII()
        {
            return await MySpells.FireII.Cast();
        }

        private async Task<bool> ThunderII()
        {
            if (Ultima.LastSpell.Name != MySpells.Scathe.Name &&
                Ultima.LastSpell.Name != MySpells.Blizzard.Name &&
                Ultima.LastSpell.Name != MySpells.ThunderIII.Name)
            {
                if (Core.Player.ClassLevel < MySpells.ThunderIII.Level &&
                    !AstralAura &&
                    !UmbralAura ||
                    UmbralAura &&
                    !Core.Player.CurrentTarget.HasAura("Thunder", true, 17000) &&
                    Core.Player.CurrentManaPercent <= 90 &&
                    !Core.Player.HasAura("Thundercloud"))
                {
                    return await MySpells.ThunderII.Cast();
                }
                return false;
            }
            return false;
        }

        private async Task<bool> Swiftcast()
        {
            if (AstralAura &&
                Actionmanager.CanCast(MySpells.Convert.Name, Core.Player) &&
                LowMP ||
                AstralAura &&
                !Actionmanager.CanCast(MySpells.Convert.Name, Core.Player) &&
                Core.Player.CurrentManaPercent >= 60)
            {
                return await MySpells.Swiftcast.Cast();
            }
            return false;
        }

        private async Task<bool> Manaward()
        {
            return await MySpells.Manaward.Cast();
        }

        private async Task<bool> FireIII()
        {
            if (!AstralAura &&
                !UmbralAura ||
                UmbralAura &&
                Core.Player.CurrentManaPercent == 100)
            {
                return await MySpells.FireIII.Cast();
            }
            return false;
        }

        private async Task<bool> BlizzardIII()
        {
            if (!UmbralAura &&
                LowMP)
            {
                return await MySpells.BlizzardIII.Cast();
            }
            return false;
        }

        private async Task<bool> Lethargy()
        {
            return await MySpells.Lethargy.Cast();
        }

        private async Task<bool> ThunderIII()
        {
            if (Ultima.LastSpell.Name != MySpells.ThunderIII.Name &&
                Ultima.LastSpell.Name != MySpells.ThunderII.Name)
            {
                if (!AstralAura &&
                    !UmbralAura &&
                    !Core.Player.CurrentTarget.HasAura("Thunder"))
                {
                    return await MySpells.ThunderIII.Cast();
                }
                return false;
            }
            return false;
        }

        private async Task<bool> AetherialManipulation()
        {
            return await MySpells.AetherialManipulation.Cast();
        }

        #endregion

        #region Cross Class Spells

        #region Arcanist

        private async Task<bool> Ruin()
        {
            if (Ultima.UltSettings.BlackMageRuin)
            {
                return await MySpells.CrossClass.Ruin.Cast();
            }
            return false;
        }

        private async Task<bool> Physick()
        {
            if (Ultima.UltSettings.BlackMagePhysick)
            {
                return await MySpells.CrossClass.Physick.Cast();
            }
            return false;
        }

        private async Task<bool> Virus()
        {
            if (Ultima.UltSettings.BlackMageVirus)
            {
                return await MySpells.CrossClass.Virus.Cast();
            }
            return false;
        }

        private async Task<bool> EyeForAnEye()
        {
            if (Ultima.UltSettings.BlackMageEyeForAnEye)
            {
                return await MySpells.CrossClass.EyeForAnEye.Cast();
            }
            return false;
        }

        #endregion

        #region Archer

        private async Task<bool> RagingStrikes()
        {
            if (Ultima.UltSettings.BlackMageRagingStrikes &&
                AstralAura &&
                Core.Player.CurrentManaPercent >= 70)
            {
                return await MySpells.CrossClass.RagingStrikes.Cast();
            }
            return false;
        }

        private async Task<bool> HawksEye()
        {
            if (Ultima.UltSettings.BlackMageHawksEye)
            {
                return await MySpells.CrossClass.HawksEye.Cast();
            }
            return false;
        }

        private async Task<bool> QuellingStrikes()
        {
            if (Ultima.UltSettings.BlackMageQuellingStrikes)
            {
                return await MySpells.CrossClass.QuellingStrikes.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region Job Spells

        private async Task<bool> Convert()
        {
            if (AstralAura &&
                Ultima.LastSpell.Name == MySpells.Flare.Name &&
                LowMP)
            {
                return await MySpells.Convert.Cast();
            }
            return false;
        }

        private async Task<bool> Freeze()
        {
            return await MySpells.Freeze.Cast();
        }

        private async Task<bool> Apocatastasis()
        {
            return await MySpells.Apocatastasis.Cast();
        }

        private async Task<bool> Manawall()
        {
            return await MySpells.Manawall.Cast();
        }

        private async Task<bool> Flare()
        {
            if (AstralAura &&
                Ultima.LastSpell.Name == MySpells.Swiftcast.Name &&
                LowMP)
            {
                return await MySpells.Flare.Cast();
            }
            return false;
        }

        #endregion

        #region Custom Spells

        private static bool UmbralAura
        {
            get
            {
                return Core.Player.HasAura("Umbral Ice") ||
                       Core.Player.HasAura("Umbral Ice II") ||
                       Core.Player.HasAura("Umbral Ice III");
            }
        }

        private static bool AstralAura
        {
            get
            {
                return Core.Player.HasAura("Astral Fire") ||
                       Core.Player.HasAura("Astral Fire II") ||
                       Core.Player.HasAura("Astral Fire III");
            }
        }

        private static bool LowMP
        {
            get { return Core.Player.CurrentManaPercent <= 26; }
        }

        private async Task<bool> Thundercloud()
        {
            if (Core.Player.HasAura("Thundercloud") &&
                !UmbralAura)
                if (Core.Player.ClassLevel >= MySpells.ThunderIII.Level &&
                    Ultima.LastSpell.Name != MySpells.Swiftcast.Name &&
                    Ultima.LastSpell.Name != MySpells.Flare.Name)
                {
                    return await MySpells.ThunderIII.Cast();
                }
                else
                {
                    return await MySpells.ThunderII.Cast();
                }
            return false;
        }

        private async Task<bool> Firestarter()
        {
            if (Core.Player.HasAura("Firestarter") &&
                !UmbralAura &&
                Ultima.LastSpell.Name != MySpells.Swiftcast.Name &&
                Ultima.LastSpell.Name != MySpells.Flare.Name)
            {
                return await MySpells.FireIII.Cast();
            }
            return false;
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

        private async Task<bool> NightWing()
        {
            return await MySpells.PvP.NightWing.Cast();
        }

        private async Task<bool> PhantomDart()
        {
            return await MySpells.PvP.PhantomDart.Cast();
        }

        private async Task<bool> Purify()
        {
            return await MySpells.PvP.Purify.Cast();
        }
        #endregion
    }
}