using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class RAM : ComputerPart
    {
        private string type;
        private int volume; // MB
        private double frequency; // GHz
        private string PCIndex;
        private string timings;

        public string Type { get => type; set => type = value; }
        public int Volume { get => volume; set => volume = value; }
        public double Frequency { get => frequency; set => frequency = value; }
        public string PCIndex1 { get => PCIndex; set => PCIndex = value; }
        public string Timings { get => timings; set => timings = value; }
    }
}
