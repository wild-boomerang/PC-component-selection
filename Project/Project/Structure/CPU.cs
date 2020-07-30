using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Project
{
    [Table("CPUs")]
    public class CPU : ComputerPart
    {
        private string socket;
        private string crystalCodeName;
        private int numberOfCores;
        private int numberOfThreads;
        private string clockFrequency; // GHz
        private string turboFrequency; // GHz
        private string productionTechnology; // nm
        private string integratedGraphics;
        //private int Id;
        
        public CPU()
        {
            WhoIs = computerParts.CPU;
        }

        public string Socket { get => socket; set => socket = value; }
        public string CrystalCodeName { get => crystalCodeName; set => crystalCodeName = value; }
        public int NumberOfCores { get => numberOfCores; set => numberOfCores = value; }
        public int NumberOfThreads { get => numberOfThreads; set => numberOfThreads = value; }
        public string ClockFrequency { get => clockFrequency; set => clockFrequency = value; }
        public string TurboFrequency { get => turboFrequency; set => turboFrequency = value; }
        public string ProductionTechnology { get => productionTechnology; set => productionTechnology = value; }
        public string IntegratedGraphics { get => integratedGraphics; set => integratedGraphics = value; }
        //[PrimaryKey, AutoIncrement, Column("_id")]
        //public int Id1 { get => Id; set => Id = value; }
    }
}
