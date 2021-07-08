using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Hearthstone_bot
{
    class Program
    {
        private static string status = "read";
        private static string token { get; set; } = "1650098968:AAFSuR92SXTQGJP2NfvYZftT5sovpsv7e4c";
        private static TelegramBotClient TG_client;

        static void Main(string[] args)
        {
            TG_client = new TelegramBotClient(token);
            TG_client.StartReceiving();
            TG_client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            TG_client.StopReceiving();

        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message.Text == "/start")
            {
                Console.WriteLine($"You have received a message with text: {message.Text}");
                var Sticker = await TG_client.SendStickerAsync(
                    chatId: message.Chat.Id,
                    sticker: "CAACAgIAAxkBAAECUkdgpnBwj1KctHV_Fcfjkd46L7O-rQACHgAD8N0EFJpi1XxaWXM8HwQ",
                    replyToMessageId: message.MessageId);

            }
            if (status.Equals("read"))
            {
                switch (message.Text)
                {

                    case "Стрим":
                        var sticker = await TG_client.SendStickerAsync(chatId: message.Chat.Id,
                                sticker: "https://cdn.tlgrm.ru/stickers/502/199/50219971-fa71-31e7-b850-2dfbcc7d4804/192/1.webp",
                                replyToMessageId: message.MessageId);
                        var streamer1 = await TG_client.SendTextMessageAsync(chatId: message.Chat.Id,
                                text: "https://www.youtube.com/channel/UCcPKNJknTYe6-tC5OyGl0ZQ" + "\n" + "https://www.twitch.tv/serg_heavybeard" +
                                "\nСтримера зовут обычно Серж, но можно по реальному имени Сергей.\nПрактически ежедневные стримы и не в позднее время." +
                                "\nОбщается со всеми зрителями в чате на обоих платформах Ютуб и Твич.",
                                replyToMessageId: message.MessageId,
                                replyMarkup: Buttons());
                        var streamer2 = await TG_client.SendTextMessageAsync(chatId: message.Chat.Id,
                            text: "https://www.youtube.com/channel/UC_7EMCIsl9xfQlvGTxAskgw" + "\n" + "https://www.twitch.tv/alliestrasza" +
                            "\nЭто англоязычная стримерша по HS. \nЗовут её Элли или можно по нику называть: Алекстраза." +
                            "\nИграет на высоких рангах.\nПравила стрима вы сможете найти по ссылке выше на Твиче!",
                            replyToMessageId: message.MessageId,
                            replyMarkup: Buttons());
                        var streamer3 = await TG_client.SendTextMessageAsync(chatId: message.Chat.Id,
                            text: "https://www.twitch.tv/silvername" + "\n" + "https://www.youtube.com/channel/UCqQrewSyOB-64dnwnL3FuCQ" +
                            "\nЕсли Вы уже долгое время играете в Hearthstone, то, возможно, слышали про такого стримера, как Сильвер." +
                            "\nСильвер (или же Влад) являлся одним из самых лучших игроков за последние годы." +
                            "\nОН собрал много престижных наград и выиграл немало турниров. Об этом вы сможете найти информацию по ссылке на Твич." +
                            "На данный момент Влад стримит сейчас только режим Battlegrounds.",
                            replyToMessageId: message.MessageId,
                            replyMarkup: Buttons());
                        break;


                    case "Получить карту":
                        var AnswerForButton = await TG_client.SendTextMessageAsync(chatId: message.Chat.Id,
                            text: "Перед вами команды /name, /class, /race, /quality. \nОни будут выдавать нужную Вам карту. Его нужно будет вводить по-английски." +
                            "\n/cardSet будет давать карту по ее дополнению (Whispers of the Old Gods...)" +
                            "\n/race будет давать карту по расе (Dragon, Pirate...)" +
                            "\n/quality будет давать карту по ее редкости (Common, Rare...)" +
                            "\nВсе команды, кроме /name включают ввод доп. данных, по типу cost или attack",
                            replyToMessageId: message.MessageId,
                            replyMarkup: Buttons());
                        break;


                    case "/name":
                        status = "card";
                        var card1 = await TG_client.SendTextMessageAsync(chatId: message.Chat.Id,
                            text: "Введите название карты:",
                            replyToMessageId: message.MessageId);
                        break;


                    case "/cardSet":
                        status = "card1";
                        var type = await TG_client.SendTextMessageAsync(chatId: message.Chat.Id,
                        text: "Введите дополнение:" +
                            "\nВведите здоровье карты карты:" +
                            "\nВведите стоимость карты:" +
                            "\nВведите атаку карты:",
                            replyToMessageId: message.MessageId);
                        break;


                    case "/race":
                        status = "card2";
                        var race = await TG_client.SendTextMessageAsync(chatId: message.Chat.Id,
                            text: "Введите расу карты:",
                            replyToMessageId: message.MessageId);
                        break;


                    case "/quality":
                        status = "card3";
                        var quality = await TG_client.SendTextMessageAsync(chatId: message.Chat.Id,
                            text: "Введите редкость карты:",
                            replyToMessageId: message.MessageId);
                        break;


                    case "Таблица топовых игроков":
                        var table = await TG_client.SendTextMessageAsync(chatId: message.Chat.Id,
                            text: "https://playhearthstone.com/ru-ru/community/leaderboards/?region=EU&leaderboardId=STD&seasonId=90" +
                            "\nПерейдя по этой ссылке вы сможете увидеть рейтинговую таблицу лучших " +
                            "200 игроков за разные сезоны в разных форматах и в разных регионах",
                            replyToMessageId: message.MessageId,
                            replyMarkup: Buttons());
                        break;


                    case "Новости":
                        var news = await TG_client.SendTextMessageAsync(chatId: message.Chat.Id,
                            text: "https://playhearthstone.com/ru-ru/news/patchnotes#articles" +
                            "\nПерейдя по этой ссылке, Вы сможете посмотреть все обновления, которые происходили с игрой",
                            replyToMessageId: message.MessageId,
                            replyMarkup: Buttons());
                        break;


                    case "Турниры":
                        var Tournaments = await TG_client.SendTextMessageAsync(chatId: message.Chat.Id,
                            text: "https://playhearthstone.com/ru-ru/esports/" +
                            "\nТут Вы сможете найти информацию о всех турнирах, которые проводяться в данный момент.",
                            replyToMessageId: message.MessageId,
                            replyMarkup: Buttons());
                        break;


                    case "Movies/Series":
                        status = "movie/series";
                        var something = await TG_client.SendTextMessageAsync(chatId: message.Chat.Id,
                            text: "Write a movie or series title",
                            replyToMessageId: message.MessageId);
                        break;


                    case "Witcher":

                        var WitcherAnswer = await TG_client.SendTextMessageAsync
                            (
                                chatId: message.Chat.Id,
                                text: "Here is a choice /witcherChar, /witcherMonster and /witcherQuest" +
                                "\n/witcherChar can find a character from the game The Witcher 3: Wild Hunt by their name. Just write it" +
                                "\n/witcherMonster can find information about a monster from the bestiari of The Witcher 3 by name" +
                                "\n/witcherQuest can find a quest with its info by the name",
                                replyToMessageId: message.MessageId,
                                replyMarkup: Buttons()
                            );
                        break;


                    case "/witcherChar":
                        status = "char";
                        var Witcher1 = await TG_client.SendTextMessageAsync
                            (
                                chatId: message.Chat.Id,
                                text: "Enter the name of a character:",
                                replyToMessageId: message.MessageId
                            );
                        break;

                    case "/witcherMonster":
                        status = "mon";
                        var Witcher2 = await TG_client.SendTextMessageAsync
                            (
                                chatId: message.Chat.Id,
                                text: "Enter the name of a monster:",
                                replyToMessageId: message.MessageId
                            );
                        break;

                    case "/witcherQuest":
                        status = "q";
                        var Witcher3 = await TG_client.SendTextMessageAsync
                            (
                                chatId: message.Chat.Id,
                                text: "Enter the name of an quest:",
                                replyToMessageId: message.MessageId
                            );
                        break;



                    default:
                        await TG_client.SendTextMessageAsync(message.Chat.Id, "Выберите команду: ", replyMarkup: Buttons());
                        break;
                }
            }


            else if (status.Equals("card"))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://localhost:5001/Hs/Name?Name={message.Text}"),

                };
                string HS;

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    HS = await response.Content.ReadAsStringAsync();

                }
                var text = CreateText(HS);
                status = "read";
                await TG_client.SendTextMessageAsync(message.Chat.Id,
                    text, replyToMessageId: message.MessageId);
            }


            else if (status.Equals("card1"))
            {
                string set;
                int cost, attack, health;
                string[] Str = message.Text.Split("\n");
                set = Str[0];
                health = int.Parse(Str[1]);
                cost = int.Parse(Str[2]);
                attack = int.Parse(Str[3]);

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://localhost:5001/Hs/cardSet?set={set}&cost={cost}&attack={attack}&health={health}")

                };
                string HS;

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    HS = await response.Content.ReadAsStringAsync();
                }
                var text = CreateText(HS);
                status = "read";
                await TG_client.SendTextMessageAsync(message.Chat.Id,
                    text, replyToMessageId: message.MessageId);

            }


            else if (status.Equals("movie/series"))
            {
                try
                {

                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri($"https://localhost:5001/M_and_S_/title?query={message.Text}")
                    };
                    string body;

                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        body = await response.Content.ReadAsStringAsync();
                    }
                    var text = MovieText(body);

                    status = "read";
                    await TG_client.SendTextMessageAsync(message.Chat.Id,
                        text, replyToMessageId: message.MessageId);
                }
                catch
                {
                    status = "read";
                    await TG_client.SendTextMessageAsync(message.Chat.Id,
                    text: "You have done something wrong. Try Again!",
                    replyToMessageId: message.MessageId);
                }
            }


            else if (status.Equals("char"))
            {
                try
                {

                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri($"https://localhost:5001/M_and_S_/name?name={message.Text}")
                    };

                    string body;

                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        body = await response.Content.ReadAsStringAsync();
                    }
                    var text = CharText(body);

                    status = "read";
                    await TG_client.SendTextMessageAsync(message.Chat.Id,
                        text, replyToMessageId: message.MessageId);
                }
                catch
                {
                    status = "read";
                    await TG_client.SendTextMessageAsync(message.Chat.Id,
                    text: "You have done something wrong. Try Again!",
                    replyToMessageId: message.MessageId);

                }
            }


            else if (status.Equals("mon"))
            {
                try
                {
                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri($"https://localhost:5001/M_and_S_/creatureName?name={message.Text}")
                    };

                    string body;

                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        body = await response.Content.ReadAsStringAsync();
                    }
                    var text = MonsterText(body);

                    status = "read";
                    await TG_client.SendTextMessageAsync(message.Chat.Id,
                        text, replyToMessageId: message.MessageId);
                }
                catch
                {
                    status = "read";
                    await TG_client.SendTextMessageAsync(message.Chat.Id,
                    text: "You have done something wrong. Try Again!",
                    replyToMessageId: message.MessageId);
                }
            }
            else if (status.Equals("q"))
            {
                try
                {
                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri($"https://localhost:5001/M_and_S_/questName?name={message.Text}")
                    };

                    string body;

                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        body = await response.Content.ReadAsStringAsync();
                    }
                    var text = QuestText(body);

                    status = "read";
                    await TG_client.SendTextMessageAsync(message.Chat.Id,
                        text, replyToMessageId: message.MessageId);
                }
                catch
                {
                    status = "read";
                    await TG_client.SendTextMessageAsync(message.Chat.Id,
                    text: "You have done something wrong. Try Again!",
                    replyToMessageId: message.MessageId);
                }
            }

            static IReplyMarkup Buttons()
            {
                return new ReplyKeyboardMarkup
                {
                    Keyboard = new List<List<KeyboardButton>>
                    {
                    new List<KeyboardButton>{new KeyboardButton {Text="Получить карту"}, new KeyboardButton {Text="Стрим"}},
                    new List<KeyboardButton>{new KeyboardButton {Text="Таблица топовых игроков"}, new KeyboardButton {Text="Новости"} },
                    new List<KeyboardButton>{new KeyboardButton {Text="Турниры"}, new KeyboardButton { Text = "Movies/Series" } },
                    new List<KeyboardButton>{new KeyboardButton { Text="Witcher"} }
                    }
                };
            }

        }
        public static string CreateText(string Json)
        {
            var obj = JsonConvert.DeserializeObject<Card>(Json);
            string result = $"Name: {obj.name} \n" +
                $"Type: {obj.type}\n"+$"Rarity: {obj.rarity}\n"+$"Cost: {obj.cost}\n"+$"Attack: {obj.attack}\n"+$"Health: {obj.health}\n" +
                $"Image: {obj.img}\n";

            return result;
        }
        
        public static string MovieText(string json)
        {
            var objective = JsonConvert.DeserializeObject<IMDbModelForFilms>(json);
            string resultat = $"Название: {objective.results[0].title}\n" + $"Тип: {objective.results[0].titleType}\n" + $"Год выпуска: {objective.results[0].year}\n" 
                + $"Продолжительность: {objective.results[0].runningTimeInMinutes} минуты\n" + $"Постер: {objective.results[0].image.url}";
            return resultat;
        }




        public static string CharText(string js)
        {
            var obj = JsonConvert.DeserializeObject<List<WitcherCharacter>>(js);
            string result = $"Name: {obj[0].name}\n"+
                $"Gender: {obj[0].gender}\n"+
                $"Race: {obj[0].race}\n"+
                $"Profession: {obj[0].profession}\n"+
                $"Image: {obj[0].image}";
            return result;
        }

        public static string MonsterText(string js)
        {
            var obj = JsonConvert.DeserializeObject<List<Info>>(js);
            string result = $"Name: {obj[0].name}\n" +
                $"Immunity: {obj[0].immunity}\n" +
                $"What will help against them: {obj[0].susceptibility}\n" +
                $"Image: {obj[0].image}";
            return result;
        }

        public static string QuestText(string js)
        {
            var obj = JsonConvert.DeserializeObject<List<QuestInfo>>(js);
            string result = $"Name: {obj[0].name}\n\n" +
                $"Type of the quest (main / secondary): {obj[0].type}\n\n" +
                $"Location of the action: {obj[0].location}\n\n" +
                $"Required level: {obj[0].level}\n\n" +
                $"Involved characters: {obj[0].characters}";
            return result;
        }
    }
}
