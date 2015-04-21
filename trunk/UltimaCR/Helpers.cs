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
        public static bool IsEnemy(this BattleCharacter bc)
        {
           return bc != null &&
               GameObjectManager.Attackers.Contains(bc) &&
               !bc.IsDead &&
               bc.CanAttack &&
               bc.IsTargetable;
        }

        private static IEnumerable<BattleCharacter> EnemyUnit
        {
            get
            {
                return
                    GameObjectManager.GetObjectsOfType<BattleCharacter>()
                        .Where(u => u.IsEnemy());
            }
        }
        public static bool PlayerTargeted
        {
            get
            {
                return EnemyUnit.All(u => u.CurrentTargetId == Core.Me.ObjectId);
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