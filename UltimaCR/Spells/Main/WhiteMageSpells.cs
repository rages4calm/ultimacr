
namespace UltimaCR.Spells.Main
{
    public class WhiteMageSpells : ConjurerSpells
    {
        private CrossClass.WhiteMageSpells.Crossclass _crossClass;
        public new CrossClass.WhiteMageSpells.Crossclass CrossClass
        {
            get { return _crossClass ?? (_crossClass = new CrossClass.WhiteMageSpells.Crossclass()); }
        }

        private PVP.WhiteMageSpells.Pvp _pvp;
        public new PVP.WhiteMageSpells.Pvp PvP
        {
            get { return _pvp ?? (_pvp = new PVP.WhiteMageSpells.Pvp()); }
        }

        private Spell _presenceofmind;
        public Spell PresenceOfMind
        {
            get
            {
                return _presenceofmind ??
                       (_presenceofmind =
                           new Spell
                           {
                               Name = "Presence of Mind",
                               ID = 136,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _regen;
        public Spell Regen
        {
            get
            {
                return _regen ??
                       (_regen =
                           new Spell
                           {
                               Name = "Regen",
                               ID = 137,
                               Level = 35,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Heal,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _divineseal;
        public Spell DivineSeal
        {
            get
            {
                return _divineseal ??
                       (_divineseal =
                           new Spell
                           {
                               Name = "Divine Seal",
                               ID = 138,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _holy;
        public Spell Holy
        {
            get
            {
                return _holy ??
                       (_holy =
                           new Spell
                           {
                               Name = "Holy",
                               ID = 139,
                               Level = 45,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _benediction;
        public Spell Benediction
        {
            get
            {
                return _benediction ??
                       (_benediction =
                           new Spell
                           {
                               Name = "Benediction",
                               ID = 140,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Heal,
                               CastType = CastType.Target
                           });
            }
        }
    }
}