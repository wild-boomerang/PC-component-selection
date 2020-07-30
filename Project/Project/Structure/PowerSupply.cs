using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class PowerSupply : ComputerPart
    {
        private int power; // W
        private string certificate_80_PLUS;
        private int efficiency; // %
        private string motherboardPower;
        private int maximumLineCurrent_12V; // A
        private bool modularPowerCableConnection;
        private int fanSize; // mm

        public int Power { get => power; set => power = value; }
        public string Certificate_80_PLUS { get => certificate_80_PLUS; set => certificate_80_PLUS = value; }
        public int Efficiency { get => efficiency; set => efficiency = value; }
        public string MotherboardPower { get => motherboardPower; set => motherboardPower = value; }
        public int MaximumLineCurrent_12V { get => maximumLineCurrent_12V; set => maximumLineCurrent_12V = value; }
        public bool ModularPowerCableConnection { get => modularPowerCableConnection; set => modularPowerCableConnection = value; }
        public int FanSize { get => fanSize; set => fanSize = value; }
    }
}
