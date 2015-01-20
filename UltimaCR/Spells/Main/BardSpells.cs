
namespace UltimaCR.Spells.Main
{
    public class BardSpells : ArcherSpells
    {
        private CrossClass.BardSpells.Crossclass _crossClass;
        public new CrossClass.BardSpells.Crossclass CrossClass
        {
            get { return _crossClass ?? (_crossClass = new CrossClass.BardSpells.Crossclass()); }
        }

        private PVP.BardSpells.Pvp _pvp;
        public new PVP.BardSpells.Pvp PvP
        {
            get { return _pvp ?? (_pvp = new PVP.BardSpells.Pvp()); }
        }

        private Spell _magesballad;
        public Spell MagesBallad
        {
            get
            {
                return _magesballad ??
                       (_magesballad =
                           new Spell
                           {
                               Name = "Mage's Ballad",
                               ID = 114,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _foerequiem;
        public Spell FoeRequiem
        {
            get
            {
                return _foerequiem ??
                       (_foerequiem =
                           new Spell
                           {
                               Name = "Foe Requiem",
                               ID = 115,
                               Level = 35,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Debuff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _armyspaeon;
        public Spell ArmysPaeon
        {
            get
            {
                return _armyspaeon ??
                       (_armyspaeon =
                           new Spell
                           {
                               Name = "Army's Paeon",
                               ID = 116,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _rainofdeath;
        public Spell RainOfDeath
        {
            get
            {
                return _rainofdeath ??
                       (_rainofdeath =
                           new Spell
                           {
                               Name = "Rain of Death",
                               ID = 117,
                               Level = 45,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _battlevoice;
        public Spell BattleVoice
        {
            get
            {
                return _battlevoice ??
                       (_battlevoice =
                           new Spell
                           {
                               Name = "Battle Voice",
                               ID = 118,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
    }
}