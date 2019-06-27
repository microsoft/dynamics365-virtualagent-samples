// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace ContentConverter.Content
{
    /// <summary>
    /// Generates Lu Down file based on intents and trigger phrases
    /// Checkout https://github.com/microsoft/botbuilder-tools/tree/master/packages/Ludown for more information 
    /// </summary>
    /// <example>
    /// # <intent-name1> 
    /// - trigger phrase 1
    /// - trigger phrase 2
    /// - trigger phrase 3
    /// - trigger phrase n
    /// # <intent-name2>
    /// - trigger phrase 1
    /// - trigger phrase 2
    /// - trigger phrase 3
    /// - trigger phrase n
    /// </example>
    public class LuFileGenerator
    {
        private IDictionary<string, IList<string>> Intents;

        /// <summary>
        /// Generates Luis File
        /// </summary>
        public LuFileGenerator()
        {
            Intents = new Dictionary<string, IList<string>>();
        }

        /// <summary>
        /// Add Intent and its trigger phrases
        /// </summary>
        /// <param name="intentName"> Intent name </param>
        /// <param name="triggerPhrases"> Trigger phrases for this intent </param>
        public void AddIntent(string intentName, IList<string> triggerPhrases)
        {
            if (!Intents.ContainsKey(intentName))
            {
                Intents.Add(intentName, triggerPhrases);
            }
        }

        /// <summary>
        /// Builds string in LU format
        /// </summary>
        /// <returns> LU format string</returns>
        public override string ToString()
        {
            Console.WriteLine("Converting Bot Intents to LU format... \n");

            StringBuilder stringBuilder = new StringBuilder();
            
            foreach(var intent in Intents)
            {
                stringBuilder.AppendLine($"# {intent.Key}");

                if(intent.Value != null)
                {
                    foreach(string triggerPhrase in intent.Value)
                    {
                        stringBuilder.AppendLine($"- {triggerPhrase}");
                    }
                }
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }
    }
}
