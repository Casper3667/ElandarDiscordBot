using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;
using Weather;

namespace DiscordBot
{
    class DiscordBot
    {

        [Command("test")]
        public async Task Test(CommandContext ctx)
        {
            await ctx.RespondAsync($"This is a test.");
        }

        [Command("hi")]
        public async Task Hi(CommandContext ctx)
        {

            await ctx.RespondAsync($"👋 Hi, {ctx.User.Mention}!");
            var interactivity = ctx.Client.GetInteractivityModule();
            var msg = await interactivity.WaitForMessageAsync(xm => xm.Author.Id == ctx.User.Id && xm.Content.ToLower() == "how are you?", TimeSpan.FromMinutes(1));
            if (msg != null)
                await ctx.RespondAsync($"I'm fine, thank you!");    
        }

        [Command("random"), Description("Give it two numbers, it will pick a random number between them.")]
        public async Task Random(CommandContext ctx, int min, int max)
        {
            var rnd = new Random();
            await ctx.RespondAsync($"🎲 Your random number is: {rnd.Next(min, max)}");
        }

        /*
        [Command("r"), Aliases("roll"), Description("It is a dice command, really.\n2d6kh1, keeps highest\n1d6ad, advantage, rolls twice and keeps highest")]
        public async Task Roll(CommandContext ctx, string die, string text = "")
        {
            string silence = "";

            if (text == "")
            {
                silence = "";
            }
            else
            {
                silence = " #";
            }
            RollResult result = Roller.Roll(die);
            await ctx.RespondAsync($"" + result + silence + text);
        }
        */

        [Command("noble"), Description("Mentions what title is appropriate for what rank of nobility."), Aliases("nobility", "rank", "ranks")]
        public async Task Nobility(CommandContext ctx)
        {
            await ctx.RespondAsync($"How to address non-peerage titles:\n>>> - 'Baronet' for Baronet\n- 'Sir' for Knight\n- 'Mister' for Gentleman");
        }

        [Command("rumor"), Description("Suggests some tips for when solving rumors."), Aliases("Rumor", "Rumors", "rumors"), Hidden]
        public async Task Rumor(CommandContext ctx)
        {
            await ctx.RespondAsync($"Tips in case you get stuck during a rumor search:" +
                $"\n>>> - Knowledge rolls are always possible in some way. Perhaps you know somebody who knows?" +
                $"\n- There are often witnesses, it is a rumor after all. Ask people" +
                $"\n- It isn't unusual for there to be a scene. Checking it out might net something worthwhile" +
                $"\n- Stuck on a part? The DM might be able to give a hint" +
                $"\n- Rumors don't have to be done alone. Talk to other characters, maybe they have ideas or an ability to help" +
                $"\n- Rolls aren't everything either. Logic and being detailed in the RP can improve chances greatly to find new and useful information" +
                $"\n- Are you in a scene where there might be something? Check it out and interact with the different elements to find clues. While a roll might help there might also be some things that can't be found by just using dice");
        }

        [Command("cute")]
        public async Task Cute(CommandContext ctx)
        {
            var rnd = new Random();
            var nxt = rnd.Next(0, 2);

            switch (nxt)
            {
                case 0:
                    await ctx.RespondAsync($"Who's cute? You're cute!");
                    return;

                case 1:
                    await ctx.RespondAsync($"Kobolds are adorable!");
                    return;

                case 2:
                    await ctx.RespondAsync($"Have a sugar glider: <https://i.imgur.com/QNz9VrC.jpg>");
                    return;
            }
        }

        [Command("shutdown")]
        public async Task Shutdown(CommandContext ctx)
        {
            // TODO: Pick an user it reacts this way to
            if (ctx.User.Mention == "<@>")
            {
                await ctx.RespondAsync($"Shutting down.");
                System.Environment.Exit(1);
            }
            else
            {
                await ctx.RespondAsync($"You are not my master.");
            }
        }

        [Command("update"), Hidden]
        public async Task Update(CommandContext ctx)
        {
            // TODO: Pick an user it reacts this way to
            if (ctx.User.Mention == "<@>")
            {
                await ctx.RespondAsync($"Shutting down for updates.");
                System.Environment.Exit(1);
            }
            else
            {
                await ctx.RespondAsync($"You are not my master.");
            }
        }

        [Command("master"), Hidden]
        public async Task Master(CommandContext ctx)
        {
            // TODO: Pick an user it reacts this way to
            if (ctx.User.Mention == "<@>" || ctx.User.Mention == "<@>")
            {
                await ctx.RespondAsync($"Abuse detected :angry:");
            }
            else if (ctx.User.Mention == "<@>")
            {
                await ctx.RespondAsync($"<@!> is my master.");
            }
            else
            {
                await ctx.RespondAsync($"{ctx.User.Mention} is not my master.");
            }
        }
        
        [Command("weather")]
        public async Task Weather(CommandContext ctx)
        {
            // weatherGenerator.WeatherReport();
            await ctx.RespondAsync(WeatherGenerator.WeatherReport());
            
        }
    }
}