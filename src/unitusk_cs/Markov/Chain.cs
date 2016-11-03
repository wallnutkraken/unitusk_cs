using System;
using System.Collections.Generic;

namespace unitusk_cs.Markov
{
    internal class Chain
    {
        private Dictionary<string, List<string>> _chain;
        private int PrefixLength { get; }

        internal Chain(int prefixLen)
        {
            _chain = new Dictionary<string, List<string>>();
            PrefixLength = prefixLen;
        }

        /// <summary>
        /// Reads text from the provided string and
        /// parses it into prefixes and suffixes that are stored in Chain.
        /// </summary>
        /// <param name="text">Text to eat</param>
        public void Feed(string text)
        {
            string[] lines = text.Split(' ', '\n', '\t', '\r');
            Prefix pref = new Prefix(PrefixLength);
            foreach (string line in lines)
            {
                string key = pref.ToString();
                _chain[key].Add(line);
                pref.Shift(line);
            }
        }

        /// <summary>
        /// Returns a string of at most <paramref name="n"/> words generated from Chain.
        /// </summary>
        /// <param name="n">Max number of words to return</param>
        public string Generate(int n)
        {
            Prefix pref = new Prefix(PrefixLength);
            List<string> words = new List<string>();
            int rngSeed = (int) DateTime.Now.Ticks;

            for (int i = 0; i < n; i++)
            {
                List<string> choices = _chain[pref.ToString()];
                if (choices.Count == 0)
                    break;
                string next = choices[new Random(rngSeed++).Next(choices.Count)];
                words.Add(next);
                pref.Shift(next);
            }

            return string.Join(" ", words);
        }
    }
}
