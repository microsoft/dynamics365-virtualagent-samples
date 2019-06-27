// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace ContentConverter.Content
{
    /// <summary>
    /// Intent schema for this converter.
    /// </summary>
    public class BotIntent
    {
        public BotIntent()
        {
            TriggerQueries = new List<string>();
        }

        public IList<string> TriggerQueries { get; set; }
        public string DisplayName { get; set; }
    }
}
