using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace unitusk_cs.Markov
{
    internal class Prefix
    {
        internal string[] Strings { get; }
        private int Len { get; }

        internal Prefix(int len)
        {
            Strings = new string[len];
            Len = len;
        }

        public override string ToString()
        {
            return string.Join(" ", Strings);
        }

        /// <summary>
        /// Removes the first word from the Prefix and appends the given <paramref name="word"/>
        /// </summary>
        internal void Shift(string word)
        {
            for (int i = 1; i < Len; i++)
                Strings[i - 1] = Strings[i];
            Strings[Len - 1] = word;
        }
    }
}
