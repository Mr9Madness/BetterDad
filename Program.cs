using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace DadBot {
    public class Program {
        public static void Main (string[] args) => new Program ().MainAsync ().GetAwaiter ().GetResult ();

        public async Task MainAsync () {
            var client = new DiscordSocketClient ();

            client.Log += Log;
            client.MessageReceived += MessageReceived;

            string token = "NTMxOTEzMzIxNDUzMDYwMDk2.DxlOnQ.tGMWBEznjoa_RO_NHMtUjjXToao"; // Remember to keep this private!
            await client.LoginAsync (TokenType.Bot, token);
            await client.StartAsync ();

            // Block this task until the program is closed.
            await Task.Delay (-1);
        }
        private async Task MessageReceived (SocketMessage message) {
            if (message.Content.Contains ("I'm dad")) {
                await message.Channel.SendMessageAsync ("No you're not!");
            } else if (message.Content.Contains ("I'm")) {
                await message.Channel.SendMessageAsync ("Hi " + message.Content);
            }
        }
        private Task Log (LogMessage msg) {
            Console.WriteLine (msg.ToString ());
            return Task.CompletedTask;
        }
    }
}