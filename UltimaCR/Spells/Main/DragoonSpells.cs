
namespace UltimaCR.Spells.Main
{
    public class DragoonSpells : LancerSpells
    {
        private CrossClass.DragoonSpells.Crossclass _crossClass;
        public new CrossClass.DragoonSpells.Crossclass CrossClass
        {
            get { return _crossClass ?? (_crossClass = new CrossClass.DragoonSpells.Crossclass()); }
        }

        private PVP.DragoonSpells.Pvp _pvp;
        public new PVP.DragoonSpells.Pvp PvP
        {
            get { return _pvp ?? (_pvp = new PVP.DragoonSpells.Pvp()); }
        }

        private Spell _jump;
        public Spell Jump
        {
            get
            {
                return _jump ??
                       (_jump =
                           new Spell
                           {
                               Name = "Jump",
                               ID = 92,
                               Level = 30,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Cooldown,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _elusivejump;
        public Spell ElusiveJump
        {
            get
            {
                return _elusivejump ??
                       (_elusivejump =
                           new Spell
                           {
                               Name = "Elusive Jump",
                               ID = 94,
                               Level = 35,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Knockback,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _spineshatterdive;
        public Spell SpineshatterDive
        {
            get
            {
                return _spineshatterdive ??
                       (_spineshatterdive =
                           new Spell
                           {
                               Name = "Spineshatter Dive",
                               ID = 95,
                               Level = 40,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Cooldown,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _powersurge;
        public Spell PowerSurge
        {
            get
            {
                return _powersurge ??
                       (_powersurge =
                           new Spell
                           {
                               Name = "Power Surge",
                               ID = 93,
                               Level = 45,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _dragonfiredive;
        public Spell DragonfireDive
        {
            get
            {
                return _dragonfiredive ??
                       (_dragonfiredive =
                           new Spell
                           {
                               Name = "Dragonfire Dive",
                               ID = 96,
                               Level = 50,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Cooldown,
                               CastType = CastType.Target
                           });
            }
        }
    }
}