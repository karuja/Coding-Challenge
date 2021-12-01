using Newtonsoft.Json;
using System;

namespace Coding_Challenge.Common.Dto
{
    public class VisitorsDto
    {
        [JsonProperty("number-of-Visitors")]
        public int NVisitors { get; set; }

        public string Url { get; set; }

        public override bool Equals(object obj)
        {
            return obj is VisitorsDto visitors &&
                Url == visitors.Url &&
                NVisitors == visitors.NVisitors;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Url);
            hash.Add(NVisitors);
            return hash.ToHashCode();
        }
    }
}