using ScadaApp.Services.Interfaces;
using System.Threading.Tasks;

namespace ScadaApp.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
