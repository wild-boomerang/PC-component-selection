using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Project
{
    [Table("HDDs")]
    public class HDD : ComputerPart
    {
        private string formFactor;
        private string connectionInterface;
        private int volume; // GB
        private int spindleRotationSpeed;// rpm
        private int bufferSize; // MB

        public HDD()
        {
            WhoIs = computerParts.HDD;
        }

        public string FormFactor { get => formFactor; set => formFactor = value; }
        public string ConnectionInterface { get => connectionInterface; set => connectionInterface = value; }
        public int Volume { get => volume; set => volume = value; }
        public int SpindleRotationSpeed { get => spindleRotationSpeed; set => spindleRotationSpeed = value; }
        public int BufferSize { get => bufferSize; set => bufferSize = value; }
    }
}
