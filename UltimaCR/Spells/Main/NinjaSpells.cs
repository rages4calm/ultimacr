
namespace UltimaCR.Spells.Main
{
    public class NinjaSpells : RogueSpells
    {
        private CrossClass.NinjaSpells.Crossclass _crossClass;
        public new CrossClass.NinjaSpells.Crossclass CrossClass
        {
            get { return _crossClass ?? (_crossClass = new CrossClass.NinjaSpells.Crossclass()); }
        }

        private PVP.NinjaSpells.Pvp _pvp;
        public new PVP.NinjaSpells.Pvp PvP
        {
            get { return _pvp ?? (_pvp = new PVP.NinjaSpells.Pvp()); }
        }

        private Spell _ninjutsu;
        public Spell Ninjutsu
        {
            get
            {
                return _ninjutsu ??
                       (_ninjutsu =
                           new Spell
                           {
                               Name = "Ninjutsu",
                               ID = 2260,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Ninjutsu,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _ten;
        public Spell Ten
        {
            get
            {
                return _ten ??
                       (_ten =
                           new Spell
                           {
                               Name = "Ten",
                               ID = 2259,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _fumashuriken;
        public Spell FumaShuriken
        {
            get
            {
                return _fumashuriken ??
                       (_fumashuriken =
                           new Spell
                           {
                               Name = "Fuma Shuriken",
                               ID = 2265,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Ninjutsu,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _chi;
        public Spell Chi
        {
            get
            {
                return _chi ??
                       (_chi =
                           new Spell
                           {
                               Name = "Chi",
                               ID = 2261,
                               Level = 35,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _katon;
        public Spell Katon
        {
            get
            {
                return _katon ??
                       (_katon =
                           new Spell
                           {
                               Name = "Katon",
                               ID = 2266,
                               Level = 35,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Ninjutsu,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _raiton;
        public Spell Raiton
        {
            get
            {
                return _raiton ??
                       (_raiton =
                           new Spell
                           {
                               Name = "Raiton",
                               ID = 2267,
                               Level = 35,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Ninjutsu,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _shukuchi;
        public Spell Shukuchi
        {
            get
            {
                return _shukuchi ??
                       (_shukuchi =
                           new Spell
                           {
                               Name = "Shukuchi",
                               ID = 2262,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.OnLocation,
                               CastType = CastType.Location
                           });
            }
        }
        private Spell _jin;
        public Spell Jin
        {
            get
            {
                return _jin ??
                       (_jin =
                           new Spell
                           {
                               Name = "Jin",
                               ID = 2263,
                               Level = 45,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _hyoton;
        public Spell Hyoton
        {
            get
            {
                return _hyoton ??
                       (_hyoton =
                           new Spell
                           {
                               Name = "Hyoton",
                               ID = 2268,
                               Level = 45,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Ninjutsu,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _huton;
        public Spell Huton
        {
            get
            {
                return _huton ??
                       (_huton =
                           new Spell
                           {
                               Name = "Huton",
                               ID = 2269,
                               Level = 45,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Ninjutsu,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _doton;
        public Spell Doton
        {
            get
            {
                return _doton ??
                       (_doton =
                           new Spell
                           {
                               Name = "Doton",
                               ID = 2270,
                               Level = 45,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Ninjutsu,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _suiton;
        public Spell Suiton
        {
            get
            {
                return _suiton ??
                       (_suiton =
                           new Spell
                           {
                               Name = "Suiton",
                               ID = 2271,
                               Level = 45,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Ninjutsu,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _kassatsu;
        public Spell Kassatsu
        {
            get
            {
                return _kassatsu ??
                       (_kassatsu =
                           new Spell
                           {
                               Name = "Kassatsu",
                               ID = 2264,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
    }
}