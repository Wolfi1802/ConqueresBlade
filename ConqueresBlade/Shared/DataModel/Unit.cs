using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConqueresBlade.Shared.DataModel
{
    public class Unit
    {
        public string Name { get; set; }
        public string Acquisition { get; set; }
        public string Type { get; set; }
        public string Era { get; set; }
        public string Health { get; set; }
        public string Strength { get; set; }
        public string Leadership { get; set; }
        public string Speed { get; set; }
        public string Range { get; set; }
        public string Ammo { get; set; }
        public string Labour { get; set; }
        public string MaxLevel { get; set; }
        public string PiercingAP { get; set; }
        public string PiercingDMG { get; set; }
        public string PiercingDEF { get; set; }
        public string SlashingAP { get; set; }
        public string SlashingDMG { get; set; }
        public string SlashingDEF { get; set; }
        public string BluntAP { get; set; }
        public string BluntDMG { get; set; }
        public string BluntDEF { get; set; }
        public List<string> TerrainEffects { get; set; } = new();//5 und 5
        public List<(string, string)> Path1 { get; set; } = new();
        public List<(string, string)> Path2 { get; set; } = new();
        public List<(string, string)> Path3 { get; set; } = new();
        public List<(string, string)> Path4 { get; set; } = new();
    }
}
