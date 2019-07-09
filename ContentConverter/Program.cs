// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace ContentConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               Converter converter = new Converter();
               converter.Process(args);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error Occured : {e.ToString()}");
            }
            
            Console.WriteLine("Press Any Key To Terminate...");
            Console.ReadLine();
        }
    }
}
