// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace ContentConverter.Content
{
    /// <summary>
    /// Content schema for this converter.
    /// </summary>
    public class BotContent
    {
        public BotContent()
        {
            Intents = new List<BotIntent>();
        }

        public IList<BotIntent> Intents { get; set; }
    }
}
