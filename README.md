# EnterpriseDevMeetup-Chatbot
https://www.meetup.com/Enterprise-Developer-Meetup/events/246861083/

A 2018. január 31-én tartott Enterprise Developer Meetupon bemutatott "Chatbotok a gyakorlatban" című előadás diái és példakódjai.

A forráskód a Sources mappában található, a három demo projekt egy solution alá gyűjtve.

Az egyes projektekhez szükséges, kiexportált LUIS fájlok (számozva) a LUIS mappában találhatóak, ezeket egy új LUIS alkalmazásba importálva ki lehet próbálni a példákat. (Importálás: Új LUIS app létrehozása -> Settings -> Oldal alján "Import new version" gomb)

A demo során használt QnA Maker app kiexportált tudásbázisa ugyanígy megtalálható a QnAMaker mappában. Ez szintén importálás után kipróbálható egy új QnA Maker appon keresztül. (Importálás: Új QnA Maker app létrehozása -> Settings -> Files/Select a file...)

A kipróbáláshoz létrehozott LUIS és QnA Maker appok kulcsait a megfelelő forrásfájlokba behelyettesítve lehet működésre bírni a példakódokat.

A kipróbáláshoz ajánlott a Bot Framework Emulator használata: https://github.com/Microsoft/BotFramework-Emulator/releases