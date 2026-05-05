using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern.Implements
{
    public class ComputerBuilder
    {
        private string? _cpu;
        private string? _ram;
        private string? _storage;
        private string? _gpu;
        private bool _hasWifi;

        public ComputerBuilder SetCPU(string cpu)
        {
            _cpu = cpu;
            return this;
        }

        public ComputerBuilder SetRAM(string ram)
        {
            _ram = ram;
            return this;
        }

        public ComputerBuilder SetStorage(string storage)
        {
            _storage = storage;
            return this;
        }

        public ComputerBuilder SetGPU(string gpu)
        {
            _gpu = gpu;
            return this;
        }

        public ComputerBuilder EnableWifi()
        {
            _hasWifi = true;
            return this;
        }

        public Computer Build()
        {
            // Validation
            if (string.IsNullOrEmpty(_cpu))
                throw new Exception("CPU is required");

            if (string.IsNullOrEmpty(_ram))
                throw new Exception("RAM is required");

            if (string.IsNullOrEmpty(_storage))
                throw new Exception("Storage is required");

            return new Computer(_cpu, _ram, _storage, _gpu, _hasWifi);
        }
    }
}
