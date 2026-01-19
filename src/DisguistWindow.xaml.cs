using System;
using System.Linq;
using System.Threading;
using System.Windows;
using Aspenlaub.Net.GitHub.CSharp.Disguist.Components;
using Aspenlaub.Net.GitHub.CSharp.Disguist.Entities;
using Aspenlaub.Net.GitHub.CSharp.Disguist.Interfaces;
using Autofac;

namespace Aspenlaub.Net.GitHub.CSharp.Disguist;

/// <summary>
/// Interaction logic for DisguistWindow.xaml
/// </summary>
// ReSharper disable once UnusedMember.Global
public partial class DisguistWindow {
    private readonly IContainer vContainer;
    private readonly Lock vLockObject = new();

    public DisguistWindow() {
        InitializeComponent();
        vContainer = new ContainerBuilder().UseDisguistAndPegh().Build();
        Title = Properties.Resources.WindowTitle;
    }

    private void Window_Initialized(object sender, EventArgs e) {
        Word.Focus();
        SetButtonAccess();
    }

    private void SetButtonAccess() {
        CopyButton.IsEnabled = DisguistWord.Text.Length != 0;
    }

    private async void Word_PasswordChangedAsync(object sender, RoutedEventArgs e) {
        WordDisguiserResult result = await vContainer.Resolve<IWordDisguiser>().DisguiseWordAsync(Word.Password);
        if (result.Errors.Any()) {
            throw new Exception(string.Join("\r\n", result.Errors));
        }
        lock (vLockObject) {
            DisguistWord.Text = result.DisguisedWord;
            SetButtonAccess();
        }
    }

    private void CopyButton_OnClick(object sender, RoutedEventArgs e) {
        Clipboard.SetText(DisguistWord.Text);
    }
}