using System;
using Newtonsoft.Json;

namespace RokredUI.Models
{
    public class Category
    {
        [JsonProperty("guid")] public Guid Guid { get; set; }

        [JsonProperty("parentGiud")] public string ParentGiud { get; set; }

        [JsonProperty("isNew")] public bool IsNew { get; set; }

        [JsonProperty("name")] public string Name { get; set; }
        
        [JsonProperty("isSelected")] public bool IsSelected { get; set; }
    }
}