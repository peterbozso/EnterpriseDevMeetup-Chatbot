using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseDevMeetup_Chatbot_3.Dialogs
{
    [LuisModel("your credentials", "come here")]
    [Serializable]
    public partial class RootLuisDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Sorry, I did not understand '{result.Query}'.");
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Question")]
        public async Task Question(IDialogContext context, LuisResult result)
        {
            await context.Forward(new QnADialog(), ResumeAfterQnA, context.Activity, CancellationToken.None);
        }

        private async Task ResumeAfterQnA(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hi!");
            await context.PostAsync("I am FlightBot. I can help you with buying a plane ticket or answering your questions.");
            await context.PostAsync("What can I do for you?");
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Buy")]
        public async Task Buy(IDialogContext context, LuisResult result)
        {
            var city = result.Entities.FirstOrDefault((entity) => entity.Type == "city")?.Entity;
            var date = GetDateFromLuisResult(result);

            if (city == null || date == null)
            {
                await context.PostAsync("Sorry, I didn't get that! Could you rephrase it please?");
            }
            else
            {
                await context.PostAsync($"Okay, let me just go ahead and buy you a ticket to {city} on {date?.ToString("dd.MM.yyyy")}");
            }

            context.Wait(this.MessageReceived);
        }

        private DateTime? GetDateFromLuisResult(LuisResult result)
        {
            var dateString = ((Dictionary<string, object>)((List<object>)result.Entities.FirstOrDefault((entity) => entity.Type == "builtin.datetimeV2.date")?.Resolution?["values"])?.FirstOrDefault())?["value"] as string;

            DateTime date;
            var haveDate = DateTime.TryParse(dateString, out date);

            if (haveDate)
            {
                return date;
            }

            return null;
        }
    }
}