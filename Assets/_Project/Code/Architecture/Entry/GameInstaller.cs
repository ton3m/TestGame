using Zenject;

namespace _Project.Code.Architecture
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ICharacterInput>().To<KeyboardCharacterInput>().AsSingle();
            Container.Bind<ISceneLoader>().To<DefaultSceneLoader>().AsSingle();
            Container.Bind<ResourcesLoader>().AsSingle();

            Container.Bind<CoroutinePerformer>()
                .FromComponentInNewPrefabResource(ResourcesPaths.CoroutinePerformerPath)
                .AsSingle();
            
            Container.Bind<LoadingCurtain>()
                .FromComponentInNewPrefabResource(ResourcesPaths.LoadingCurtainPath)
                .AsSingle();
        }
    }
}