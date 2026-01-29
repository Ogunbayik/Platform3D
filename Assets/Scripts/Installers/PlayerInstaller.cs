using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CharacterController>().FromComponentOnRoot().AsSingle();

        Container.Bind<PlayerController>().FromComponentOnRoot().AsSingle();
        Container.Bind<PlayerInteract>().FromComponentOnRoot().AsSingle();
        Container.Bind<PlayerPhysicsHandler>().FromComponentOnRoot().AsSingle();

        Container.Bind<PlayerUI>().FromComponentInHierarchy().AsSingle();
    }
}