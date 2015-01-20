using Buddy.Coroutines;
using ff14bot;
using ff14bot.AClasses;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using TreeSharp;
using UltimaCR.Rotations;
using UltimaCR.Settings;
using UltimaCR.Settings.Forms;
using UltimaCR.Spells;

namespace UltimaCR
{
    public class Ultima : CombatRoutine
    {
        public override sealed string Name
        {
            get { return "Ultima"; }
        }

        #region RebornBuddy Overrides

        public override float PullRange
        {
            get { return MyRotation.PullRange; }
        }

        public override sealed void Initialize()
        {
        }

        public override sealed void Pulse()
        {
            CheckClass();
        }

        public override sealed void ShutDown()
        {
        }

        #endregion

        #region Settings

        public static readonly UltimaSettings UltSettings = UltimaSettings.Instance;
        private Form _uForm;

        public override sealed bool WantButton
        {
            get { return true; }
        }

        public override sealed void OnButtonPress()
        {
            if (_uForm == null || _uForm.IsDisposed || _uForm.Disposing)
                _uForm = new UltimaForm();

            _uForm.ShowDialog();
        }

        #endregion

        #region Class Handlers

        private IRotation _myRotation;
        private IRotation MyRotation
        {
            get { return _myRotation ?? (_myRotation = GetRotation(CurrentClass)); }
        }

        private ClassJobType _currentClass;
        private ClassJobType CurrentClass
        {
            get
            {
                if (_currentClass == Core.Me.CurrentJob) return _currentClass;
                _currentClass = Core.Me.CurrentJob;
                _myRotation = GetRotation(_currentClass);
                Logging.Write(Colors.Yellow, @"[Ultima] Loading: " + _currentClass);
                return _currentClass;
            }
        }

        private void CheckClass()
        {
            var _class = CurrentClass;
        }

        public override sealed ClassJobType[] Class
        {
            get
            {
                return new[]
                {
                    ClassJobType.Arcanist, ClassJobType.Summoner, ClassJobType.Scholar,
                    ClassJobType.Archer, ClassJobType.Bard,
                    ClassJobType.Conjurer, ClassJobType.WhiteMage,
                    ClassJobType.Gladiator, ClassJobType.Paladin,
                    ClassJobType.Lancer, ClassJobType.Dragoon,
                    ClassJobType.Marauder, ClassJobType.Warrior,
                    ClassJobType.Pugilist, ClassJobType.Monk,
                    ClassJobType.Thaumaturge, ClassJobType.BlackMage,
                    ClassJobType.Rogue, ClassJobType.Ninja
                };
            }
        }

        private static IRotation GetRotation(ClassJobType job)
        {
            switch (job)
            {
                case ClassJobType.Arcanist:
                    return new Arcanist();
                case ClassJobType.Archer:
                    return new Archer();
                case ClassJobType.Bard:
                    return new Bard();
                case ClassJobType.BlackMage:
                    return new BlackMage();
                case ClassJobType.Conjurer:
                    return new Conjurer();
                case ClassJobType.Dragoon:
                    return new Dragoon();
                case ClassJobType.Gladiator:
                    return new Gladiator();
                case ClassJobType.Lancer:
                    return new Lancer();
                case ClassJobType.Marauder:
                    return new Marauder();
                case ClassJobType.Monk:
                    return new Monk();
                case ClassJobType.Ninja:
                    return new Ninja();
                case ClassJobType.Paladin:
                    return new Paladin();
                case ClassJobType.Pugilist:
                    return new Pugilist();
                case ClassJobType.Rogue:
                    return new Rogue();
                case ClassJobType.Scholar:
                    return new Scholar();
                case ClassJobType.Summoner:
                    return new Summoner();
                case ClassJobType.Thaumaturge:
                    return new Thaumaturge();
                case ClassJobType.Warrior:
                    return new Warrior();
                case ClassJobType.WhiteMage:
                    return new WhiteMage();
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion

        #region Behavior Composites

        /*
        *These are the behaviors that RebornBuddy will use in its Combat Logic
        *The general order that the behaviors are pulsed in are:
        *  1. Rest                 (Not used in the Combat Assist Botbase)
        *  2. Pre-Combat Buff      (Not used in the Combat Assist Botbase)
        *  3. Pull                 (Not used in the Combat Assist Botbase)
        *  4. Heal
        *  5. Combat Buff
        *  6. Combat
        */

        public override Composite RestBehavior
        {
            get { return new ActionRunCoroutine(ctx => GetRest()); }
        }

        public override Composite PreCombatBuffBehavior
        {
            get { return new ActionRunCoroutine(ctx => GetPreCombatBuff()); }
        }

        public override Composite PullBehavior
        {
            get { return new ActionRunCoroutine(ctx => GetPull()); }
        }

        public override Composite HealBehavior
        {
            get { return new ActionRunCoroutine(ctx => GetHeal()); }
        }

        public override Composite CombatBuffBehavior
        {
            get { return new ActionRunCoroutine(ctx => GetCombatBuff()); }
        }

        public override Composite CombatBehavior
        {
            get { return new ActionRunCoroutine(ctx => GetCombat()); }
        }

        #region Not Used Behavior Composites

        /*
        * These behaviors have been put in the CombatRoutine class,
        * but RebornBuddy does not use them in any current Botbase.
        */
        public override Composite DeathBehavior { get; set; }
        public override Composite PullBuffBehavior { get; set; }

        #endregion

        #region Behavior Level Switch Methods

        private async Task<bool> GetRest()
        {
            return await MyRotation.Rest();
        }

        private async Task<bool> GetPreCombatBuff()
        {
            switch ((int) Core.Me.ClassLevel)
            {
                case 50:
                    return await MyRotation.PreCombatBuffLvL50();
                case 49:
                case 48:
                    return await MyRotation.PreCombatBuffLvL48();
                case 47:
                case 46:
                    return await MyRotation.PreCombatBuffLvL46();
                case 45:
                case 44:
                    return await MyRotation.PreCombatBuffLvL44();
                case 43:
                case 42:
                    return await MyRotation.PreCombatBuffLvL42();
                case 41:
                case 40:
                    return await MyRotation.PreCombatBuffLvL40();
                case 39:
                case 38:
                    return await MyRotation.PreCombatBuffLvL38();
                case 37:
                case 36:
                    return await MyRotation.PreCombatBuffLvL36();
                case 35:
                case 34:
                    return await MyRotation.PreCombatBuffLvL34();
                case 33:
                case 32:
                    return await MyRotation.PreCombatBuffLvL32();
                case 31:
                case 30:
                    return await MyRotation.PreCombatBuffLvL30();
                case 29:
                case 28:
                    return await MyRotation.PreCombatBuffLvL28();
                case 27:
                case 26:
                    return await MyRotation.PreCombatBuffLvL26();
                case 25:
                case 24:
                    return await MyRotation.PreCombatBuffLvL24();
                case 23:
                case 22:
                    return await MyRotation.PreCombatBuffLvL22();
                case 21:
                case 20:
                    return await MyRotation.PreCombatBuffLvL20();
                case 19:
                case 18:
                    return await MyRotation.PreCombatBuffLvL18();
                case 17:
                case 16:
                    return await MyRotation.PreCombatBuffLvL16();
                case 15:
                    return await MyRotation.PreCombatBuffLvL15();
                case 14:
                    return await MyRotation.PreCombatBuffLvL14();
                case 13:
                case 12:
                    return await MyRotation.PreCombatBuffLvL12();
                case 11:
                case 10:
                    return await MyRotation.PreCombatBuffLvL10();
                case 9:
                case 8:
                    return await MyRotation.PreCombatBuffLvL8();
                case 7:
                case 6:
                    return await MyRotation.PreCombatBuffLvL6();
                case 5:
                case 4:
                    return await MyRotation.PreCombatBuffLvL4();
                case 3:
                case 2:
                    return await MyRotation.PreCombatBuffLvL2();
                default:
                    return await MyRotation.PreCombatBuffLvL1();
            }
        }

        private async Task<bool> GetPull()
        {
            switch ((int) Core.Me.ClassLevel)
            {
                case 50:
                    return await MyRotation.PullLvL50();
                case 49:
                case 48:
                    return await MyRotation.PullLvL48();
                case 47:
                case 46:
                    return await MyRotation.PullLvL46();
                case 45:
                case 44:
                    return await MyRotation.PullLvL44();
                case 43:
                case 42:
                    return await MyRotation.PullLvL42();
                case 41:
                case 40:
                    return await MyRotation.PullLvL40();
                case 39:
                case 38:
                    return await MyRotation.PullLvL38();
                case 37:
                case 36:
                    return await MyRotation.PullLvL36();
                case 35:
                case 34:
                    return await MyRotation.PullLvL34();
                case 33:
                case 32:
                    return await MyRotation.PullLvL32();
                case 31:
                case 30:
                    return await MyRotation.PullLvL30();
                case 29:
                case 28:
                    return await MyRotation.PullLvL28();
                case 27:
                case 26:
                    return await MyRotation.PullLvL26();
                case 25:
                case 24:
                    return await MyRotation.PullLvL24();
                case 23:
                case 22:
                    return await MyRotation.PullLvL22();
                case 21:
                case 20:
                    return await MyRotation.PullLvL20();
                case 19:
                case 18:
                    return await MyRotation.PullLvL18();
                case 17:
                case 16:
                    return await MyRotation.PullLvL16();
                case 15:
                    return await MyRotation.PullLvL15();
                case 14:
                    return await MyRotation.PullLvL14();
                case 13:
                case 12:
                    return await MyRotation.PullLvL12();
                case 11:
                case 10:
                    return await MyRotation.PullLvL10();
                case 9:
                case 8:
                    return await MyRotation.PullLvL8();
                case 7:
                case 6:
                    return await MyRotation.PullLvL6();
                case 5:
                case 4:
                    return await MyRotation.PullLvL4();
                case 3:
                case 2:
                    return await MyRotation.PullLvL2();
                default:
                    return await MyRotation.PullLvL1();
            }
        }

        private async Task<bool> GetHeal()
        {
            switch ((int) Core.Me.ClassLevel)
            {
                case 50:
                    return await MyRotation.HealLvL50();
                case 49:
                case 48:
                    return await MyRotation.HealLvL48();
                case 47:
                case 46:
                    return await MyRotation.HealLvL46();
                case 45:
                case 44:
                    return await MyRotation.HealLvL44();
                case 43:
                case 42:
                    return await MyRotation.HealLvL42();
                case 41:
                case 40:
                    return await MyRotation.HealLvL40();
                case 39:
                case 38:
                    return await MyRotation.HealLvL38();
                case 37:
                case 36:
                    return await MyRotation.HealLvL36();
                case 35:
                case 34:
                    return await MyRotation.HealLvL34();
                case 33:
                case 32:
                    return await MyRotation.HealLvL32();
                case 31:
                case 30:
                    return await MyRotation.HealLvL30();
                case 29:
                case 28:
                    return await MyRotation.HealLvL28();
                case 27:
                case 26:
                    return await MyRotation.HealLvL26();
                case 25:
                case 24:
                    return await MyRotation.HealLvL24();
                case 23:
                case 22:
                    return await MyRotation.HealLvL22();
                case 21:
                case 20:
                    return await MyRotation.HealLvL20();
                case 19:
                case 18:
                    return await MyRotation.HealLvL18();
                case 17:
                case 16:
                    return await MyRotation.HealLvL16();
                case 15:
                    return await MyRotation.HealLvL15();
                case 14:
                    return await MyRotation.HealLvL14();
                case 13:
                case 12:
                    return await MyRotation.HealLvL12();
                case 11:
                case 10:
                    return await MyRotation.HealLvL10();
                case 9:
                case 8:
                    return await MyRotation.HealLvL8();
                case 7:
                case 6:
                    return await MyRotation.HealLvL6();
                case 5:
                case 4:
                    return await MyRotation.HealLvL4();
                case 3:
                case 2:
                    return await MyRotation.HealLvL2();
                default:
                    return await MyRotation.HealLvL1();
            }
        }

        private async Task<bool> GetCombatBuff()
        {
            switch ((int) Core.Me.ClassLevel)
            {
                case 50:
                    return await MyRotation.CombatBuffLvL50();
                case 49:
                case 48:
                    return await MyRotation.CombatBuffLvL48();
                case 47:
                case 46:
                    return await MyRotation.CombatBuffLvL46();
                case 45:
                case 44:
                    return await MyRotation.CombatBuffLvL44();
                case 43:
                case 42:
                    return await MyRotation.CombatBuffLvL42();
                case 41:
                case 40:
                    return await MyRotation.CombatBuffLvL40();
                case 39:
                case 38:
                    return await MyRotation.CombatBuffLvL38();
                case 37:
                case 36:
                    return await MyRotation.CombatBuffLvL36();
                case 35:
                case 34:
                    return await MyRotation.CombatBuffLvL34();
                case 33:
                case 32:
                    return await MyRotation.CombatBuffLvL32();
                case 31:
                case 30:
                    return await MyRotation.CombatBuffLvL30();
                case 29:
                case 28:
                    return await MyRotation.CombatBuffLvL28();
                case 27:
                case 26:
                    return await MyRotation.CombatBuffLvL26();
                case 25:
                case 24:
                    return await MyRotation.CombatBuffLvL24();
                case 23:
                case 22:
                    return await MyRotation.CombatBuffLvL22();
                case 21:
                case 20:
                    return await MyRotation.CombatBuffLvL20();
                case 19:
                case 18:
                    return await MyRotation.CombatBuffLvL18();
                case 17:
                case 16:
                    return await MyRotation.CombatBuffLvL16();
                case 15:
                    return await MyRotation.CombatBuffLvL15();
                case 14:
                    return await MyRotation.CombatBuffLvL14();
                case 13:
                case 12:
                    return await MyRotation.CombatBuffLvL12();
                case 11:
                case 10:
                    return await MyRotation.CombatBuffLvL10();
                case 9:
                case 8:
                    return await MyRotation.CombatBuffLvL8();
                case 7:
                case 6:
                    return await MyRotation.CombatBuffLvL6();
                case 5:
                case 4:
                    return await MyRotation.CombatBuffLvL4();
                case 3:
                case 2:
                    return await MyRotation.CombatBuffLvL2();
                default:
                    return await MyRotation.CombatBuffLvL1();
            }
        }

        private async Task<bool> GetCombat()
        {
            switch ((int) Core.Me.ClassLevel)
            {
                case 50:
                    return await MyRotation.CombatLvL50();
                case 49:
                case 48:
                    return await MyRotation.CombatLvL48();
                case 47:
                case 46:
                    return await MyRotation.CombatLvL46();
                case 45:
                case 44:
                    return await MyRotation.CombatLvL44();
                case 43:
                case 42:
                    return await MyRotation.CombatLvL42();
                case 41:
                case 40:
                    return await MyRotation.CombatLvL40();
                case 39:
                case 38:
                    return await MyRotation.CombatLvL38();
                case 37:
                case 36:
                    return await MyRotation.CombatLvL36();
                case 35:
                case 34:
                    return await MyRotation.CombatLvL34();
                case 33:
                case 32:
                    return await MyRotation.CombatLvL32();
                case 31:
                case 30:
                    return await MyRotation.CombatLvL30();
                case 29:
                case 28:
                    return await MyRotation.CombatLvL28();
                case 27:
                case 26:
                    return await MyRotation.CombatLvL26();
                case 25:
                case 24:
                    return await MyRotation.CombatLvL24();
                case 23:
                case 22:
                    return await MyRotation.CombatLvL22();
                case 21:
                case 20:
                    return await MyRotation.CombatLvL20();
                case 19:
                case 18:
                    return await MyRotation.CombatLvL18();
                case 17:
                case 16:
                    return await MyRotation.CombatLvL16();
                case 15:
                    return await MyRotation.CombatLvL15();
                case 14:
                    return await MyRotation.CombatLvL14();
                case 13:
                case 12:
                    return await MyRotation.CombatLvL12();
                case 11:
                case 10:
                    return await MyRotation.CombatLvL10();
                case 9:
                case 8:
                    return await MyRotation.CombatLvL8();
                case 7:
                case 6:
                    return await MyRotation.CombatLvL6();
                case 5:
                case 4:
                    return await MyRotation.CombatLvL4();
                case 3:
                case 2:
                    return await MyRotation.CombatLvL2();
                default:
                    return await MyRotation.CombatLvL1();
            }
        }

        #endregion

        #endregion

        #region Summon Chocobo

        public static async Task<bool> SummonChocobo()
        {
            if (BotManager.Current.IsAutonomous &&
                !PartyManager.IsInParty &&
                !MovementManager.IsMoving &&
                !Chocobo.Summoned &&
                Chocobo.CanSummon &&
                UltSettings.SummonChocobo)
            {
                Chocobo.Summon();
                await Coroutine.Wait(1000, () => Chocobo.Summoned);
                if (!Chocobo.Summoned)
                {
                    return await SummonChocobo();
                }
                if (Chocobo.Summoned)
                {
                    if (UltSettings.ChocoboFreeStance &&
                        Chocobo.Stance != CompanionStance.Free)
                    {
                        Chocobo.FreeStance();
                        await Coroutine.Wait(1000, () => Chocobo.Stance == CompanionStance.Free);
                        return true;
                    }

                    if (UltSettings.ChocoboDefenderStance &&
                        Chocobo.Stance != CompanionStance.Defender)
                    {
                        Chocobo.DefenderStance();
                        await Coroutine.Wait(1000, () => Chocobo.Stance == CompanionStance.Defender);
                        return true;
                    }

                    if (UltSettings.ChocoboAttackerStance &&
                        Chocobo.Stance != CompanionStance.Attacker)
                    {
                        Chocobo.AttackerStance();
                        await Coroutine.Wait(1000, () => Chocobo.Stance == CompanionStance.Attacker);
                        return true;
                    }

                    if (UltSettings.ChocoboHealerStance &&
                        Chocobo.Stance != CompanionStance.Healer)
                    {
                        Chocobo.HealerStance();
                        await Coroutine.Wait(1000, () => Chocobo.Stance == CompanionStance.Healer);
                        return true;
                    }
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Ultima LastSpell

        private static Spell _lastSpell;
        public static Spell LastSpell
        {
            get { return _lastSpell ?? (_lastSpell = new Spell()); }
            set { _lastSpell = value; }
        }

        #endregion
    }
}