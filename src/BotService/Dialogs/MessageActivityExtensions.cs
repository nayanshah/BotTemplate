using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Teams;
using MyApp.Main.Models;

namespace MyApp.BotService.Dialogs
{
    public static class MessageActivityExtensions
    {
        public static AppMessage AsAppMessage(this IMessageActivity activity)
        {
            var message = activity.GetTextWithoutMentions().Trim();

            var appMessage = new AppMessage
            {
                Sender = activity.From.Name,
                Text = message,
            };

            return appMessage;
        }
    }
}