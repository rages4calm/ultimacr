using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public abstract class Rotation : IRotation
    {
        #region ISpellBook

        public virtual float PullRange
        {
            get { return 25.0f; }
        }

        #endregion

        #region IRotation

        #region Rest

        public abstract Task<bool> Rest();

        #endregion

        #region Pre-Combat Buff

        public abstract Task<bool> PreCombatBuffLvL1();
        public abstract Task<bool> PreCombatBuffLvL2();
        public abstract Task<bool> PreCombatBuffLvL4();
        public abstract Task<bool> PreCombatBuffLvL6();
        public abstract Task<bool> PreCombatBuffLvL8();
        public abstract Task<bool> PreCombatBuffLvL10();
        public abstract Task<bool> PreCombatBuffLvL12();
        public abstract Task<bool> PreCombatBuffLvL14();
        public abstract Task<bool> PreCombatBuffLvL15();
        public abstract Task<bool> PreCombatBuffLvL16();
        public abstract Task<bool> PreCombatBuffLvL18();
        public abstract Task<bool> PreCombatBuffLvL20();
        public abstract Task<bool> PreCombatBuffLvL22();
        public abstract Task<bool> PreCombatBuffLvL24();
        public abstract Task<bool> PreCombatBuffLvL26();
        public abstract Task<bool> PreCombatBuffLvL28();
        public abstract Task<bool> PreCombatBuffLvL30();
        public abstract Task<bool> PreCombatBuffLvL32();
        public abstract Task<bool> PreCombatBuffLvL34();
        public abstract Task<bool> PreCombatBuffLvL36();
        public abstract Task<bool> PreCombatBuffLvL38();
        public abstract Task<bool> PreCombatBuffLvL40();
        public abstract Task<bool> PreCombatBuffLvL42();
        public abstract Task<bool> PreCombatBuffLvL44();
        public abstract Task<bool> PreCombatBuffLvL46();
        public abstract Task<bool> PreCombatBuffLvL48();
        public abstract Task<bool> PreCombatBuffLvL50();

        #endregion

        #region Pull

        public abstract Task<bool> PullLvL1();
        public abstract Task<bool> PullLvL2();
        public abstract Task<bool> PullLvL4();
        public abstract Task<bool> PullLvL6();
        public abstract Task<bool> PullLvL8();
        public abstract Task<bool> PullLvL10();
        public abstract Task<bool> PullLvL12();
        public abstract Task<bool> PullLvL14();
        public abstract Task<bool> PullLvL15();
        public abstract Task<bool> PullLvL16();
        public abstract Task<bool> PullLvL18();
        public abstract Task<bool> PullLvL20();
        public abstract Task<bool> PullLvL22();
        public abstract Task<bool> PullLvL24();
        public abstract Task<bool> PullLvL26();
        public abstract Task<bool> PullLvL28();
        public abstract Task<bool> PullLvL30();
        public abstract Task<bool> PullLvL32();
        public abstract Task<bool> PullLvL34();
        public abstract Task<bool> PullLvL36();
        public abstract Task<bool> PullLvL38();
        public abstract Task<bool> PullLvL40();
        public abstract Task<bool> PullLvL42();
        public abstract Task<bool> PullLvL44();
        public abstract Task<bool> PullLvL46();
        public abstract Task<bool> PullLvL48();
        public abstract Task<bool> PullLvL50();

        #endregion

        #region Heal

        public abstract Task<bool> HealLvL1();
        public abstract Task<bool> HealLvL2();
        public abstract Task<bool> HealLvL4();
        public abstract Task<bool> HealLvL6();
        public abstract Task<bool> HealLvL8();
        public abstract Task<bool> HealLvL10();
        public abstract Task<bool> HealLvL12();
        public abstract Task<bool> HealLvL14();
        public abstract Task<bool> HealLvL15();
        public abstract Task<bool> HealLvL16();
        public abstract Task<bool> HealLvL18();
        public abstract Task<bool> HealLvL20();
        public abstract Task<bool> HealLvL22();
        public abstract Task<bool> HealLvL24();
        public abstract Task<bool> HealLvL26();
        public abstract Task<bool> HealLvL28();
        public abstract Task<bool> HealLvL30();
        public abstract Task<bool> HealLvL32();
        public abstract Task<bool> HealLvL34();
        public abstract Task<bool> HealLvL36();
        public abstract Task<bool> HealLvL38();
        public abstract Task<bool> HealLvL40();
        public abstract Task<bool> HealLvL42();
        public abstract Task<bool> HealLvL44();
        public abstract Task<bool> HealLvL46();
        public abstract Task<bool> HealLvL48();
        public abstract Task<bool> HealLvL50();

        #endregion

        #region Combat Buff

        public abstract Task<bool> CombatBuffLvL1();
        public abstract Task<bool> CombatBuffLvL2();
        public abstract Task<bool> CombatBuffLvL4();
        public abstract Task<bool> CombatBuffLvL6();
        public abstract Task<bool> CombatBuffLvL8();
        public abstract Task<bool> CombatBuffLvL10();
        public abstract Task<bool> CombatBuffLvL12();
        public abstract Task<bool> CombatBuffLvL14();
        public abstract Task<bool> CombatBuffLvL15();
        public abstract Task<bool> CombatBuffLvL16();
        public abstract Task<bool> CombatBuffLvL18();
        public abstract Task<bool> CombatBuffLvL20();
        public abstract Task<bool> CombatBuffLvL22();
        public abstract Task<bool> CombatBuffLvL24();
        public abstract Task<bool> CombatBuffLvL26();
        public abstract Task<bool> CombatBuffLvL28();
        public abstract Task<bool> CombatBuffLvL30();
        public abstract Task<bool> CombatBuffLvL32();
        public abstract Task<bool> CombatBuffLvL34();
        public abstract Task<bool> CombatBuffLvL36();
        public abstract Task<bool> CombatBuffLvL38();
        public abstract Task<bool> CombatBuffLvL40();
        public abstract Task<bool> CombatBuffLvL42();
        public abstract Task<bool> CombatBuffLvL44();
        public abstract Task<bool> CombatBuffLvL46();
        public abstract Task<bool> CombatBuffLvL48();
        public abstract Task<bool> CombatBuffLvL50();

        #endregion

        #region Combat

        public abstract Task<bool> CombatLvL1();
        public abstract Task<bool> CombatLvL2();
        public abstract Task<bool> CombatLvL4();
        public abstract Task<bool> CombatLvL6();
        public abstract Task<bool> CombatLvL8();
        public abstract Task<bool> CombatLvL10();
        public abstract Task<bool> CombatLvL12();
        public abstract Task<bool> CombatLvL14();
        public abstract Task<bool> CombatLvL15();
        public abstract Task<bool> CombatLvL16();
        public abstract Task<bool> CombatLvL18();
        public abstract Task<bool> CombatLvL20();
        public abstract Task<bool> CombatLvL22();
        public abstract Task<bool> CombatLvL24();
        public abstract Task<bool> CombatLvL26();
        public abstract Task<bool> CombatLvL28();
        public abstract Task<bool> CombatLvL30();
        public abstract Task<bool> CombatLvL32();
        public abstract Task<bool> CombatLvL34();
        public abstract Task<bool> CombatLvL36();
        public abstract Task<bool> CombatLvL38();
        public abstract Task<bool> CombatLvL40();
        public abstract Task<bool> CombatLvL42();
        public abstract Task<bool> CombatLvL44();
        public abstract Task<bool> CombatLvL46();
        public abstract Task<bool> CombatLvL48();
        public abstract Task<bool> CombatLvL50();

        public abstract Task<bool> PVPRotation();

        #endregion

        #endregion
    }
}