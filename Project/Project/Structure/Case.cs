using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Project
{
    [Table("Cases")]
    public class Case : ComputerPart
    {
        private string type;
        private string material;
        private bool powerSupply;
        private string motherboardFormFactor;
        private int maxVideoCardLength; // mm
        private int maxProcessorCoolerHeight; // mm
        private bool transparentWindow;
        private string powerSupplyLocation;
        private string liquidCoolingSupport;

        public Case()
        {
            WhoIs = computerParts.CASE;
        }

        public string Type { get => type; set => type = value; }
        public string Material { get => material; set => material = value; }
        public bool PowerSupply { get => powerSupply; set => powerSupply = value; }
        public string MotherboardFormFactor { get => motherboardFormFactor; set => motherboardFormFactor = value; }
        public int MaxVideoCardLength { get => maxVideoCardLength; set => maxVideoCardLength = value; }
        public int MaxProcessorCoolerHeight { get => maxProcessorCoolerHeight; set => maxProcessorCoolerHeight = value; }
        public bool TransparentWindow { get => transparentWindow; set => transparentWindow = value; }
        public string PowerSupplyLocation { get => powerSupplyLocation; set => powerSupplyLocation = value; }
        public string LiquidCoolingSupport { get => liquidCoolingSupport; set => liquidCoolingSupport = value; }
    }
}
