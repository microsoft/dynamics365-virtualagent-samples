// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace ContentConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Converter converter = new Converter();
            converter.Process(args);

            Console.WriteLine("Press Any Key To Terminate...");
            Console.ReadLine();
        }
    }
}
