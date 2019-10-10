using System.Threading.Tasks;
using Aspenlaub.Net.GitHub.CSharp.Disguist.Entities;
using Aspenlaub.Net.GitHub.CSharp.Disguist.Interfaces;
using Aspenlaub.Net.GitHub.CSharp.Pegh.Entities;
using Aspenlaub.Net.GitHub.CSharp.Pegh.Interfaces;

namespace Aspenlaub.Net.GitHub.CSharp.Disguist.Components {
    public class WordDisguiser : IWordDisguiser {
        private readonly IDisguiser vDisguiser;
        private readonly ISecretRepository vSecretRepository;

        public WordDisguiser(IDisguiser disguiser, ISecretRepository secretRepository) {
            vDisguiser = disguiser;
            vSecretRepository = secretRepository;
        }

        public async Task<WordDisguiserResult> DisguiseWordAsync(string word) {
            var errorsAndInfos = new ErrorsAndInfos();
            var result = new WordDisguiserResult {
                DisguisedWord = await vDisguiser.Disguise(vSecretRepository, word, errorsAndInfos),
                Errors = errorsAndInfos.Errors
            };
            return result;
        }
    }
}
