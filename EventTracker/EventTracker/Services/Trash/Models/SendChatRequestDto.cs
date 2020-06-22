using System;
using Newtonsoft.Json;

namespace ChatBot.Services.Models
{
    public class SendChatRequestDto
    {

        [JsonProperty("context")]
        public string[] context { get; set; }

        [JsonProperty("lang")]
        public string lang { get; set; }

        [JsonProperty("query")]
        public string query { get; set; }

        [JsonProperty("sessionId")]
        public string sessionId { get; set; }

        [JsonProperty("timwezone")]
        public string timwezone { get; set; }
    }
}
