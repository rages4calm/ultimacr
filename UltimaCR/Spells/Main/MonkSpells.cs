
namespace UltimaCR.Spells.Main
{
    public class MonkSpells : PugilistSpells
    {
        private CrossClass.MonkSpells.Crossclass _crossClass;
        public new CrossClass.MonkSpells.Crossclass CrossClass
        {
            get { return _crossClass ?? (_crossClass = new CrossClass.MonkSpells.Crossclass()); }
        }

        private PVP.MonkSpells.Pvp _pvp;
        public new PVP.MonkSpells.Pvp PvP
        {
            get { return _pvp ?? (_pvp = new PVP.MonkSpells.Pvp()); }
        }

        private Spell _rockbreaker;
        public Spell Rockbreaker
        {
            get
            {
                return _rockbreaker ??
                       (_rockbreaker =
                           new Spell
                           {
                               Name = "Rockbreaker",
                               ID = 70,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _shouldertackle;
        public Spell ShoulderTackle
        {
            get
            {
                return _shouldertackle ??
                       (_shouldertackle =
                           new Spell
                           {
                               Name = "Shoulder Tackle",
                               ID = 71,
                               Level = 35,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Interrupt,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _fistsoffire;
        public Spell FistsOfFire
        {
            get
            {
                return _fistsoffire ??
                       (_fistsoffire =
                           new Spell
                           {
                               Name = "Fists of Fire",
                               ID = 63,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Aura,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _oneilmpunch;
        public Spell OneIlmPunch
        {
            get
            {
                return _oneilmpunch ??
                       (_oneilmpunch =
                           new Spell
                           {
                               Name = "One Ilm Punch",
                               ID = 72,
                               Level = 45,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Debuff,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _dragonkick;
        public Spell DragonKick
        {
            get
            {
                return _dragonkick ??
                       (_dragonkick =
                           new Spell
                           {
                               Name = "Dragon Kick",
                               ID = 74,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Flank,
                               CastType = CastType.Target
                           });
            }
        }
    }
}