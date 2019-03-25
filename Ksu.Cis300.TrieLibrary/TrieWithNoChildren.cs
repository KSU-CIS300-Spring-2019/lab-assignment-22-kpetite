using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        private bool _isEmpty = false;

        public ITrie Add(string s)
        {
            if (s == "")
            {
                _isEmpty = true;
                return this;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else
            {
                return new TrieWithOneChild(s, _isEmpty);
            }
        }

        public bool Contains(string s)
        {
            if (s == "")
            {
                return _isEmpty;
            }
            else
            {
                return false;
            }
        }
    }
}
