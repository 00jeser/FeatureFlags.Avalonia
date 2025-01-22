using System;
using System.Collections.Generic;
using System.IO;
using Avalonia;

namespace FeatureFlags.Avalonia
{
    public static partial class FeatureManager
    {
        public static AppBuilder UseIniForFeatureFlags(this AppBuilder bld, string filePath, bool throwNotFoundException = false)
        {
            try
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var parts = line.Split('=');
                    if (parts.Length != 2) continue;
                    if (parts[1].Trim(' ', '\t', '\n', '\r', '"', '\'') == "true" || 
                        parts[1].Trim(' ', '\t', '\n', '\r', '"', '\'') == "1") 
                        SetFeatureEnabled(parts[0], true);
                    if (parts[1].Trim(' ', '\t', '\n', '\r', '"', '\'') == "false" || 
                        parts[1].Trim(' ', '\t', '\n', '\r', '"', '\'') == "0")
                        SetFeatureEnabled(parts[0], false);
                }
            }
            catch (FileNotFoundException e)
            {
                if(throwNotFoundException) throw;
            }
            return bld;
        }
        public static AppBuilder UseJsonForFeatureFlags(this AppBuilder bld, string filePath, bool throwNotFoundException = false)
        {
            try
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var parts = line.Split(':');
                    if (parts.Length != 2) continue;
                    if (parts[1].Trim(' ', '\t', '\n', '\r', '"', '\'', ',') == "true" || 
                        parts[1].Trim(' ', '\t', '\n', '\r', '"', '\'', ',')  == "1") 
                        SetFeatureEnabled(parts[0].Trim(' ', '\t', '\n', '\r', '"', '\'', ','), true);
                    if (parts[1].Trim(' ', '\t', '\n', '\r', '"', '\'', ',') == "false" || 
                        parts[1].Trim(' ', '\t', '\n', '\r', '"', '\'', ',')  == "0")
                        SetFeatureEnabled(parts[0].Trim(' ', '\t', '\n', '\r', '"', '\'', ','), false);
                }
            }
            catch (FileNotFoundException e)
            {
                if(throwNotFoundException) throw;
            }
            return bld;
        }
        public static AppBuilder UseDicionaryForFeatureFlags(this AppBuilder bld, Dictionary<string, bool> flags)
        {
            foreach (var flag in flags)
            {
                SetFeatureEnabled(flag.Key, flag.Value);
            }
            return bld;
        }
    }
}