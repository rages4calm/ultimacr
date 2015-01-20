
namespace UltimaCR.Spells.Main
{
    public class PaladinSpells : GladiatorSpells
    {
        private CrossClass.PaladinSpells.Crossclass _crossClass;
        public new CrossClass.PaladinSpells.Crossclass CrossClass
        {
            get { return _crossClass ?? (_crossClass = new CrossClass.PaladinSpells.Crossclass()); }
        }

        private PVP.PaladinSpells.Pvp _pvp;
        public new PVP.PaladinSpells.Pvp PvP
        {
            get { return _pvp ?? (_pvp = new PVP.PaladinSpells.Pvp()); }
        }

        private Spell _swordoath;
        public Spell SwordOath
        {
            get
            {
                return _swordoath ??
                       (_swordoath =
                           new Spell
                           {
                               Name = "Sword Oath",
                               ID = 26,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Aura,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _cover;
        public Spell Cover
        {
            get
            {
                return _cover ??
                       (_cover =
                           new Spell
                           {
                               Name = "Cover",
                               ID = 27,
                               Level = 35,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Defensive,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _shieldoath;
        public Spell ShieldOath
        {
            get
            {
                return _shieldoath ??
                       (_shieldoath =
                           new Spell
                           {
                               Name = "Shield Oath",
                               ID = 28,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Aura,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _spiritswithin;
        public Spell SpiritsWithin
        {
            get
            {
                return _spiritswithin ??
                       (_spiritswithin =
                           new Spell
                           {
                               Name = "Spirits Within",
                               ID = 29,
                               Level = 45,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Interrupt,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _hallowedground;
        public Spell HallowedGround
        {
            get
            {
                return _hallowedground ??
                       (_hallowedground =
                           new Spell
                           {
                               Name = "Hallowed Ground",
                               ID = 30,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Defensive,
                               CastType = CastType.Self
                           });
            }
        }
    }
}