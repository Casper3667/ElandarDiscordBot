using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using Weather;

namespace DiscordBot
{
    public class BotProgram
    {
        static DiscordClient discord;
        static CommandsNextModule commands;
        static InteractivityModule Interactivity;

        async void StartAsync()
        {
            // await MessageWriteAsync("This is a test");
        }

        public async Task MessageWriteAsync(string text)
        {
            // string text = Console.ReadLine();
            await SendMessage(text);
        }

        async Task SendMessage(string v)
        {
            // TODO: Give a channel for general messages
            // DiscordChannel channel = await discord.GetChannelAsync();
            // await discord.SendMessageAsync(channel, v);
        }
        public async Task GenerateWeather()
        {
            // TODO: Give a channel for weather messages
            // DiscordChannel channel = await discord.GetChannelAsync();
            // await discord.SendMessageAsync(channel, WeatherGenerator.WeatherReport());
        }
        public static void StartBot()
        {
            secondMain(null);
        }
        public static void secondMain(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                // TODO: Insert a new token
                // Token = 
                TokenType = TokenType.Bot
            });

            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().StartsWith("!ping"))
                    await e.Message.RespondAsync("pong!");
            };


            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "!"
            });

            Interactivity = discord.UseInteractivity(new InteractivityConfiguration
            {
                
            });

            commands.RegisterCommands<DiscordBot>();
            // commands.RegisterCommands<Wiki>();
            // commands.RegisterCommands<FactionCommands>();

            await discord.ConnectAsync();
            while (true)
            {
                BotProgram foo = new BotProgram();
                foo.StartAsync();
            }
            // await Task.Delay(-1);
            
        }
    }
}