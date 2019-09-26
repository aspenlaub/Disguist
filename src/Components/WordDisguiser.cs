using System.Threading.Tasks;
using Aspenlaub.Net.GitHub.CSharp.Pegh.Components;
using Aspenlaub.Net.GitHub.CSharp.Pegh.Entities;
using Aspenlaub.Net.GitHub.CSharp.Pegh.Interfaces;

namespace Aspenlaub.Net.GitHub.CSharp.Disguist.Components {
    public class WordDisguiser {
        protected IComponentProvider ComponentProvider;

        public WordDisguiser() {
            ComponentProvider = new ComponentProvider();
        }

        public async Task<WordDisguiserResult> DisguiseWordAsync(string word) {
            var errorsAndInfos = new ErrorsAndInfos();
            var result = new WordDisguiserResult {
                DisguisedWord = await ComponentProvider.Disguiser.Disguise(word, errorsAndInfos),
                Errors = errorsAndInfos.Errors
            };
            return result;
        }
    }
}
