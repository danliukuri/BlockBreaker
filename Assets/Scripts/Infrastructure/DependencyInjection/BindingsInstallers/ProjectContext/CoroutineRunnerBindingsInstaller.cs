using Unity.VisualScripting;
using Zenject;

namespace BlockBreaker.Infrastructure.DependencyInjection.BindingsInstallers.ProjectContext
{
    public class CoroutineRunnerBindingsInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindCoroutineRunner();

        private void BindCoroutineRunner()
        {
            Container
                .BindInterfacesAndSelfTo<CoroutineRunner>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}