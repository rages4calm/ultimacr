using Buddy.Coroutines;
using Clio.Utilities;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Navigation;
using ff14bot.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public static readonly Dictionary<string, DateTime> RecentSpell = new Dictionary<string, DateTime>();

        readonly Random _rnd = new Random();

        private int GetMultiplier() { return _rnd.NextDouble() < 0.5 ? 1 : -1; }

        public async Task<bool> Cast(GameObject target = null)
        {
            #region Target
            if (target == null)
            {
                switch (CastType)
                {
                    case CastType.TargetLocation:
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

            #region Bard Song Check

            if (Core.Player.CurrentJob == ClassJobType.Bard &&
                SpellType == SpellType.Buff)
            {
                if (Core.Player.HasAura(114, true) ||
                    Core.Player.HasAura(116, true))
                {
                    return false;
                }
            }

            #endregion

            #region AoE Check

            if (SpellType == SpellType.AoE &&
                Ultima.UltSettings.SmartTarget)
            {
                var EnemyCount = Helpers.EnemyUnit.Count(eu => eu.Distance2D(target) - eu.CombatReach - target.CombatReach <= DataManager.GetSpellData(ID).Radius);

                if (Core.Player.CurrentJob == ClassJobType.Arcanist ||
                    Core.Player.CurrentJob == ClassJobType.Scholar ||
                    Core.Player.CurrentJob == ClassJobType.Summoner)
                {
                    if (EnemyCount < 2)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.Archer ||
                    Core.Player.CurrentJob == ClassJobType.Bard)
                {
                    if (EnemyCount < 3)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.Lancer ||
                    Core.Player.CurrentJob == ClassJobType.Dragoon)
                {
                    if (EnemyCount < 3)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.Pugilist ||
                    Core.Player.CurrentJob == ClassJobType.Monk)
                {
                    if (EnemyCount < 3)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.Rogue ||
                    Core.Player.CurrentJob == ClassJobType.Ninja)
                {
                    if (EnemyCount < 3)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.Thaumaturge ||
                    Core.Player.CurrentJob == ClassJobType.BlackMage)
                {
                    if (EnemyCount < 3)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.Astrologian)
                {
                    if (EnemyCount < 3)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.DarkKnight)
                {
                    if (EnemyCount < 3)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.Machinist)
                {
                    if (EnemyCount < 3)
                    {
                        return false;
                    }
                }

            }

            #region Cone Check

            if (ID == 106 || ID == 41 || ID == 70)
            {
                if (Core.Player.Distance2D(target) - target.CombatReach - Core.Player.CombatReach > DataManager.GetSpellData(ID).Range ||
                    !Helpers.InsideCone(Core.Player.Location, Core.Player.Heading, target.Location))
                {
                    return false;
                }
            }

            #endregion

            #region Rectangle Check

            if (ID == 86)
            {
                if (Core.Player.Distance2D(target) - target.CombatReach - Core.Player.CombatReach > DataManager.GetSpellData(ID).Range ||
                    !Core.Player.IsFacing(target))
                {
                    return false;
                }
            }

            #endregion

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
                    if (!await Coroutine.Wait(1000, () => Pet.DoAction("Obey", Core.Player)))
                    {
                        return false;
                    }
                    Logging.Write(Colors.OrangeRed, @"[Ultima] Ability: Pet Obey");
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

            #region Card Exception

            if (SpellType == SpellType.Card)
            {
                if (!await Coroutine.Wait(1000, () => Actionmanager.DoAction(ID, target)))
                {
                    return false;
                }
                Ultima.LastSpell = this;
                #region Recent Spell Add
                var key = target.ObjectId.ToString("X") + "-" + Name;
                var val = DateTime.UtcNow + DataManager.GetSpellData(3590).AdjustedCastTime + TimeSpan.FromSeconds(5);
                RecentSpell.Add(key, val);
                #endregion
                Logging.Write(Colors.OrangeRed, @"[Ultima] Ability: " + Name);
                return true;
            }

            #endregion

            #region CanAttack Check

            if (!target.CanAttack &&
                CastType != CastType.Self)
            {
                switch (SpellType)
                {
                    case SpellType.Damage:
                    case SpellType.DoT:
                    case SpellType.Cooldown:
                    case SpellType.Interrupt:
                    case SpellType.Execute:
                    case SpellType.Knockback:
                    case SpellType.Debuff:
                    case SpellType.Flank:
                    case SpellType.Behind:
                        return false;
                }
            }

            #endregion

            #region Ninjutsu Exception
            if (SpellType == SpellType.Ninjutsu ||
                SpellType == SpellType.Mudra)
            {
                if (BotManager.Current.IsAutonomous)
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
                        case SpellRangeCheck.Success:
                            if (MovementManager.IsMoving)
                            {
                                Navigator.PlayerMover.MoveStop();
                            }
                            break;
                    }
                }
                if (Ultima.UltSettings.QueueSpells)
                {
                    if (!Actionmanager.CanCastOrQueue(DataManager.GetSpellData(ID), target))
                    {
                        return true;
                    }
                }
                else
                {
                    if (!Actionmanager.CanCast(ID, target))
                    {
                        return true;
                    }
                }
                if (!await Coroutine.Wait(1000, () => Actionmanager.DoAction(ID, target)))
                {
                    return true;
                }
                Ultima.LastSpell = this;
                #region Recent Spell Add
                if (SpellType == SpellType.Mudra)
                {
                    var key = target.ObjectId.ToString("X") + "-" + Name;
                    var val = DateTime.UtcNow + DataManager.GetSpellData(ID).AdjustedCastTime + TimeSpan.FromSeconds(6);
                    RecentSpell.Add(key, val);
                }
                #endregion
                Logging.Write(Colors.OrangeRed, @"[Ultima] Ability: " + Name);
                return true;
            }
            #endregion

            #region HasSpell Check

            if (!Actionmanager.HasSpell(ID))
            {
                return false;
            }

            #endregion

            #region Player Movement

            if (BotManager.Current.IsAutonomous)
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
                    case SpellRangeCheck.Success:
                        if (MovementManager.IsMoving)
                        {
                            Navigator.PlayerMover.MoveStop();
                        }
                        break;
                }

                if (CastType == CastType.TargetLocation &&
                    Actionmanager.InSpellInRangeLOS(ID, target.Location) == SpellRangeCheck.ErrorNotInRange)
                {
                    Navigator.MoveTo(target.Location);
                    await Coroutine.Wait(3000, () => Actionmanager.InSpellInRangeLOS(ID, target.Location) != SpellRangeCheck.ErrorNotInRange);
                    return false;
                }
                
                if (!MovementManager.IsMoving &&
                    Core.Player.IsMounted)
                {
                    Actionmanager.Dismount();
                }
            }

            #endregion

            #region CanCast Check

            switch (CastType)
            {
                case CastType.TargetLocation:
                    if (!Actionmanager.CanCastLocation(ID, target.Location))
                    {
                        return false;
                    }
                    break;
                case CastType.SelfLocation:
                    if (!Actionmanager.CanCastLocation(ID, target.Location))
                    {
                        return false;
                    }
                    break;
                default:
                    if (Ultima.UltSettings.QueueSpells)
                    {
                        if (!Actionmanager.CanCastOrQueue(DataManager.GetSpellData(ID), target))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!Actionmanager.CanCast(ID, target))
                        {
                            return false;
                        }
                    }
                break;
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
                if (Core.Player.CurrentJob == ClassJobType.Astrologian)
                {
                    if (DataManager.GetSpellData(3596).Cooldown.TotalMilliseconds <= 1000)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.DarkKnight)
                {
                    if (DataManager.GetSpellData(3617).Cooldown.TotalMilliseconds <= 1000)
                    {
                        return false;
                    }
                }
                if (Core.Player.CurrentJob == ClassJobType.Machinist)
                {
                    if (DataManager.GetSpellData(2866).Cooldown.TotalMilliseconds <= 1000)
                    {
                        return false;
                    }
                }
            }
            #endregion

            #region Cleric Stance Check

            if (Actionmanager.HasSpell(122))
            {
                switch (Core.Player.HasAura("Cleric Stance"))
                {
                    case true:
                        if (SpellType == SpellType.Heal)
                        {
                            await Coroutine.Wait(1000, () => Actionmanager.DoAction(122, Core.Player));
                            Logging.Write(Colors.OrangeRed, @"[Ultima] Removing Cleric Stance");
                            await Coroutine.Wait(3000, () => !Core.Player.HasAura(145));
                        }
                        break;
                    case false:
                        if (SpellType == SpellType.Damage ||
                            SpellType == SpellType.DoT)
                        {
                            await Coroutine.Wait(1000, () => Actionmanager.DoAction(122, Core.Player));
                            Logging.Write(Colors.OrangeRed, @"[Ultima] Ability: Cleric Stance");
                            await Coroutine.Wait(3000, () => Core.Player.HasAura(145));
                        }
                        break;
                }
            }

            #endregion

            #region DoAction
            switch (CastType)
            {
                case CastType.TargetLocation:
                    if (Ultima.UltSettings.RandomCastLocation)
                    {
                        var rndx = (target.CombatReach * _rnd.NextDouble() * GetMultiplier());
                        var rndz = (target.CombatReach * _rnd.NextDouble() * GetMultiplier());
                        var rndxz = new Vector3((float)rndx, 0f, (float)rndz);
                        var tarloc = target.Location;
                        var rndloc = tarloc + rndxz;

                        if (!await Coroutine.Wait(1000, () => Actionmanager.DoActionLocation(ID, rndloc)))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!await Coroutine.Wait(1000, () => Actionmanager.DoActionLocation(ID, target.Location)))
                        {
                            return false;
                        }
                    }
                    break;
                case CastType.SelfLocation:
                    if (Ultima.UltSettings.RandomCastLocation)
                    {
                        var rndx = ((1f * _rnd.NextDouble() + 1f) * GetMultiplier());
                        var rndz = ((1f * _rnd.NextDouble() + 1f) * GetMultiplier());
                        var rndxz = new Vector3((float)rndx, 0f, (float)rndz);
                        var tarloc = target.Location;
                        var rndloc = tarloc + rndxz;

                        if (!await Coroutine.Wait(1000, () => Actionmanager.DoActionLocation(ID, rndloc)))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!await Coroutine.Wait(1000, () => Actionmanager.DoActionLocation(ID, target.Location)))
                        {
                            return false;
                        }
                    }
                    break;
                default:
                    if (!await Coroutine.Wait(1000, () => Actionmanager.DoAction(ID, target)))
                    {
                        return false;
                    }
                    break;
            }
            #endregion
            Ultima.LastSpell = this;
            #region Recent Spell Add
            if (SpellType != SpellType.Damage &&
                SpellType != SpellType.Heal &&
                SpellType != SpellType.AoE &&
                SpellType != SpellType.Behind &&
                SpellType != SpellType.Flank)
            {
                var key = target.ObjectId.ToString("X") + "-" + Name;
                var val = DateTime.UtcNow + DataManager.GetSpellData(ID).AdjustedCastTime + TimeSpan.FromSeconds(5);
                RecentSpell.Add(key, val);
            }
            if (SpellType == SpellType.Heal)
            {
                var key = target.ObjectId.ToString("X") + "-" + Name;
                var val = DateTime.UtcNow + DataManager.GetSpellData(ID).AdjustedCastTime + TimeSpan.FromSeconds(3);
                RecentSpell.Add(key, val);
            }
            #endregion
            Logging.Write(Colors.OrangeRed, @"[Ultima] Ability: " + Name);
            await Coroutine.Wait(3000, () => !Actionmanager.CanCast(ID, target));
            return true;
        }
    }
}