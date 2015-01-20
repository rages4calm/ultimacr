using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public interface IRotation
    {
        float PullRange { get; }

        #region Level Specific Methods

        #region Rest

        Task<bool> Rest();

        #endregion

        #region Pre-Combat Buff

        Task<bool> PreCombatBuffLvL1();
        Task<bool> PreCombatBuffLvL2();
        Task<bool> PreCombatBuffLvL4();
        Task<bool> PreCombatBuffLvL6();
        Task<bool> PreCombatBuffLvL8();
        Task<bool> PreCombatBuffLvL10();
        Task<bool> PreCombatBuffLvL12();
        Task<bool> PreCombatBuffLvL14();
        Task<bool> PreCombatBuffLvL15();
        Task<bool> PreCombatBuffLvL16();
        Task<bool> PreCombatBuffLvL18();
        Task<bool> PreCombatBuffLvL20();
        Task<bool> PreCombatBuffLvL22();
        Task<bool> PreCombatBuffLvL24();
        Task<bool> PreCombatBuffLvL26();
        Task<bool> PreCombatBuffLvL28();
        Task<bool> PreCombatBuffLvL30();
        Task<bool> PreCombatBuffLvL32();
        Task<bool> PreCombatBuffLvL34();
        Task<bool> PreCombatBuffLvL36();
        Task<bool> PreCombatBuffLvL38();
        Task<bool> PreCombatBuffLvL40();
        Task<bool> PreCombatBuffLvL42();
        Task<bool> PreCombatBuffLvL44();
        Task<bool> PreCombatBuffLvL46();
        Task<bool> PreCombatBuffLvL48();
        Task<bool> PreCombatBuffLvL50();

        #endregion

        #region Pull

        Task<bool> PullLvL1();
        Task<bool> PullLvL2();
        Task<bool> PullLvL4();
        Task<bool> PullLvL6();
        Task<bool> PullLvL8();
        Task<bool> PullLvL10();
        Task<bool> PullLvL12();
        Task<bool> PullLvL14();
        Task<bool> PullLvL15();
        Task<bool> PullLvL16();
        Task<bool> PullLvL18();
        Task<bool> PullLvL20();
        Task<bool> PullLvL22();
        Task<bool> PullLvL24();
        Task<bool> PullLvL26();
        Task<bool> PullLvL28();
        Task<bool> PullLvL30();
        Task<bool> PullLvL32();
        Task<bool> PullLvL34();
        Task<bool> PullLvL36();
        Task<bool> PullLvL38();
        Task<bool> PullLvL40();
        Task<bool> PullLvL42();
        Task<bool> PullLvL44();
        Task<bool> PullLvL46();
        Task<bool> PullLvL48();
        Task<bool> PullLvL50();

        #endregion

        #region Heal

        Task<bool> HealLvL1();
        Task<bool> HealLvL2();
        Task<bool> HealLvL4();
        Task<bool> HealLvL6();
        Task<bool> HealLvL8();
        Task<bool> HealLvL10();
        Task<bool> HealLvL12();
        Task<bool> HealLvL14();
        Task<bool> HealLvL15();
        Task<bool> HealLvL16();
        Task<bool> HealLvL18();
        Task<bool> HealLvL20();
        Task<bool> HealLvL22();
        Task<bool> HealLvL24();
        Task<bool> HealLvL26();
        Task<bool> HealLvL28();
        Task<bool> HealLvL30();
        Task<bool> HealLvL32();
        Task<bool> HealLvL34();
        Task<bool> HealLvL36();
        Task<bool> HealLvL38();
        Task<bool> HealLvL40();
        Task<bool> HealLvL42();
        Task<bool> HealLvL44();
        Task<bool> HealLvL46();
        Task<bool> HealLvL48();
        Task<bool> HealLvL50();

        #endregion

        #region Combat Buff

        Task<bool> CombatBuffLvL1();
        Task<bool> CombatBuffLvL2();
        Task<bool> CombatBuffLvL4();
        Task<bool> CombatBuffLvL6();
        Task<bool> CombatBuffLvL8();
        Task<bool> CombatBuffLvL10();
        Task<bool> CombatBuffLvL12();
        Task<bool> CombatBuffLvL14();
        Task<bool> CombatBuffLvL15();
        Task<bool> CombatBuffLvL16();
        Task<bool> CombatBuffLvL18();
        Task<bool> CombatBuffLvL20();
        Task<bool> CombatBuffLvL22();
        Task<bool> CombatBuffLvL24();
        Task<bool> CombatBuffLvL26();
        Task<bool> CombatBuffLvL28();
        Task<bool> CombatBuffLvL30();
        Task<bool> CombatBuffLvL32();
        Task<bool> CombatBuffLvL34();
        Task<bool> CombatBuffLvL36();
        Task<bool> CombatBuffLvL38();
        Task<bool> CombatBuffLvL40();
        Task<bool> CombatBuffLvL42();
        Task<bool> CombatBuffLvL44();
        Task<bool> CombatBuffLvL46();
        Task<bool> CombatBuffLvL48();
        Task<bool> CombatBuffLvL50();

        #endregion

        #region Combat

        Task<bool> CombatLvL1();
        Task<bool> CombatLvL2();
        Task<bool> CombatLvL4();
        Task<bool> CombatLvL6();
        Task<bool> CombatLvL8();
        Task<bool> CombatLvL10();
        Task<bool> CombatLvL12();
        Task<bool> CombatLvL14();
        Task<bool> CombatLvL15();
        Task<bool> CombatLvL16();
        Task<bool> CombatLvL18();
        Task<bool> CombatLvL20();
        Task<bool> CombatLvL22();
        Task<bool> CombatLvL24();
        Task<bool> CombatLvL26();
        Task<bool> CombatLvL28();
        Task<bool> CombatLvL30();
        Task<bool> CombatLvL32();
        Task<bool> CombatLvL34();
        Task<bool> CombatLvL36();
        Task<bool> CombatLvL38();
        Task<bool> CombatLvL40();
        Task<bool> CombatLvL42();
        Task<bool> CombatLvL44();
        Task<bool> CombatLvL46();
        Task<bool> CombatLvL48();
        Task<bool> CombatLvL50();

        Task<bool> PVPRotation();

        #endregion

        #endregion
    }
}