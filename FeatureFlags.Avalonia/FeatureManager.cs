using System.Collections.Generic;

namespace FeatureFlags.Avalonia
{
    public static partial class FeatureManager
    {
        private static readonly Dictionary<string, bool> Features = new Dictionary<string, bool>();

        private static void SetFeatureEnabled(string featureName, bool isEnabled)
        {
            Features[featureName] = isEnabled;
        }

        public static bool IsFeatureEnabled(string featureName)
        {
            return Features.TryGetValue(featureName, out var isEnabled) && isEnabled;
        }
        
    }
}