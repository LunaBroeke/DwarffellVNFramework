using System;
using System.IO;
using System.Collections.Generic;

namespace Dwarffell.TextEngine
{
    public class Language
    {
        public Language()
        {

        }
        public Language(string code)
        {
            this.languageCode = code;
        }
        public string languageName = "English";
        public string languageCode = "en_NL";
        public System system = new System();
        public Name name = new Name();
        public Dialogue dialogue = new Dialogue();
        public Shop shop = new Shop();
        public class System
        {
            public string menu = "menu";
            public string pause = "pause";
            public string play = "play";
            public string save = "save";
            public string load = "load";
            public Credits credits = new Credits();
            public class Credits
            {
                public string dwarffell = "Luna Dwarffell";
                public string program = "Programming";
                public string art = "Artwork";
            }
        }
        public class Name
        {
            public string dwarffell = "Luna Dwarffell";
            public string celestia = "Celestia";
            public string lumine = "Lumine";
            public string serena = "Serena";
            public string ange = "Ange";
            public string maple = "Maple";
            public string bnuy = "bnuy";
            public List<string> bnuyNames = new List<string>()
            {
                "Bnuy",
            };
        }
        public class Dialogue
        {
            public string event_PrototypeEvent01_line01 = "The Forest of Magic - Planet Lumia - Day";
            public string event_PrototypeEvent01_line02 = "So what is the plan again?";
            public string event_PrototypeEvent01_line03 = "We lock in!";
            public string event_PrototypeEvent01_line04 = "What does that even mean?";
            public string event_PrototypeEvent01_line05 = "It means what it means.";
            public string event_PrototypeEvent01_line06 = "It barely makes any sense though.";
            public string event_PrototypeEvent02_set00_line01 = "The Abyss - Planet Lumia - Day";
            public string event_PrototypeEvent02_set00_line02 = "So you really live down here?";
            public string event_PrototypeEvent02_set00_choice01 = "\"Is there a problem, Ange?\"";
            public string event_PrototypeEvent02_set00_choice02 = "\"Yep! Born and raised underground!\"";
            public string event_PrototypeEvent02_set00_choice03 = "\"Pretty boring underground\"";
            public string event_PrototypeEvent02_set00_choice04 = "Stay silent";
            public string event_PrototypeEvent02_set01_line01 = "N-Not at all!";
            public string event_PrototypeEvent02_set02_line01 = "That's really cool!";
            public string event_PrototypeEvent02_set03_line01 = "I wouldn't say that.";
            public string event_PrototypeEvent02_set04_line01 = "...";
            public string event_PrototypeEvent02_set04_line02 = "I keep forgetting you don't talk much.";
            public string event_PrototypeEvent02_set00_line03 = "Its just that-";
            public string event_PrototypeEvent02_set00_line04 = "I grew up in a forest with the sun shining through the leaves.";
            public string event_PrototypeEvent02_set00_line05 = "I have a hard time imagining a civilization being completely under the surface.";
            public string event_PrototypeEvent02_set00_choice05 = "\"And you claimed you were open minded?\"";
            public string event_PrototypeEvent02_set00_choice06 = "Turn away and pout";
            public string event_PrototypeEvent02_set00_line06 = "Don't look so offended.";
        }
        public class Shop
        {
            public string shop = "Shop";
            public string health = "Bun-Aid";
            public string food = "Bnuy Food";
            public string happy = "Bnuynip";
            public string name = "Name Tag";
            public string seed = "Flower Seed";
            public string none = "None";
        }
        public class DevLog
        {
            public string entry1 = "";
        }
        public ErrorMessages errorMessages = new ErrorMessages();
        public class ErrorMessages
        {
            public string getError = "Big Boner down the lane";
        }
    }
}