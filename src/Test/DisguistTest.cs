using System.IO;
using Aspenlaub.Net.GitHub.CSharp.Paleface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resources = Aspenlaub.Net.GitHub.CSharp.Disguist.Properties.Resources;

namespace Aspenlaub.Net.GitHub.CSharp.Disguist.Test {
    [TestClass]
    public class DisguistTest {

        [TestMethod]
        public void ThereIsADisguistWindow() {
            var executableFile = GetType().Assembly.Location
                .Replace(@"Test\bin", "bin")
                .Replace(".Test.dll", ".exe")
                .Replace(@"\netcoreapp3.0", "");
            Assert.IsTrue(File.Exists(executableFile));
            // ReSharper disable once UnusedVariable
            using var sut = new Window(executableFile, Resources.WindowTitle, () => { });
        }
    }
}
