using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern.Implements
{
    public class Computer
    {
        public string CPU { get; }
        public string RAM { get; }
        public string Storage { get; }
        public string GPU { get; }
        public bool HasWifi { get; }

        internal Computer(string cpu, string ram, string storage, string gpu, bool hasWifi)
        {
            CPU = cpu;
            RAM = ram;
            Storage = storage;
            GPU = gpu;
            HasWifi = hasWifi;
        }

        public override string ToString()
        {
            return $"CPU: {CPU}, RAM: {RAM}, Storage: {Storage}, GPU: {GPU}, Wifi: {HasWifi}";
        }
    }
}
