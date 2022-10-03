using EasyNetQ;

namespace Messages
{
    [Queue("testqueue", ExchangeName = "")]
    public class TextMessage
    {
        public string Text { get; set; }
    }
}