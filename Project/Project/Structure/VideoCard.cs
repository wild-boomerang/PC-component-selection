using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Project
{
    [Table("Videocards")]
    public class VideoCard : ComputerPart
    {
        private string GPUManufacturer;
        private string typeOfVideoMemory;
        private int videoMemoryCapacity; // MB
        private int videoBus; // mb
        private double GPUFrequency; // GHz
        private double memoryFrequency; // GHz
        private string powerConnectors;

        public VideoCard()
        {
            WhoIs = computerParts.VIDEOCARD;
        }

        public string GPUManufacturer1 { get => GPUManufacturer; set => GPUManufacturer = value; }
        public string TypeOfVideoMemory { get => typeOfVideoMemory; set => typeOfVideoMemory = value; }
        public int VideoMemoryCapacity { get => videoMemoryCapacity; set => videoMemoryCapacity = value; }
        public int VideoBus { get => videoBus; set => videoBus = value; }
        public double GPUFrequency1 { get => GPUFrequency; set => GPUFrequency = value; }
        public double MemoryFrequency { get => memoryFrequency; set => memoryFrequency = value; }
        public string PowerConnectors { get => powerConnectors; set => powerConnectors = value; }
    }
}
