// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ContentConverter.Content;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContentConverter
{
    public class Converter : CommandLineParser
    {
        private const string s_ContentFile = "ContentFile";
        private const string s_BotInfoFile = "BotInfoFile";
        private const string s_BotId = "BotId";

        protected override Dictionary<string, string> RequiredArguments => new Dictionary<string, string>
        {
            { "-c", s_ContentFile },
            { "-i", s_BotInfoFile },
            { "-b", s_BotId }
        };

        /// <summary>
        /// Converts Bot Intents to LU format
        /// </summary>
        /// <param name="config">configuration that includes arugment params for this process</param>
        protected override void ProcessInternal(IConfiguration config)
        {
            string inputBotInfoFile = config[s_BotInfoFile];

            Console.WriteLine("Processing... \n");
            try
            {
                if(readCSVBotInformation(config[s_BotInfoFile], config[s_BotId], out var botContentid)
                   && readCSVContent(config[s_ContentFile], botContentid, out var rawContent))
                {
                    BotContent botContent = JsonConvert.DeserializeObject<BotContent>(rawContent);
                    LuFileGenerator luisFileGenerator = new LuFileGenerator();
                    foreach (var intent in botContent.Intents)
                    {
                        luisFileGenerator.AddIntent(intent.DisplayName, intent.TriggerQueries);
                    }

                    if (File.Exists($"{Directory.GetCurrentDirectory()}\\Content.lu"))
                    {
                        Console.Write("File Already exists overwriting current Content.lu file... \n");
                    }

                    File.WriteAllText($"{Directory.GetCurrentDirectory()}\\Content.lu", luisFileGenerator.ToString());
                }
                else
                {
                    if(string.IsNullOrEmpty(botContentid))
                    {
                        throw new Exception("Bot Id was not found");
                    }else
                    {
                        throw new Exception("Bot content was not found");
                    }
                }
            }
            catch(Exception e)
            {
                Console.Write(e.ToString());
            }
            Console.WriteLine("Done\n");
        }

        /// <summary>
        /// Extract Bot Content based on content Id
        /// </summary>
        /// <param name="file">content file</param>
        /// <param name="botContentId">bot content id that maps to bot content</param>
        /// <param name="rawContent">decoded base 64 bot content (out value )</param>
        /// <returns></returns>
        private bool readCSVContent(string file, string botContentId, out string rawContent)
        {
            Console.WriteLine("Reading Bot Content... \n");
            rawContent = string.Empty;
            botContentId = UpdateContentId(botContentId);
            using (var reader = new StreamReader(file))
            {
                bool header = true;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if(!header)
                    {
                        if(string.Equals(botContentId, values[9], StringComparison.OrdinalIgnoreCase))
                        {
                            // filter content artifacts
                            var content = values[2].Substring(25, values[2].Length - 31);
                            // decode content
                            rawContent = Encoding.UTF8.GetString(Convert.FromBase64String(content));
                            return true;
                        }
                    }
                    else
                    {
                        header = false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Read Bot information to extract content id based on the bot id provided
        /// </summary>
        /// <param name="file">file that contains bot information</param>
        /// <param name="botId">bot id to lookup bot content Id</param>
        /// <param name="botContentId">content id for that belongs your botId (out value)</param>
        /// <returns></returns>
        private bool readCSVBotInformation(string file, string botId, out string botContentId)
        {
            Console.WriteLine("Reading Bot Information... \n");
            botContentId = string.Empty;
            using (var reader = new StreamReader(file))
            {
                bool header = true;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (!header)
                    {
                        if (string.Equals(botId, values[2], StringComparison.OrdinalIgnoreCase))
                        {
                            botContentId = values[1];
                            return true;
                        }
                    }
                    else
                    {
                        header = false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Update ContentId to increment 2nd digit by 1
        /// Temporary Solution
        /// </summary>
        /// <param name="contentId">content Id</param>
        /// <returns>udpated content Id</returns>
        private string UpdateContentId(string contentId)
        {
            StringBuilder strBuilder = new StringBuilder(contentId);
            var intHex = int.Parse(strBuilder[1].ToString(), System.Globalization.NumberStyles.HexNumber) + 1;
            strBuilder.Remove(1, 1);
            strBuilder.Insert(1, intHex.ToString("X").ToLower());
            return strBuilder.ToString();
        }
    }
}
