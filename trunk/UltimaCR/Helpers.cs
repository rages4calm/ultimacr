using ff14bot;
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

            var retval = auras.Any(aura => aura.TimespanLeft.TotalMilliseconds > msLeft);

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

            var retval = auras.Any(aura => aura.TimespanLeft.TotalMilliseconds > msLeft);

            return retval;
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
           return ie != null &&
               GameObjectManager.Attackers.Contains(ie) &&
               !ie.IsDead &&
               ie.CanAttack &&
               ie.IsTargetable;
        }

        private static IEnumerable<BattleCharacter> EnemyUnit
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

/*
        public static int AoETargets(float range)
        {
            var target = Core.Player.CurrentTarget;
            if (target == null)
                return 0;
            var tarLoc = target.Location;
            return EnemyUnit.Count(u => u.Location.Distance3D(tarLoc) <= range);
        }
*/
    }
}