
namespace UltimaCR.Spells.Main
{
    public class WarriorSpells : MarauderSpells
    {
        private CrossClass.WarriorSpells.Crossclass _crossClass;
        public new CrossClass.WarriorSpells.Crossclass CrossClass
        {
            get { return _crossClass ?? (_crossClass = new CrossClass.WarriorSpells.Crossclass()); }
        }

        private PVP.WarriorSpells.Pvp _pvp;
        public new PVP.WarriorSpells.Pvp PvP
        {
            get { return _pvp ?? (_pvp = new PVP.WarriorSpells.Pvp()); }
        }

        private Spell _defiance;
        public Spell Defiance
        {
            get
            {
                return _defiance ??
                       (_defiance =
                           new Spell
                           {
                               Name = "Defiance",
                               ID = 48,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Aura,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _innerbeast;
        public Spell InnerBeast
        {
            get
            {
                return _innerbeast ??
                       (_innerbeast =
                           new Spell
                           {
                               Name = "Inner Beast",
                               ID = 49,
                               Level = 35,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _unchained;
        public Spell Unchained
        {
            get
            {
                return _unchained ??
                       (_unchained =
                           new Spell
                           {
                               Name = "Unchained",
                               ID = 50,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _steelcyclone;
        public Spell SteelCyclone
        {
            get
            {
                return _steelcyclone ??
                       (_steelcyclone =
                           new Spell
                           {
                               Name = "Steel Cyclone",
                               ID = 51,
                               Level = 45,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _infuriate;
        public Spell Infuriate
        {
            get
            {
                return _infuriate ??
                       (_infuriate =
                           new Spell
                           {
                               Name = "Infuriate",
                               ID = 52,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
    }
}