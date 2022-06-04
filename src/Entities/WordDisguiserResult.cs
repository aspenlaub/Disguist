using System.Collections.Generic;

namespace Aspenlaub.Net.GitHub.CSharp.Disguist.Entities;

public class WordDisguiserResult {
    public string DisguisedWord { get; set; }
    public IList<string> Errors { get; set; }
}