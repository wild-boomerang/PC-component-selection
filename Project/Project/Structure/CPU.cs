using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class CPU : ComputerPart
    {
        private string socket;
        private string crystalCodeName;
        private int numberOfCores;
        private int numberOfThreads;
        private double clockFrequency; // GHz
        private double turboFrequency; // GHz
        private int productionTechnology; // nm
        private string integratedGraphics;

        public string Socket { get => socket; set => socket = value; }
        public string CrystalCodeName { get => crystalCodeName; set => crystalCodeName = value; }
        public int NumberOfCores { get => numberOfCores; set => numberOfCores = value; }
        public int NumberOfThreads { get => numberOfThreads; set => numberOfThreads = value; }
        public double ClockFrequency { get => clockFrequency; set => clockFrequency = value; }
        public double TurboFrequency { get => turboFrequency; set => turboFrequency = value; }
        public int ProductionTechnology { get => productionTechnology; set => productionTechnology = value; }
        public string IntegratedGraphics { get => integratedGraphics; set => integratedGraphics = value; }
    }
}
