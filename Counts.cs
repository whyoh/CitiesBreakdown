using System.Collections.Generic;
using System.Linq;

namespace Breakdown
{
    public class Counts<T>
    {
        public readonly Dictionary<T, uint> Counters = new Dictionary<T, uint>();

        public void Add(T value)
        {
            if (!this.Counters.ContainsKey(value))
            {
                this.Counters[value] = 0;
            }
            this.Counters[value]++;
        }

        public IEnumerable<T> Keys => this.Counters.Keys;

        public int Total => Enumerable.Sum(this.Counters.Values.Select(x => (int)x));

        public override string ToString()
        {
            string result = string.Concat(this.Counters.Take(3).Select(x => $"{x.Key}:{x.Value}").ToArray());
            if (this.Keys.Count() > 3)
            {
                result += "...";
            }
            return result;
        }
    }
}
