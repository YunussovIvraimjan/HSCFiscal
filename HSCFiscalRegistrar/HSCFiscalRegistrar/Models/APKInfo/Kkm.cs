using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HSCFiscalRegistrar.Models.APKInfo
{
    public class Kkm
    {
        public string Id { get; set; }
        public string SerialNumber { get; set; }
        [JsonProperty("PointOfPaymentNumber")]
        public string PointOfPayment { get; set; }
        public string FnsKkmId { get; set; }
        public string TerminalNumber { get; set; }
    }
}