using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Project
{
    [Table("Motherboards")]
    public class Motherboard : ComputerPart
    {
        private string socket;
        private string processorManufacturer;
        private string chipset;
        private string memoryType;
        private string formFactor;
        private int memorySlots;

        public Motherboard()
        {
            WhoIs = computerParts.MOTHERBOARD;
        }

        public string Socket { get => socket; set => socket = value; }
        public string ProcessorManufacturer { get => processorManufacturer; set => processorManufacturer = value; }
        public string Chipset { get => chipset; set => chipset = value; }
        public string MemoryType { get => memoryType; set => memoryType = value; }
        public string FormFactor { get => formFactor; set => formFactor = value; }
        public int MemorySlots { get => memorySlots; set => memorySlots = value; }
    }
}
