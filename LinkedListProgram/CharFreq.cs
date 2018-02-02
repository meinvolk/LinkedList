using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListProgram
{
    public class CharFreq
    {
        private char _ch;
        private int _freq;
        
        //Defauly constructor which accepts a character value.
        public CharFreq(char c)
        {
            Ch = c;
            Freq = 1;
        }

        //Character can only be set by the default constructor.
        protected char Ch
        {
            get { return _ch; }
            set { _ch = value; }
        }

        //Frequency is only every modified by the Increment() method.
        protected int Freq
        {
            get { return _freq; }
            set { _freq = value; }
        }

        /// <summary>
        /// Increment the frequency of a character that appears in a txt document.
        /// </summary>
        /// <returns></returns>
        public int Increment()
        {
            return Freq++;
        }

        /// <summary>
        /// Overridden Equals method to compare two CharFreq's character values.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            CharFreq cf = (CharFreq)obj;

            return _ch.Equals(cf.Ch);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return _ch.GetHashCode();
        }

        public override string ToString()
        {
            return $"Character: {_ch} ASCII: ({(int)_ch}) Frequency: {_freq}";
        }
    }
}
