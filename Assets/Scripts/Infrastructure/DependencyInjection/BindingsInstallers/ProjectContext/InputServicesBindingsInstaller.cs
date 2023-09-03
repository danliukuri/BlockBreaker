using BlockBreaker.Infrastructure.Services.Input;
using Zenject;

namespace BlockBreaker.Infrastructure.DependencyInjection.BindingsInstallers.ProjectContext
{
    public class InputServicesBindingsInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindPlayerTouchInputService();

        private void BindPlayerTouchInputService() => Container.BindInterfacesTo<PlayerTouchInputService>().AsSingle();
    }
}