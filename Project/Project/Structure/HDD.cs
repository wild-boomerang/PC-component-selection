using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class HDD : ComputerPart
    {
        private string formFactor;
        private string connectionInterface;
        private int volume; // GB
        private int spindleRotationSpeed;// rpm
        private int bufferSize; // MB

        public string FormFactor { get => formFactor; set => formFactor = value; }
        public string ConnectionInterface { get => connectionInterface; set => connectionInterface = value; }
        public int Volume { get => volume; set => volume = value; }
        public int SpindleRotationSpeed { get => spindleRotationSpeed; set => spindleRotationSpeed = value; }
        public int BufferSize { get => bufferSize; set => bufferSize = value; }
    }
}
