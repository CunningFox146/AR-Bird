using ArBird.Player;
using ArBird.Services;
using Zenject;

namespace ArBird.Infrastructure
{
    public class SceneInstaller : MonoInstaller
    {
        public PlayerSpawner PlayerSpawner { get; private set; }
        public Shop Shop { get; private set; }

        public override void InstallBindings()
        {
            BindPlayerSpawner();
            BindShop();
        }

        private void BindShop()
        {
            Container.Bind<Shop>()
                            .FromComponentInHierarchy(true)
                            .AsSingle()
                            .NonLazy();
        }

        private void BindPlayerSpawner()
        {
            Container.Bind<PlayerSpawner>()
                            .FromComponentInHierarchy(true)
                            .AsSingle()
                            .NonLazy();
        }
    }
}
