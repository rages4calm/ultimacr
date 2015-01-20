
namespace UltimaCR.Spells.Main
{
    public class BlackMageSpells : ThaumaturgeSpells
    {
        private CrossClass.BlackMageSpells.Crossclass _crossClass;
        public new CrossClass.BlackMageSpells.Crossclass CrossClass
        {
            get { return _crossClass ?? (_crossClass = new CrossClass.BlackMageSpells.Crossclass()); }
        }

        private PVP.BlackMageSpells.Pvp _pvp;
        public new PVP.BlackMageSpells.Pvp PvP
        {
            get { return _pvp ?? (_pvp = new PVP.BlackMageSpells.Pvp()); }
        }

        private Spell _convert;
        public Spell Convert
        {
            get
            {
                return _convert ??
                       (_convert =
                           new Spell
                           {
                               Name = "Convert",
                               ID = 158,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _freeze;
        public Spell Freeze
        {
            get
            {
                return _freeze ??
                       (_freeze =
                           new Spell
                           {
                               Name = "Freeze",
                               ID = 159,
                               Level = 35,
                               GCDType = GCDType.On,
                               SpellType = SpellType.OnLocation,
                               CastType = CastType.Location
                           });
            }
        }
        private Spell _apocatastasis;
        public Spell Apocatastasis
        {
            get
            {
                return _apocatastasis ??
                       (_apocatastasis =
                           new Spell
                           {
                               Name = "Apocatastasis",
                               ID = 160,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Defensive,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _manawall;
        public Spell Manawall
        {
            get
            {
                return _manawall ??
                       (_manawall =
                           new Spell
                           {
                               Name = "Manawall",
                               ID = 161,
                               Level = 45,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Defensive,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _flare;
        public Spell Flare
        {
            get
            {
                return _flare ??
                       (_flare =
                           new Spell
                           {
                               Name = "Flare",
                               ID = 162,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Cooldown,
                               CastType = CastType.Target
                           });
            }
        }
    }
}