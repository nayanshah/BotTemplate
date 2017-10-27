using System.Threading.Tasks;
using MyApp.Main.Models;

namespace MyApp.Main.Core
{
    public interface IMessageProcessor
    {
        Task<string> Process(AppMessage appMessage);
    }
}