using System;
using Newtonsoft.Json;

namespace ChatBot.Services.Models
{
    public class SendChatReponseDto
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("result")]
        public ResultSendChatReponseDto result { get; set; }

        [JsonProperty("sessionId")]
        public string sessionId { get; set; }

        [JsonProperty("timestamp")]
        public string timestamp { get; set; }


        [JsonProperty("status")]
        public StatusSendChatReponseDto status { get; set; }
    }

    public class ResultSendChatReponseDto
    {
        [JsonProperty("source")]
        public string source { get; set; }

        [JsonProperty("resolvedQuery")]
        public string resolvedQuery { get; set; }

        [JsonProperty("action")]
        public string action { get; set; }

        [JsonProperty("actionIncomplete")]
        public bool actionIncomplete { get; set; }

        [JsonProperty("score")]
        public float score { get; set; }

        [JsonProperty("contexts")]
        public ContextsSendChatReponseDto[] contexts { get; set; }

        [JsonProperty("metadata")]
        public MetadataSendChatReponseDto metadata { get; set; }

        [JsonProperty("fulfillment")]
        public FulfillmentSendChatReponseDto fulfillment { get; set; }
    }

    public class ContextsSendChatReponseDto
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("lifespan")]
        public int lifespan { get; set; }
    }
    public class MetadataSendChatReponseDto
    {
        [JsonProperty("intentId")]
        public string intentId { get; set; }

        [JsonProperty("intentName")]
        public string intentName { get; set; }

        [JsonProperty("webhookUsed")]
        public bool webhookUsed { get; set; }

        [JsonProperty("webhookForSlotFillingUsed")]
        public bool webhookForSlotFillingUsed { get; set; }

        [JsonProperty("isFallbackIntent")]
        public bool isFallbackIntent { get; set; }
    }

    public class FulfillmentSendChatReponseDto
    {
        [JsonProperty("intspeechentId")]
        public string intspeechentId { get; set; }

        [JsonProperty("messages")]
        public MessagesSendChatReponseDto[] messages { get; set; }



    }
    public class MessagesSendChatReponseDto
    {
        [JsonProperty("lang")]
        public string lang { get; set; }

        [JsonProperty("type")]
        public int type { get; set; }

        [JsonProperty("speech")]
        public string speech { get; set; }
    }
    public class StatusSendChatReponseDto
    {
        [JsonProperty("code")]
        public int code { get; set; }

        [JsonProperty("errorType")]
        public string errorType { get; set; }


    }


}
