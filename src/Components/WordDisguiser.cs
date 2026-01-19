using System.Threading.Tasks;
using Aspenlaub.Net.GitHub.CSharp.Disguist.Entities;
using Aspenlaub.Net.GitHub.CSharp.Disguist.Interfaces;
using Aspenlaub.Net.GitHub.CSharp.Pegh.Entities;
using Aspenlaub.Net.GitHub.CSharp.Pegh.Interfaces;

namespace Aspenlaub.Net.GitHub.CSharp.Disguist.Components;

public class WordDisguiser(IDisguiser disguiser, ISecretRepository secretRepository) : IWordDisguiser {
    public async Task<WordDisguiserResult> DisguiseWordAsync(string word) {
        var errorsAndInfos = new ErrorsAndInfos();
        var result = new WordDisguiserResult {
            DisguisedWord = await disguiser.Disguise(secretRepository, word, errorsAndInfos),
            Errors = errorsAndInfos.Errors
        };
        return result;
    }
}