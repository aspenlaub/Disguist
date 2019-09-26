using System;
using System.IO;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspenlaub.Net.GitHub.CSharp.Disguist.Test {
    public class ApplicationAndWindow : IDisposable {
        public UIA3Automation Uia3Automation { get; }
        public Application Application { get; }
        public Window Window { get; }

        public ApplicationAndWindow() {
            var executableFile = GetType().Assembly.Location.Replace(@"Test\bin", "bin").Replace(".Test.dll", ".exe");
            Assert.IsTrue(File.Exists(executableFile));
            Application = Application.Launch(executableFile);
            Application.WaitWhileBusy();
            Uia3Automation = new UIA3Automation();
            Window = Application.GetMainWindow(Uia3Automation);
        }

        public void Dispose() {
            Window.Close();
            Application.Dispose();
        }
    }

    [TestClass]
    public class DisguistTest {
        [TestMethod]
        public void ThereIsADisguistWindow() {
            using (var applicationAndWindow = new ApplicationAndWindow()) {
                Assert.IsNotNull(applicationAndWindow);
                Assert.IsNotNull(applicationAndWindow.Application);
                Assert.IsNotNull(applicationAndWindow.Window);
            }
        }
    }
}
