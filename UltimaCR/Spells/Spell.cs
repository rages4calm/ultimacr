using Buddy.Coroutines;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Navigation;
using ff14bot.Objects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media;

namespace UltimaCR.Spells
{
    public class Spell
    {
        public string Name { get; set; }
        public uint ID { get; set; }
        public byte Level { get; set; }
        public GCDType GCDType { private get; set; }
        public SpellType SpellType { private get; set; }
        public CastType CastType { private get; set; }

        private readonly Dictionary<string, DateTime> RecentSpell = new Dictionary<string, DateTime>();

        public async Task<bool> Cast(GameObject target = null)
        {
            #region Target
            if (target == null)
            {
                switch (CastType)
                {
                    case CastType.Location:
                        if (!Core.Player.HasTarget)
                        {
                            return false;
                        }
                        target = Core.Player.CurrentTarget;
                        break;
                    case CastType.Target:
                        if (!Core.Player.HasTarget)
                        {
                            return false;
                        }
                        target = Core.Player.CurrentTarget;
                        break;
                    default:
                        target = Core.Player;
                        break;
                }
            }
            #endregion

            #region Recent Spell Check
            RecentSpell.RemoveAll(t => DateTime.UtcNow > t);

            if (RecentSpell.ContainsKey(target.ObjectId.ToString("X") + "-" + Name))
            {
                return false;
            }
            #endregion

            #region Pet Exception
            if (SpellType == SpellType.Pet)
            {
                if (Core.Player.Pet == null)
                {
                    return false;
                }
                if (Pet.PetMode != PetMode.Obey)
                {
                    await Coroutine.Wait(1000, () => Pet.DoAction("Obey", Core.Player));
                }
                if (!Pet.CanCast(Name, target))
                {
                    return false;
                }
                if (!await Coroutine.Wait(5000, () => Pet.DoAction(Name, target)))
                {
                    return false;
                }
                Ultima.LastSpell = this;
                #region Recent Spell Add
                var key = target.ObjectId.ToString("X") + "-" + Name;
                var val = DateTime.UtcNow + DataManager.GetSpellData(Name).AdjustedCastTime + TimeSpan.FromSeconds(5);
                RecentSpell.Add(key, val);
                #endregion
                Logging.Write(Colors.OrangeRed, @"[Ultima] Ability: " + Name);
                return true;
            }
            #endregion

            #region Ninjutsu Exception
            if (SpellType == SpellType.Ninjutsu)
            {
                if (BotManager.Current.IsAutonomous &&
                    Core.Player.HasTarget)
                {
                    switch (Actionmanager.InSpellInRangeLOS(2247, target))
                    {
                        case SpellRangeCheck.ErrorNotInLineOfSight:
                            Navigator.MoveTo(target.Location);
                            return true;
                        case SpellRangeCheck.ErrorNotInRange:
                            Navigator.MoveTo(target.Location);
                            return true;
                        case SpellRangeCheck.ErrorNotInFront:
                            if (!target.InLineOfSight())
                            {
                                Navigator.MoveTo(target.Location);
                                return true;
                            }
                            target.Face();
                            return true;
                    }
                    if (MovementManager.IsMoving &&
                        target.InLineOfSight() &&
                        Core.Player.Distance(target) <= 15 &&
                        Core.Player.IsFacing(target))
                    {
                        Navigator.PlayerMover.MoveStop();
                    }
                }
                if (!await Coroutine.Wait(1000, () => Actionmanager.DoAction(ID, target)))
                {
                    return false;
                }
                Logging.Write(Colors.OrangeRed, @"[Ultima] Ability: " + Name);
                return true;
            }
            #endregion

            #region Player Movement
            if (BotManager.Current.IsAutonomous &&
                Core.Player.HasTarget)
            {
                switch (Actionmanager.InSpellInRangeLOS(ID, target))
                {
                    case SpellRangeCheck.ErrorNotInLineOfSight:
                        Navigator.MoveTo(target.Location);
                        return false;
                    case SpellRangeCheck.ErrorNotInRange:
                        Navigator.MoveTo(target.Location);
                        return false;
                    case SpellRangeCheck.ErrorNotInFront:
                        if (!target.InLineOfSight())
                        {
                            Navigator.MoveTo(target.Location);
                            return false;
                        }
                        target.Face();
                        return false;
                }
                if (MovementManager.IsMoving &&
                    target.InLineOfSight() &&
                    Core.Player.Distance(target) <= (DataManager.GetSpellData(ID).Range + Core.Player.CombatReach + target.CombatReach) &&
                    Core.Player.IsFacing(target))
                {
                    Navigator.PlayerMover.MoveStop();
                }
            }
            #endregion

            #region CanCast Check
            if (!Actionmanager.CanCast(ID, target))
            {
                return false;
            }

            if (MovementManager.IsMoving &&
                DataManager.GetSpellData(ID).AdjustedCastTime.TotalMilliseconds > 0)
            {
                if (!BotManager.Current.IsAutonomous)
                {
                    return false;
                }
                Navigator.PlayerMover.MoveStop();
            }
            #endregion

            #region Off-GCD Check
            if (GCDType == GCDType.Off)
            {

                if (Core.Player.CurrentJob == ClassJobType.Arcanist ||
                    Core.Player.CurrentJob == ClassJobType.Scholar ||
                    Core.Player.CurrentJob == ClassJobType.Summoner)
                {
                    if (Core.Player.ClassLevel >= 38 &&
                        Core.Player.CurrentManaPercent > 40 &&
                        DataManager.GetSpellData(163).Cooldown.TotalMilliseconds <= 1000)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.Archer ||
                    Core.Player.CurrentJob == ClassJobType.Bard)
                {
                    if (DataManager.GetSpellData(97).Cooldown.TotalMilliseconds <= 1000)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.Conjurer ||
                    Core.Player.CurrentJob == ClassJobType.WhiteMage)
                {
                    if (DataManager.GetSpellData(119).Cooldown.TotalMilliseconds <= 1000)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.Gladiator ||
                    Core.Player.CurrentJob == ClassJobType.Paladin)
                {
                    if (DataManager.GetSpellData(9).Cooldown.TotalMilliseconds <= 1000)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.Lancer ||
                    Core.Player.CurrentJob == ClassJobType.Dragoon)
                {
                    if (DataManager.GetSpellData(75).Cooldown.TotalMilliseconds <= 1000)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.Marauder ||
                    Core.Player.CurrentJob == ClassJobType.Warrior)
                {
                    if (DataManager.GetSpellData(31).Cooldown.TotalMilliseconds <= 1000)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.Pugilist ||
                    Core.Player.CurrentJob == ClassJobType.Monk)
                {
                    if (DataManager.GetSpellData(53).Cooldown.TotalMilliseconds <= 1000)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.Rogue ||
                    Core.Player.CurrentJob == ClassJobType.Ninja)
                {
                    if (DataManager.GetSpellData(2240).Cooldown.TotalMilliseconds <= 1000)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.Thaumaturge ||
                    Core.Player.CurrentJob == ClassJobType.BlackMage)
                {
                    if (DataManager.GetSpellData(142).Cooldown.TotalMilliseconds <= 1000)
                    {
                        return false;
                    }
                }
            }
            #endregion

            #region DoAction
            if (CastType == CastType.Location)
            {
                if (!await Coroutine.Wait(1000, () => Actionmanager.DoActionLocation(ID, target.Location)))
                {
                    return false;
                }
            }
            else
            {
                if (!await Coroutine.Wait(1000, () => Actionmanager.DoAction(ID, target)))
                {
                    return false;
                }
            }
            #endregion
            Ultima.LastSpell = this;
            #region Recent Spell Add
            if (SpellType != SpellType.Damage &&
                SpellType != SpellType.Behind &&
                SpellType != SpellType.Flank)
            {
                var key = target.ObjectId.ToString("X") + "-" + Name;
                var val = DateTime.UtcNow + DataManager.GetSpellData(ID).AdjustedCastTime + TimeSpan.FromSeconds(5);
                RecentSpell.Add(key, val);
            }
            #endregion
            Logging.Write(Colors.OrangeRed, @"[Ultima] Ability: " + Name);
            await Coroutine.Wait(3000, () => !Actionmanager.CanCast(ID, target));
            return true;
        }
    }
}

