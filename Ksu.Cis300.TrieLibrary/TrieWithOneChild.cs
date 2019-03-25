using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// whether the trie contains the empty string or not 
        /// </summary>
        private bool _isEmpty;

        /// <summary>
        /// the starting child 
        /// </summary>
        private ITrie _childOne;

        /// <summary>
        /// the label of the only child defined above
        /// </summary>
        private char _childLabel;

        public TrieWithOneChild(string label, bool isEmpty)
        {

            if (label == "" || label[0] < 'a' || label[0] > 'z')
            {
                throw new ArgumentException();
            }
            else
            {
                _isEmpty = isEmpty;
                _childLabel = label[0];
                _childOne = new TrieWithNoChildren().Add(label.Substring(1));
            }
        }

        /// <summary>
        /// Adds new ITrie
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
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
                if (s[0] == _childLabel)
                {
                    _childOne = _childOne.Add(s.Substring(1));
                    return this;
                }
                else
                {
                    return new TrieWithManyChildren(s, _isEmpty, _childLabel, _childOne);
                }
            }
        }

        /// <summary>
        /// Checks to see if the trie contains a given string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _isEmpty; 
            }
            else if (s[0] == _childLabel)
            {    
                return _childOne.Contains(s.Substring(1)); 
            } 
            else
            {
                return false;
            }
            
        }
    }
}
