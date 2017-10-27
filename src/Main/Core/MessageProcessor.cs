using System.Threading.Tasks;
using MyApp.Main.Models;

namespace MyApp.Main.Core
{
    public class MessageProcessor : IMessageProcessor
    {
        public Task<string> Process(AppMessage appMessage)
        {
            // Do stuff

            return Task.FromResult($"{appMessage.Sender} says {appMessage.Text}");
        }
    }
}