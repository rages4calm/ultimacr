
namespace UltimaCR.Spells.PVP
{
    public class ScholarSpells
    {
        public class Pvp
        {
            private Spell _attunement;
            public Spell Attunement
            {
                get {
                    return _attunement ??
                           (_attunement =
                               new Spell
                               {
                                   Name = "Attunement",
                                   ID = 1585,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Defensive,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _aurablast;
            public Spell AuraBlast
            {
                get {
                    return _aurablast ??
                           (_aurablast =
                               new Spell
                               {
                                   Name = "Aura Blast",
                                   ID = 1577,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Knockback,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _focalization;
            public Spell Focalization
            {
                get {
                    return _focalization ??
                           (_focalization =
                               new Spell
                               {
                                   Name = "Focalization",
                                   ID = 1578,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Defensive,
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
