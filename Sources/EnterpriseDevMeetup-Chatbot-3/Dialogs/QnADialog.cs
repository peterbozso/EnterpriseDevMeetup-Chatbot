using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using System;

namespace EnterpriseDevMeetup_Chatbot_3.Dialogs
{
    [QnAMaker("your credentials", "come here")]
    [Serializable]
    public class QnADialog : QnAMakerDialog
    {
    }
}