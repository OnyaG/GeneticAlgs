using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgs
{
    public class RandomEx : Random
    {
        private uint _boolBits;

        public RandomEx() : base() { }
        public RandomEx(int seed) : base(seed) { }

        public bool NextBoolean()
        {
            _boolBits >>= 1;
            if (_boolBits <= 1) _boolBits = (uint)~this.Next();
            return (_boolBits & 1) == 0;
        }
    }

    public static class RandomBool
    {
        static RandomEx _randomBool = new RandomEx();
        public static bool GetRandomBool()
        {
            return _randomBool.NextBoolean();
        }
    }
}
