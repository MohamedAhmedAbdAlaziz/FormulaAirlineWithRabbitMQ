namespace FormulaAirline.API.Services
{
    public interface IMessageProducer
    {
        public Task SendingMessage<T>(T message);
    }
}
