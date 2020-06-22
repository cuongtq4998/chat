using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MopoPOC.Services.Mode
{

    public class ApiResponseDto
    {
        [JsonProperty("ReturnCode")]
        public int ReturnCode { get; set; }

        [JsonProperty("ReturnMessage")]
        public string ReturnMessage { get; set; }

    }

    public class ApiResponseDto<T>
    {
        [JsonProperty("ReturnCode")]
        public int ReturnCode { get; set; }

        [JsonProperty("ReturnMessage")]
        public string ReturnMessage { get; set; }

        [JsonProperty("Data")]
        public T Data { get; set; }
    }

    public class ApiResponseListDto<T>
    {
        [JsonProperty("ReturnCode")]
        public int ReturnCode { get; set; }

        [JsonProperty("ReturnMessage")]
        public string ReturnMessage { get; set; }

        [JsonProperty("Data")]
        public IEnumerable<T> Data { get; set; }
    }

}
