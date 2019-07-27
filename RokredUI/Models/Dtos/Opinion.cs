using System;
using Newtonsoft.Json;

namespace RokredUI.Models
{
    public class Opinion
    {
        [JsonProperty("guid")] public Guid Guid { get; set; }

        [JsonProperty("myOpinion")] public string MyOpinion { get; set; }

        [JsonProperty("opinionThread")] public Guid? OpinionThread { get; set; }

        [JsonProperty("position")] public long Position { get; set; }
    }
}