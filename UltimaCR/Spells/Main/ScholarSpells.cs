﻿
namespace UltimaCR.Spells.Main
{
    public class ScholarSpells : ArcanistSpells
    {
        private CrossClass.ScholarSpells.Crossclass _crossClass;
        public new CrossClass.ScholarSpells.Crossclass CrossClass
        {
            get { return _crossClass ?? (_crossClass = new CrossClass.ScholarSpells.Crossclass()); }
        }

        private PVP.ScholarSpells.Pvp _pvp;
        public new PVP.ScholarSpells.Pvp PvP
        {
            get { return _pvp ?? (_pvp = new PVP.ScholarSpells.Pvp()); }
        }

        private Spell _whisperingdawn;
        public Spell WhisperingDawn
        {
            get
            {
                return _whisperingdawn ??
                       (_whisperingdawn =
                           new Spell
                           {
                               Name = "Whispering Dawn",
                               ID = 33,
                               Level = 4,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _silentdusk;
        public Spell SilentDusk
        {
            get
            {
                return _silentdusk ??
                       (_silentdusk =
                           new Spell
                           {
                               Name = "Silent Dusk",
                               ID = 37,
                               Level = 15,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _feycovenant;
        public Spell FeyCovenant
        {
            get
            {
                return _feycovenant ??
                       (_feycovenant =
                           new Spell
                           {
                               Name = "Fey Covenant",
                               ID = 34,
                               Level = 20,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _feyglow;
        public Spell FeyGlow
        {
            get
            {
                return _feyglow ??
                       (_feyglow =
                           new Spell
                           {
                               Name = "Fey Glow",
                               ID = 38,
                               Level = 20,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _adloquium;
        public Spell Adloquium
        {
            get
            {
                return _adloquium ??
                       (_adloquium =
                           new Spell
                           {
                               Name = "Adloquium",
                               ID = 185,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Heal,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _succor;
        public Spell Succor
        {
            get
            {
                return _succor ??
                       (_succor =
                           new Spell
                           {
                               Name = "Succor",
                               ID = 186,
                               Level = 35,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Heal,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _feyillumination;
        public Spell FeyIllumination
        {
            get
            {
                return _feyillumination ??
                       (_feyillumination =
                           new Spell
                           {
                               Name = "Fey Illumination",
                               ID = 35,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _feylight;
        public Spell FeyLight
        {
            get
            {
                return _feylight ??
                       (_feylight =
                           new Spell
                           {
                               Name = "Fey Light",
                               ID = 39,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _leeches;
        public Spell Leeches
        {
            get
            {
                return _leeches ??
                       (_leeches =
                           new Spell
                           {
                               Name = "Leeches",
                               ID = 187,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Defensive,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _sacredsoil;
        public Spell SacredSoil
        {
            get
            {
                return _sacredsoil ??
                       (_sacredsoil =
                           new Spell
                           {
                               Name = "Sacred Soil",
                               ID = 188,
                               Level = 45,
                               GCDType = GCDType.On,
                               SpellType = SpellType.OnLocation,
                               CastType = CastType.Location
                           });
            }
        }
        private Spell _lustrate;
        public Spell Lustrate
        {
            get
            {
                return _lustrate ??
                       (_lustrate =
                           new Spell
                           {
                               Name = "Lustrate",
                               ID = 189,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Heal,
                               CastType = CastType.Target
                           });
            }
        }
    }
}