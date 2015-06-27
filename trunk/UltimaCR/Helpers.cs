using Clio.Common;
using Clio.Utilities;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UltimaCR
{
    public static class Helpers
    {
        public static bool HasAura(this GameObject unit, string auraname, bool isMyAura = false, int msLeft = 0)
        {
            var unitasc = (unit as Character);
            if (unit == null || unitasc == null)
            {
                return false;
            }
            var auras = isMyAura
                ? unitasc.CharacterAuras.Where(r => r.CasterId == Core.Player.ObjectId && r.Name == auraname)
                : unitasc.CharacterAuras.Where(r => r.Name == auraname);

            return auras.Any(aura => aura.TimespanLeft.TotalMilliseconds >= msLeft);
        }

        public static bool HasAura(this GameObject unit, uint auraid, bool isMyAura = false, int msLeft = 0)
        {
            var unitasc = (unit as Character);
            if (unit == null || unitasc == null)
            {
                return false;
            }
            var auras = isMyAura
                ? unitasc.CharacterAuras.Where(r => r.CasterId == Core.Player.ObjectId && r.Id == auraid)
                : unitasc.CharacterAuras.Where(r => r.Id == auraid);

            return auras.Any(aura => aura.TimespanLeft.TotalMilliseconds >= msLeft);
        }

        public static bool InsideCone(Vector3 PlayerLocation, float PlayerHeading, Vector3 TargetLocation)
        {
            var d = Math.Abs(MathEx.NormalizeRadian(PlayerHeading
                - MathEx.NormalizeRadian(MathHelper.CalculateHeading(PlayerLocation, TargetLocation)
                + (float)Math.PI)));

            if (d > Math.PI)
            {
                d = Math.Abs(d - 2 * (float)Math.PI);
            }
            return d < 0.78539f;
        }

        public static void RemoveAll<TKey, TValue>(this Dictionary<TKey, TValue> dic, Func<TValue, bool> predicate)
        {
            var keys = dic.Keys.Where(k => predicate(dic[k])).ToList();
            foreach (var key in keys)
            {
                dic.Remove(key);
            }
        }


        public static bool TargetDistance(this LocalPlayer o, float range, bool useMinRange = true)
        {
            return useMinRange ? o.HasTarget && o.Distance(o.CurrentTarget) >= range + o.CurrentTarget.CombatReach : o.HasTarget && o.Distance(o.CurrentTarget) <= range + o.CurrentTarget.CombatReach;
        }

        private static bool IsEnemy(this BattleCharacter ie)
        {
           return
               ie != null &&
               GameObjectManager.Attackers.Contains(ie) &&
               !ie.IsDead &&
               ie.CanAttack &&
               ie.IsTargetable;
        }

        public static IEnumerable<BattleCharacter> EnemyUnit
        {
            get
            {
                return
                    GameObjectManager.GetObjectsOfType<BattleCharacter>()
                        .Where(eu => eu.IsEnemy());
            }
        }

        //Tanking (Provoke, Flash, etc.) "If something isn't targeting me"
        public static IEnumerable<BattleCharacter> NotTargetingPlayer
        {
            get
            {
                return
                    GameObjectManager.GetObjectsOfType<BattleCharacter>()
                    .Where(ntp => EnemyUnit.Contains(ntp) && ntp.CurrentTargetId != Core.Player.ObjectId)
                    .OrderByDescending(ntp => ntp.CurrentHealthPercent);
            }
        }

        //Targeted Defensive Skills "If this is targeting me"
        public static bool IsTargetingMe(this BattleCharacter tp)
        {
            return tp.IsEnemy() && tp.CurrentTargetId == Core.Player.ObjectId;
        }


        //Self Defensive Skills "If anything is targeting me"
        public static bool EnemyTargetingMe
        {
            get
            {
                return EnemyUnit.Any(tp => tp.CurrentTargetId == Core.Player.ObjectId);
            }
        }

        public static int EnemiesNearTarget(float radius)
        {
            return Core.Player.CurrentTarget == null ? 0 : EnemyUnit.Count(u => u.Distance2D(Core.Player.CurrentTarget) <= radius + Core.Player.CurrentTarget.CombatReach);
        }

        public static int EnemiesNearPlayer(float radius)
        {
            return EnemyUnit.Count(u => u.Distance2D(Core.Player) <= radius + Core.Player.CombatReach);
        }

        #region Auto-Goad

        public static IEnumerable<Character> AutoGoad
        {
            get
            {
                return
                    PartyManager.VisibleMembers
                    .Select(ag => ag.GameObject as Character)
                    .Where(ag => !ag.IsMe && ag.Type == GameObjectType.Pc && ag.CurrentTP <= 800)
                    .OrderByDescending(GetTPScore);
            }
        }

        private static int GetTPScore(Character c)
        {
            var score = 0;

            if (c.IsTank() && c.CurrentTP <= 800)
            {
                score += 100;
            }
            switch (c.CurrentJob)
            {
                case ClassJobType.Archer:
                case ClassJobType.Bard:
                case ClassJobType.Pugilist:
                case ClassJobType.Monk:
                case ClassJobType.Rogue:
                case ClassJobType.Ninja:
                case ClassJobType.Machinist:
                    if (c.CurrentTP <= 400)
                    {
                        score += 200;
                    }
                    break;
            }
            switch (c.CurrentJob)
            {
                case ClassJobType.Lancer:
                case ClassJobType.Dragoon:
                    if (c.CurrentTP <= 300)
                    {
                        score += 200;
                    }
                    break;
            }
            return score;
        }

        #endregion

        #region Role Check

        public static bool IsTank(this Character c)
        {
            switch (c.CurrentJob)
            {
                case ClassJobType.Marauder:
                case ClassJobType.Warrior:
                case ClassJobType.Gladiator:
                case ClassJobType.Paladin:
                case ClassJobType.DarkKnight:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsHealer(this Character c)
        {
            switch (c.CurrentJob)
            {
                case ClassJobType.Arcanist:
                case ClassJobType.Scholar:
                case ClassJobType.Conjurer:
                case ClassJobType.WhiteMage:
                case ClassJobType.Astrologian:
                    return true;
                default:
                    return false;
            }
        }


        public static bool IsDPS(this Character c)
        {
            return
                !c.IsTank() && !c.IsHealer();
        }

        #endregion
    }
}