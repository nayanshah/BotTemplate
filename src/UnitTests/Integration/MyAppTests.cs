using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApp.Main.Core;
using MyApp.Main.Models;

namespace MyApp.UnitTests.Integration
{
    [TestClass]
    public class MyAppTests
    {
        [TestMethod]
        public async Task ProcessMessage()
        {
            var appMessage = new AppMessage
            {
                Sender = "Buzz Lightyear",
                Text = "To infinity and beyond!",
            };

            var result = await new MessageProcessor().Process(appMessage);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains(appMessage.Sender));
            Assert.IsTrue(result.Contains(appMessage.Text));
        }
    }
}