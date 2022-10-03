using EasyNetQ;

namespace SubMessage
{
    [Queue("testqueue", ExchangeName = "")]
    public class SubTextMessage
    {
        public string Text { get; set; }
    }
}