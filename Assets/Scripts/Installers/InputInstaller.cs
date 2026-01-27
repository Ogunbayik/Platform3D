using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    [SerializeField] private CheckpointManager _checkPointManager;
    public override void InstallBindings()
    {
        Container.Bind<IInpuService>().To<KeyboardInput>().AsSingle();

        //Geçiçi Manager'i buraya bind ediyorum
        Container.Bind<CheckpointManager>().FromInstance(_checkPointManager).AsSingle().NonLazy();
    }
}