﻿using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace BetterDad
{
    public class Program
    {
        private DiscordSocketClient _client;

        public static void Main() => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            var _config = new DiscordSocketConfig { MessageCacheSize = 100 };
            _client = new DiscordSocketClient(_config);
            _client.MessageReceived += MessageReceived;

            const string token  = "DISCORD_TOKEN"; // Remember to keep this private!
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private async Task MessageReceived(SocketMessage message)
        {
            string content = message.Content.ToLower();

            if ((content.StartsWith("i'm ") || content.StartsWith("i ") || content.StartsWith("im ")) && content.Contains("fuck"))
            {
                await message.Channel.SendMessageAsync("You better not be son!");
            }
            else if (content.Contains("fuck") || content.Contains("kys"))
            {
                await message.Channel.SendMessageAsync("I raised you better than this!");
            }
            else if (content.StartsWith("i'm dad") || content.StartsWith("i am dad") || content.StartsWith("im dad"))
            {
                await message.Channel.SendMessageAsync("No you're not, i'm dad! The best dad!!");
            }
            else if (content.StartsWith("i'm "))
            {
                await message.Channel.SendMessageAsync(content.Replace("i'm ", "Hi ") + ", I'm dad!");
            }
            else if (content.StartsWith("i am "))
            {
                await message.Channel.SendMessageAsync(content.Replace("i am ", "Hi ") + ", I'm dad!");
            }
            else if (content.StartsWith("im "))
            {
                await message.Channel.SendMessageAsync(content.Replace("im ", "Hi ") + ", I'm dad!");
            }
            else if (content.Contains("dad") && content.Contains("can i be"))
            {
                await message.Channel.SendMessageAsync("You sure can be" + content.Replace("dad", string.Empty).Replace("can i be", string.Empty).Replace("your", "my"));
            }
            else if (content.Contains("dad joke"))
            {
                var joke = GiveDadJoke();
                await message.Channel.SendMessageAsync(joke.Item1 + "\n" + joke.Item2);
            }
            else if (content.Contains("banaan"))
            {
                await message.Channel.SendMessageAsync("Lekkere warme hand!");
            }
        }

        private Tuple<string, string> GiveDadJoke()
        {
            Random rnd = new Random();
            switch (rnd.Next(15))
            {
                case 1: return new Tuple<string, string>("What time did the man go to the dentist?", "Tooth hurt-y.");
                case 0: return new Tuple<string, string>("My dad literally told me this one last week: 'Did you hear about the guy who invented Lifesavers?", "They say he made a mint.");
                case 2: return new Tuple<string, string>("A ham sandwich walks into a bar and orders a beer. Bartender says", "Sorry we don't serve food here.");
                case 3: return new Tuple<string, string>("Whenever the cashier at the grocery store asks my dad if he would like the milk in a bag he replies,", "No, just leave it in the carton!");
                case 4: return new Tuple<string, string>("Why do chicken coops only have two doors?", "Because if they had four, they would be chicken sedans!");
                case 5: return new Tuple<string, string>("Me: 'Dad, make me a sandwich!", "Dad: 'Poof, You’re a sandwich!");
                case 6: return new Tuple<string, string>("Why did the Clydesdale give the pony a glass of water?", "Because he was a little horse!");
                case 7: return new Tuple<string, string>("Me: 'Hey, I was thinking...", "My dad: 'I thought I smelled something burning.");
                case 8: return new Tuple<string, string>("How do you make a Kleenex dance?", "Put a little boogie in it!");
                case 9: return new Tuple<string, string>("Whenever we drive past a graveyard my dad says, 'Do you know why I can’t be buried there?' And we all say, 'Why not?", "Because I’m not dead yet!");
                case 10: return new Tuple<string, string>("Two peanuts were walking down the street.", "One was a salted.");
                case 11: return new Tuple<string, string>("I used to have a job at a calendar factory but I got the sack because I took a couple of days off.", null);
                case 12: return new Tuple<string, string>("How do you make holy water?", "You boil the hell out of it.");
                case 13: return new Tuple<string, string>("When I went to choir practice - Dad: 'Don’t forget a bucket.' Me: 'Why?", "To carry your tune.");
                case 14: return new Tuple<string, string>("Two guys walk into a bar, the third one ducks", null);
            }
            return null;
        }
    }
}
