using ArBird.Pipes;
using ArBird.Player;
using ArBird.Services;
using UnityEngine.XR.ARFoundation;
using Zenject;

namespace ArBird.Infrastructure
{
    public class SceneInstaller : MonoInstaller
    {
        public PlayerSpawner PlayerSpawner { get; private set; }
        public Shop Shop { get; private set; }
        public ARRaycastManager RaycastManager { get; private set; }
        public ARPlaneManager PlaneManager { get; private set; }
        public WorldSpawner WorldSpawner { get; private set; }
        public PipeSpawner PipeSpawner { get; private set; }
        public GameplayService GameplayService { get; private set; }

        public override void InstallBindings()
        {
            BindPlayerSpawner();
            BindShop();
            BindRaycastManager();
            BindPlaneManager();
            BindPipeSpawner();
            BindGameplayService();
            BindWorldSpawner();
        }

        private void BindWorldSpawner()
        {
            Container.Bind<WorldSpawner>()
                       .FromComponentInHierarchy(true)
                       .AsSingle()
                       .NonLazy();
        }

        private void BindPlaneManager()
        {
            Container.Bind<ARPlaneManager>()
                       .FromComponentInHierarchy(true)
                       .AsSingle()
                       .NonLazy();
        }

        private void BindGameplayService()
        {
            Container.Bind<GameplayService>()
                           .FromComponentInHierarchy(true)
                           .AsSingle()
                           .NonLazy();
        }

        private void BindPipeSpawner()
        {
            Container.Bind<PipeSpawner>()
                            .FromComponentInHierarchy(true)
                            .AsSingle()
                            .NonLazy();
        }

        private void BindRaycastManager()
        {
            Container.Bind<ARRaycastManager>()
                            .FromComponentInHierarchy(true)
                            .AsSingle()
                            .NonLazy();
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
