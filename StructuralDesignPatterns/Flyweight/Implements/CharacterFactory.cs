using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight.Implements
{
    public class CharacterFactory
    {
        private readonly Dictionary<char, ICharacter> _characters = [];

        public ICharacter GetCharacter(char c)
        {
            if (!_characters.ContainsKey(c))
            {
                _characters[c] =
                    new Character(c);

                Console.WriteLine(
                    $"Creating {c}");
            }

            return _characters[c];
        }
    }
}
