using System;
using System.IO;
using Aspenlaub.Net.GitHub.CSharp.Paleface.Components;
using Aspenlaub.Net.GitHub.CSharp.Paleface.Helpers;
using Aspenlaub.Net.GitHub.CSharp.Paleface.Interfaces;
using Aspenlaub.Net.GitHub.CSharp.Pegh.Helpers;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resources = Aspenlaub.Net.GitHub.CSharp.Disguist.Properties.Resources;

namespace Aspenlaub.Net.GitHub.CSharp.Disguist.Test;

[TestClass]
public class DisguistTest {
    private readonly IContainer vContainer;

    public DisguistTest() {
        vContainer = new ContainerBuilder().UsePaleface().Build();
    }

    [TestInitialize]
    public void Initialize() {
        TestProcessHelper.ShutDownRunningProcesses(TestProcessHelper.ProcessType.Paleface);
        TestProcessHelper.LaunchProcessAsync(TestProcessHelper.ProcessType.Paleface).Wait();
    }

    [TestCleanup]
    public void CleanUp() {
        TestProcessHelper.ShutDownRunningProcesses(TestProcessHelper.ProcessType.Paleface);
    }

    [TestMethod]
    public void ThereIsADisguistWindow() {
        var executableFile = GetType().Assembly.Location
                                      .Replace(@"Test\bin", "bin")
                                      .Replace(".Test.dll", ".exe")
                                      .Replace(@"\netcoreapp3.0", "");
        Assert.IsTrue(File.Exists(executableFile));
        // ReSharper disable once UnusedVariable
        using var sut = vContainer.Resolve<IAppiumSession>();
        sut.Initialize(executableFile, Resources.WindowTitle, () => { }, 10);
        var wordTextBox = sut.FindTextBox("Word");
        Assert.IsNotNull(wordTextBox);
        const string testWord = "A performer in disguise (a performer in disguise)";
        wordTextBox.Text = testWord;
        Wait.Until(() => wordTextBox.Text.Length == testWord.Length, TimeSpan.FromSeconds(10));
        Assert.AreEqual(wordTextBox.Text.Length, testWord.Length);
        var disguistWordTextBox = sut.FindTextBox("DisguistWord");
        Assert.IsNotNull(disguistWordTextBox);
        Assert.IsFalse(string.IsNullOrWhiteSpace(disguistWordTextBox.Text));
    }
}