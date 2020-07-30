using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public class Computer
    {
        private double price;
        private double weight;
        private CPU cpu;
        private Motherboard motherboard;
        private VideoCard videoCard;
        private RAM ram;
        private HDD hdd;
        private PowerSupply powerSupply;
        private Case computerCase;
        private string imageSource;

        public double Price { get => price; set => price = value; }
        public double Weight { get => weight; set => weight = value; }
        internal CPU Cpu { get => cpu; set => cpu = value; }
        internal Motherboard Motherboard { get => motherboard; set => motherboard = value; }
        internal VideoCard VideoCard { get => videoCard; set => videoCard = value; }
        internal RAM Ram { get => ram; set => ram = value; }
        internal HDD Hdd { get => hdd; set => hdd = value; }
        internal PowerSupply PowerSupply { get => powerSupply; set => powerSupply = value; }
        internal Case ComputerCase { get => computerCase; set => computerCase = value; }
        public string ImageSource { get => imageSource; set => imageSource = value; }

        //public IEnumerator GetEnumerator()
        //{

        //}
    }
}
