// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace ContentConverter
{
    public abstract class CommandLineParser
    {
        /// <summary>
        /// A collection of arguments that are required to be passed over the command line.
        /// The key should be in the format "-{short string for argument name}". The value
        /// should be the full name of the argument. For example, { "-f", "InputFile" }.
        /// </summary>
        protected abstract Dictionary<string, string> RequiredArguments
        {
            get;
        }

        /// <summary>
        /// Print arguments for that command
        /// </summary>
        public void PrintArgs()
        {
            if (RequiredArguments != null)
            {
                Console.WriteLine("Required Args");
                foreach (var argument in RequiredArguments)
                {
                    Console.WriteLine($"{argument.Key} : { argument.Value}");
                }
            }
        }

        /// <summary>
        /// Process command line arguments that are passed over the command line.
        /// </summary>
        /// <param name="args">Raw arguments that are passed over the command line.</param>
        public void Process(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddCommandLine(args, RequiredArguments)
                .Build();

            // Verify that all of the required arguments are provided
            if (RequiredArguments != null)
            {
                foreach (var requiredArgument in RequiredArguments)
                {
                    if (string.IsNullOrEmpty(config[requiredArgument.Value]))
                    {
                        throw new Exception($"Missing required argument: {requiredArgument.Key}");
                    }
                }
            }

            ProcessInternal(config);
        }

        /// <summary>
        /// Run a command
        /// </summary>
        /// <param name="config">The parsed command line arguments.</param>
        protected abstract void ProcessInternal(IConfiguration config);
    }
}
