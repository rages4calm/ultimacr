using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Monk
    {
        private MonkSpells _mySpells;

        private MonkSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new MonkSpells()); }
        }

        public override float PullRange
        {
            get { return 3.0f; }
        }

        #region Class Spells

        private async Task<bool> Bootshine()
        {
            return await MySpells.Bootshine.Cast();
        }

        private async Task<bool> TrueStrike()
        {
            return await MySpells.TrueStrike.Cast();
        }

        private async Task<bool> Featherfoot()
        {
            return await MySpells.Featherfoot.Cast();
        }

        private async Task<bool> SnapPunch()
        {
            if (!Core.Player.HasAura(MySpells.PerfectBalance.Name) ||
                Core.Player.HasAura(MySpells.PerfectBalance.Name) &&
                 !Core.Player.HasAura("Greased Lightning III"))
            {
                return await MySpells.SnapPunch.Cast();
            }
            return false;
        }

        private async Task<bool> SecondWind()
        {
            return await MySpells.SecondWind.Cast();
        }


        private async Task<bool> Haymaker()
        {
            return await MySpells.Haymaker.Cast();
        }

        private async Task<bool> InternalRelease()
        {
            return await MySpells.InternalRelease.Cast();
        }

        private async Task<bool> TouchOfDeath()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.TouchOfDeath.Name, true, 4000))
            {
                if (NoGreasedLightning ||
                    HasGreasedLightning)
                {
                    return await MySpells.TouchOfDeath.Cast();
                }
                return false;
            }
            return false;
        }

        private async Task<bool> TwinSnakes()
        {
            if (!Core.Player.HasAura(MySpells.TwinSnakes.Name, true, 5000) ||
                !Core.Player.HasAura(MySpells.PerfectBalance.Name) &&
                Core.Player.CurrentTarget.IsFlanking)
            {
                return await MySpells.TwinSnakes.Cast();
            }
            return false;
        }

        private async Task<bool> FistsOfEarth()
        {
            if (!Core.Player.HasAura(MySpells.FistsOfEarth.Name))
            {
                return await MySpells.FistsOfEarth.Cast();
            }
            return false;
        }

        private async Task<bool> ArmOfTheDestroyer()
        {
            return await MySpells.ArmOfTheDestroyer.Cast();
        }

        private async Task<bool> Demolish()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Demolish.Name, true, 5000))
            {
                return await MySpells.Demolish.Cast();
            }
            return false;
        }

        private async Task<bool> FistsOfWind()
        {
            return await MySpells.FistsOfWind.Cast();
        }

        private async Task<bool> SteelPeak()
        {
            return await MySpells.SteelPeak.Cast();
        }

        private async Task<bool> Mantra()
        {
            return await MySpells.Mantra.Cast();
        }

        private async Task<bool> HowlingFist()
        {
            return await MySpells.HowlingFist.Cast();
        }

        private async Task<bool> PerfectBalance()
        {
            if (Ultima.UltSettings.MonkPerfectBalance &&
                Actionmanager.CanCast(MySpells.Bootshine.Name, Core.Player.CurrentTarget))
            {
                if (await MySpells.PerfectBalance.Cast())
                {
                    await Coroutine.Wait(5000, () => Core.Player.HasAura(MySpells.PerfectBalance.Name));
                    return true;
                }
                return false;
            }
            return false;
        }

        #endregion

        #region Cross Class Spells

        #region Lancer

        private async Task<bool> Feint()
        {
            if (Ultima.UltSettings.MonkFeint)
            {
                return await MySpells.CrossClass.Feint.Cast();
            }
            return false;
        }

        private async Task<bool> KeenFlurry()
        {
            if (Ultima.UltSettings.MonkKeenFlurry)
            {
                return await MySpells.CrossClass.KeenFlurry.Cast();
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (Ultima.UltSettings.MonkInvigorate &&
                Core.Player.CurrentTP <= 540)
            {
                return await MySpells.CrossClass.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> BloodForBlood()
        {
            if (Ultima.UltSettings.MonkBloodForBlood)
            {
                return await MySpells.CrossClass.BloodForBlood.Cast();
            }
            return false;
        }

        #endregion

        #region Marauder

        private async Task<bool> Foresight()
        {
            if (Ultima.UltSettings.MonkForesight)
            {
                return await MySpells.CrossClass.Foresight.Cast();
            }
            return false;
        }

        private async Task<bool> SkullSunder()
        {
            if (Ultima.UltSettings.MonkSkullSunder)
            {
                return await MySpells.CrossClass.SkullSunder.Cast();
            }
            return false;
        }

        private async Task<bool> Fracture()
        {
            if (Ultima.UltSettings.MonkFracture &&
                !Core.Player.CurrentTarget.HasAura(MySpells.CrossClass.Fracture.Name, true, 4000))
            {
                return await MySpells.CrossClass.Fracture.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            if (Ultima.UltSettings.MonkBloodbath)
            {
                return await MySpells.CrossClass.Bloodbath.Cast();
            }
            return false;
        }

        private async Task<bool> MercyStroke()
        {
            if (Ultima.UltSettings.MonkMercyStroke)
            {
                return await MySpells.CrossClass.MercyStroke.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region Job Spells

        private async Task<bool> Rockbreaker()
        {
            return await MySpells.Rockbreaker.Cast();
        }

        private async Task<bool> ShoulderTackle()
        {
            if (Ultima.UltSettings.MonkShoulderTackle)
            {
                return await MySpells.ShoulderTackle.Cast();
            }
            return false;
        }

        private async Task<bool> FistsOfFire()
        {
            if (!Core.Player.HasAura(MySpells.FistsOfFire.Name))
            {
                return await MySpells.FistsOfFire.Cast();
            }
            return false;
        }

        private async Task<bool> OneIlmPunch()
        {
            return await MySpells.OneIlmPunch.Cast();
        }

        private async Task<bool> DragonKick()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.DragonKick.Name, true, 5000) &&
                !Core.Player.CurrentTarget.HasAura(MySpells.DragonKick.Name, false, 5000) ||
                !Core.Player.HasAura(MySpells.PerfectBalance.Name) &&
                Core.Player.CurrentTarget.IsFlanking)
            {
                if (Core.Player.HasAura("Opo-opo Form") ||
                    Core.Player.HasAura(MySpells.PerfectBalance.Name))
                {
                    return await MySpells.DragonKick.Cast();
                }
                return false;
            }
            return false;
        }

        #endregion

        #region Custom Spells
        private static bool NoGreasedLightning
        {
            get
            {
                return !Core.Player.HasAura("Greased Lightning") &&
                       !Core.Player.HasAura("Greased Lightning II") &&
                       !Core.Player.HasAura("Greased Lightning III");
            }
        }
        private static bool HasGreasedLightning
        {
            get
            {
                return Core.Player.HasAura("Greased Lightning", true, 4000) ||
                       Core.Player.HasAura("Greased Lightning II", true, 4000) ||
                       Core.Player.HasAura("Greased Lightning III", true, 4000);
            }
        }

        #endregion

        #region PvP Spells

        private async Task<bool> WeaponThrow()
        {
            return await MySpells.PvP.WeaponThrow.Cast();
        }

        private async Task<bool> Somersault()
        {
            return await MySpells.PvP.Somersault.Cast();
        }

        private async Task<bool> Purify()
        {
            return await MySpells.PvP.Purify.Cast();
        }

        private async Task<bool> FetterWard()
        {
            return await MySpells.PvP.FetterWard.Cast();
        }

        private async Task<bool> Enliven()
        {
            return await MySpells.PvP.Enliven.Cast();
        }

        private async Task<bool> AxeKick()
        {
            return await MySpells.PvP.AxeKick.Cast();
        }

        #endregion
    }
}