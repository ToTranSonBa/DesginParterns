using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight.Implements
{
    public class Character : ICharacter
    {
        private readonly char _symbol;

        public Character(char symbol)
        {
            _symbol = symbol;
        }

        public void Display(int x, int y)
        {
            Console.WriteLine(
                $"{_symbol} at ({x},{y})");
        }
    }
}
