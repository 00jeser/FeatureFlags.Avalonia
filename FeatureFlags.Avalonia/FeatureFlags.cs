using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;

namespace FeatureFlags.Avalonia
{
    public static class FeatureFlags
    {
        public static readonly AttachedProperty<string> IsVisibleProperty =
            AvaloniaProperty.RegisterAttached<Control, string>(
                "IsVisible", typeof(FeatureFlags), "", false, BindingMode.OneTime, FeatureNameValidate, IsVisibleFeatureNameChanged);

        private static string IsVisibleFeatureNameChanged(AvaloniaObject arg1, string arg2)
        {
            if (arg1 is Control control)
                control.IsVisible = FeatureManager.IsFeatureEnabled(arg2);
            return arg2;
        }

        public static readonly AttachedProperty<string> IsActiveProperty =
            AvaloniaProperty.RegisterAttached<Control, string>(
                "IsActive", typeof(FeatureFlags), "", false, BindingMode.OneTime, FeatureNameValidate, IsEnableFeatureNameChanged);

        private static string IsEnableFeatureNameChanged(AvaloniaObject arg1, string arg2)
        {
            if (arg1 is Control control)
                control.IsEnabled = FeatureManager.IsFeatureEnabled(arg2);
            return arg2;
        }


        public static string GetIsVisible(Control control) => control.GetValue(IsVisibleProperty);
        public static void SetIsVisible(Control control, string value) => control.SetValue(IsVisibleProperty, value);

        public static string GetIsActive(Control control) => control.GetValue(IsActiveProperty);
        public static void SetIsActive(Control control, string value) => control.SetValue(IsActiveProperty, value);
        
        private static bool FeatureNameValidate(string arg)
        {
            return true;
        }
    }
}