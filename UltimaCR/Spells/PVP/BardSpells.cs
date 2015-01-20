
namespace UltimaCR.Spells.PVP
{
    public class BardSpells
    {
        public class Pvp
        {
            private Spell _blastshot;
            public Spell BlastShot
            {
                get {
                    return _blastshot ??
                           (_blastshot =
                               new Spell
                               {
                                   Name = "Blast Shot",
                                   ID = 1570,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Knockback,
                                   CastType = CastType.Target
                               });
                }
            }
            private Spell _farshot;
            public Spell Farshot
            {
                get {
                    return _farshot ??
                           (_farshot =
                               new Spell
                               {
                                   Name = "Farshot",
                                   ID = 1569,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Cooldown,
                                   CastType = CastType.Target
                               });
                }
            }
            private Spell _manadraw;
            public Spell ManaDraw
            {
                get {
                    return _manadraw ??
                           (_manadraw =
                               new Spell
                               {
                                   Name = "Mana Draw",
                                   ID = 1583,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Buff,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _manasong;
            public Spell Manasong
            {
                get {
                    return _manasong ??
                           (_manasong =
                               new Spell
                               {
                                   Name = "Manasong",
                                   ID = 1568,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Buff,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _purify;
            public Spell Purify
            {
                get {
                    return _purify ??
                           (_purify =
                               new Spell
                               {
                                   Name = "Purify",
                                   ID = 1584,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Defensive,
                                   CastType = CastType.Self
                               });
                }
            }
        }
    }
}
