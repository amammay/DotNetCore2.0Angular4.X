﻿using System.IO;

namespace PsuApi.Tests
{
    public static class SampleDataHelper
    {

        private static readonly string SampleDataPath =
            Path.Combine(Path.GetDirectoryName(typeof(SampleDataHelper).Assembly.Location), "SampleData");

        private static string PathFor(string sampleFile)
        {
            return Path.Combine(SampleDataPath, sampleFile);
        }

        public static string GetContent(string fileName)
        {
            return File.ReadAllText(PathFor(fileName));
        }
    }
}
