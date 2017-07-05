using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLS_TextParser
{
    public class TLSSortedPair: IComparable<TLSSortedPair>
    {
        private string tls;
        private int count;

        public TLSSortedPair(KeyValuePair<string, int> pair)
        {
            tls = pair.Key;
            count = pair.Value;
        }

        public TLSSortedPair(string tls, int count)
        {
            this.tls = tls;
            this.count = count;
        }

        public int CompareTo(TLSSortedPair other)
        {
            int comparison = -1 * count.CompareTo(other.GetCount());

            if (comparison != 0)
            {
                return comparison;
            }
            else
            {
                return tls.CompareTo(other.tls);
            }
        }

        public int GetCount()
        {
            return count;
        }

        public string GetTLS()
        {
            return tls;
        }

        public override string ToString()
        {
            return tls + ", " + count;
        }
    }
}
