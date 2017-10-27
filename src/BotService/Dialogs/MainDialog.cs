using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using MyApp.Main.Core;

namespace MyApp.BotService.Dialogs
{
    [Serializable]
    public class MainDialog : IDialog<object>
    {
        [NonSerialized]
        private static readonly IMessageProcessor _messageProcessor = new MessageProcessor();

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            try
            {
                var msg = await argument;

                var appMessage = msg.AsAppMessage();

                string result = await _messageProcessor.Process(appMessage);

                await context.PostAsync(result);
            }
            catch (Exception e)
            {
                await context.PostAsync($"Unexpected error. If this continues please reply with 'feedback :: {e.Message}'");
            }

            context.Wait(MessageReceivedAsync);
        }
    }
}