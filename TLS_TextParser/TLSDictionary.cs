using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLS_TextParser
{
    public class TLSDictionary
    {
        public const string IncorrectLengthTLSMessage = "Attempted to add a TLS of incorrect size";

        private Dictionary<string, int> dictionary;

        public TLSDictionary()
        {
            dictionary = new Dictionary<string, int>();
        }

        public void IncrementTLS(string tls)
        {
            CheckTLSLength(tls);
            CheckAndIncrementEntry(tls);
        }

        private void CheckTLSLength(string tls)
        {
            if(tls.Length != 3)
            {
                throw new ArgumentException(IncorrectLengthTLSMessage);
            }
        }

        private void CheckAndIncrementEntry(string tls)
        {
            tls = tls.ToLower();

            if(dictionary.ContainsKey(tls))
            {
                IncrementEntry(tls);
            }
            else
            {
                dictionary.Add(tls, 1);
            }
        }

        private void IncrementEntry(string tls)
        {
            int newCount = dictionary[tls] + 1;
            dictionary.Remove(tls);
            dictionary.Add(tls, newCount);
        }

        public int GetCount(string tls)
        {
            try
            {
                int count = dictionary[tls];
                return count;
            }
            catch(KeyNotFoundException)
            {
                return 0;
            }
        }

        public List<string> GetTLSWithCount(int count)
        {
            List<string> tlsList = new List<string>();

            foreach(KeyValuePair<string, int> kvp in dictionary)
            {
                if(kvp.Value == count)
                {
                    tlsList.Add(kvp.Key);
                }
            }

            return tlsList;
        }

        public List<string> GetTopTLS(int n)
        {
            TLSTopN top10 = new TLSTopN(10);

            foreach (KeyValuePair<string, int> kvp in dictionary)
            {
                TLSSortedPair pair = new TLSSortedPair(kvp);
                top10.AddNew(pair);
            }

            return top10.GetTopN();
        }
    }
}
