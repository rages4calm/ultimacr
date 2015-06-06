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
        public static bool HasAura(this GameObject unit, string spellname, bool isMyAura = false, int msLeft = 0)
        {
            var unitasc = (unit as Character);
            if (unit == null || unitasc == null)
            {
                return false;
            }
            var auras = isMyAura
                ? unitasc.CharacterAuras.Where(r => r.CasterId == Core.Player.ObjectId && r.Name == spellname)
                : unitasc.CharacterAuras.Where(r => r.Name == spellname);

            var retval = auras.Any(aura => aura.TimespanLeft.TotalMilliseconds >= msLeft);

            return retval;
        }

        public static bool HasAura(this GameObject unit, uint spellid, bool isMyAura = false, int msLeft = 0)
        {
            var unitasc = (unit as Character);
            if (unit == null || unitasc == null)
            {
                return false;
            }
            var auras = isMyAura
                ? unitasc.CharacterAuras.Where(r => r.CasterId == Core.Player.ObjectId && r.Id == spellid)
                : unitasc.CharacterAuras.Where(r => r.Id == spellid);

            var retval = auras.Any(aura => aura.TimespanLeft.TotalMilliseconds >= msLeft);

            return retval;
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
            return useMinRange ? o.HasTarget && o.Distance(o.CurrentTarget) >= range : o.HasTarget && o.Distance(o.CurrentTarget) <= range;
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

        private static bool IsPartyMember(this Character pm)
        {
            return
                pm != null &&
                PartyManager.IsInParty &&
                !pm.IsDead &&
                pm.IsTargetable;
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
            return Core.Player.CurrentTarget == null ? 0 : EnemyUnit.Count(u => u.Location.Distance3D(Core.Player.CurrentTarget.Location) <= radius);
        }

        public static int EnemiesNearPlayer(float radius)
        {
            return EnemyUnit.Count(u => u.Location.Distance3D(Core.Player.Location) <= radius);
        }

        #region Auto-Goad

        public static IEnumerable<Character> AutoGoad
        {
            get
            {
                return
                    GameObjectManager.GetObjectsOfType<Character>()
                    .Where(ltp => ltp.IsPartyMember() && !ltp.IsMe && ltp.CurrentTP <= 800)
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