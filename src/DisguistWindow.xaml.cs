using System;
using System.Linq;
using System.Windows;
using Aspenlaub.Net.GitHub.CSharp.Disguist.Components;

namespace Aspenlaub.Net.GitHub.CSharp.Disguist {
    /// <summary>
    /// Interaction logic for DisguistWindow.xaml
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public partial class DisguistWindow {
        private readonly WordDisguiser vWordDisguiser;

        public DisguistWindow() {
            InitializeComponent();
            vWordDisguiser = new WordDisguiser();
        }

        private void Window_Initialized(object sender, EventArgs e) {
            Word.Focus();
            SetButtonAccess();
        }

        private void SetButtonAccess() {
            CopyButton.IsEnabled = DisguistWord.Text.Length != 0;
        }

        private async void Word_PasswordChangedAsync(object sender, RoutedEventArgs e) {
            var result = await vWordDisguiser.DisguiseWordAsync(Word.Password);
            if (result.Errors.Any()) {
                throw new Exception(string.Join("\r\n", result.Errors));
            }
            DisguistWord.Text = result.DisguisedWord;
            SetButtonAccess();
        }

        private void CopyButton_OnClick(object sender, RoutedEventArgs e) {
            Clipboard.SetText(DisguistWord.Text);
        }
    }
}
