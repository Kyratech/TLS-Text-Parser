using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TLS_TextParser
{
    public class TLSTopN
    {
        private SortedSet<TLSSortedPair> topN;
        private int maxSize;

        public TLSTopN(int n)
        {
            topN = new SortedSet<TLSSortedPair>();
            maxSize = n;
        }

        public void AddNew(TLSSortedPair pair)
        {
            topN.Add(pair);

            if (topN.Count > maxSize)
            {
                topN.Remove(topN.Last());
            }
        }

        public List<string> GetTopN()
        {
            List<string> topNStrings = new List<string>();

            foreach (TLSSortedPair pair in topN)
            {
               topNStrings.Add(pair.ToString());
            }

            return topNStrings;
        }
    }
}
