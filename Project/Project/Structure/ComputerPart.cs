using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class ComputerPart
    {
        private string manufacturer;
        private DateTime marketLaunchDate;
        private string modelName;
        private double price;

        private double height;
        private double width;
        private double depth;
        private double weight;

        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public DateTime MarketLaunchDate { get => marketLaunchDate; set => marketLaunchDate = value; }
        public string ModelName { get => modelName; set => modelName = value; }
        public double Price { get => price; set => price = value; }
        public double Height { get => height; set => height = value; }
        public double Width { get => width; set => width = value; }
        public double Depth { get => depth; set => depth = value; }
        public double Weight { get => weight; set => weight = value; }
    }
}
