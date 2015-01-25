
namespace UltimaCR.Spells.Main
{
    public class SummonerSpells : ArcanistSpells
    {
        private CrossClass.SummonerSpells.Crossclass _crossClass;
        public new CrossClass.SummonerSpells.Crossclass CrossClass
        {
            get { return _crossClass ?? (_crossClass = new CrossClass.SummonerSpells.Crossclass()); }
        }

        private PVP.SummonerSpells.Pvp _pvp;
        public new PVP.SummonerSpells.Pvp PvP
        {
            get { return _pvp ?? (_pvp = new PVP.SummonerSpells.Pvp()); }
        }

        private Spell _shockwave;
        public Spell Shockwave
        {
            get
            {
                return _shockwave ??
                       (_shockwave =
                           new Spell
                           {
                               Name = "Shockwave",
                               ID = 18,
                               Level = 4,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _mountainbuster;
        public Spell MountainBuster
        {
            get
            {
                return _mountainbuster ??
                       (_mountainbuster =
                           new Spell
                           {
                               Name = "Mountain Buster",
                               ID = 23,
                               Level = 15,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _aerialslash;
        public Spell AerialSlash
        {
            get
            {
                return _aerialslash ??
                       (_aerialslash =
                           new Spell
                           {
                               Name = "Aerial Slash",
                               ID = 19,
                               Level = 20,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _earthenward;
        public Spell EarthenWard
        {
            get
            {
                return _earthenward ??
                       (_earthenward =
                           new Spell
                           {
                               Name = "Earthen Ward",
                               ID = 24,
                               Level = 20,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _summonIII;
        public Spell SummonIII
        {
            get
            {
                return _summonIII ??
                       (_summonIII =
                           new Spell
                           {
                               Name = "Summon III",
                               ID = 180,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Summon,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _crimsoncyclone;
        public Spell CrimsonCyclone
        {
            get
            {
                return _crimsoncyclone ??
                       (_crimsoncyclone =
                           new Spell
                           {
                               Name = "Crimson Cyclone",
                               ID = 27,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _radiantshield;
        public Spell RadiantShield
        {
            get
            {
                return _radiantshield ??
                       (_radiantshield =
                           new Spell
                           {
                               Name = "Radiant Shield",
                               ID = 29,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _fester;
        public Spell Fester
        {
            get
            {
                return _fester ??
                       (_fester =
                           new Spell
                           {
                               Name = "Fester",
                               ID = 181,
                               Level = 35,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Cooldown,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _contagion;
        public Spell Contagion
        {
            get
            {
                return _contagion ??
                       (_contagion =
                           new Spell
                           {
                               Name = "Contagion",
                               ID = 20,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _landslide;
        public Spell Landslide
        {
            get
            {
                return _landslide ??
                       (_landslide =
                           new Spell
                           {
                               Name = "Landslide",
                               ID = 25,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _flamingcrush;
        public Spell FlamingCrush
        {
            get
            {
                return _flamingcrush ??
                       (_flamingcrush =
                           new Spell
                           {
                               Name = "Flaming Crush",
                               ID = 30,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _tridisaster;
        public Spell TriDisaster
        {
            get
            {
                return _tridisaster ??
                       (_tridisaster =
                           new Spell
                           {
                               Name = "Tri-disaster",
                               ID = 182,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Debuff,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _spur;
        public Spell Spur
        {
            get
            {
                return _spur ??
                       (_spur =
                           new Spell
                           {
                               Name = "Spur",
                               ID = 183,
                               Level = 45,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _enkindle;
        public Spell Enkindle
        {
            get
            {
                return _enkindle ??
                       (_enkindle =
                           new Spell
                           {
                               Name = "Enkindle",
                               ID = 184,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Cooldown,
                               CastType = CastType.Target
                           });
            }
        }
    }
}