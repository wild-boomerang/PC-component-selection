using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Project
{
    //[Table("CPUs")]
    public class ComputerPart
    {
        private string manufacturer;
        private /*DateTime*/ string marketLaunchDate;
        private string modelName;
        private double price;
        private int Id;
        private computerParts whoIs;
        private string imageSource;

        private double height;
        private double width;
        private double depth;
        private double weight;

        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public /*DateTime*/ string MarketLaunchDate { get => marketLaunchDate; set => marketLaunchDate = value; }
        public string ModelName { get => modelName; set => modelName = value; }
        public double Price { get => price; set => price = value; }
        public double Height { get => height; set => height = value; }
        public double Width { get => width; set => width = value; }
        public double Depth { get => depth; set => depth = value; }
        public double Weight { get => weight; set => weight = value; }
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id1 { get => Id; set => Id = value; }
        public string ImageSource { get => imageSource; set => imageSource = value; }
        public computerParts WhoIs { get => whoIs; set => whoIs = value; }
    }

    public enum computerParts
    {
        CPU, RAM, VIDEOCARD, MOTHERBOARD, HDD, CASE, POWERSUPPLY
    }
}
