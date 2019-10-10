using System.Threading.Tasks;
using Aspenlaub.Net.GitHub.CSharp.Disguist.Entities;

namespace Aspenlaub.Net.GitHub.CSharp.Disguist.Interfaces {
    public interface IWordDisguiser {
        Task<WordDisguiserResult> DisguiseWordAsync(string word);
    }
}