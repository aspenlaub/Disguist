using Aspenlaub.Net.GitHub.CSharp.Disguist.Interfaces;
using Aspenlaub.Net.GitHub.CSharp.Pegh.Components;
using Autofac;

namespace Aspenlaub.Net.GitHub.CSharp.Disguist.Components {
    public static class DisguistContainerBuilder {
        public static ContainerBuilder UseDisguistAndPegh(this ContainerBuilder builder) {
            builder.UsePegh(new DummyCsArgumentPrompter());
            builder.RegisterType<WordDisguiser>().As<IWordDisguiser>();
            return builder;
        }
    }
}
