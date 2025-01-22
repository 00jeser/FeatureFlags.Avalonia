using System.Threading;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace SampleApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if(FeatureFlags.Avalonia.FeatureManager.IsFeatureEnabled("Feature3"))
            Thread.CurrentThread.Abort();
    }
}