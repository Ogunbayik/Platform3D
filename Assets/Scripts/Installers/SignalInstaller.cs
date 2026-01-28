using UnityEngine;
using Zenject;

public class SignalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<GameSignal.TrapTriggeredSignal>();
        Container.DeclareSignal<GameSignal.InteractedSignal>();
        Container.DeclareSignal<GameSignal.PlayerDiedSignal>();
        Container.DeclareSignal<GameSignal.PlayerRespawnSignal>();
        Container.DeclareSignal<GameSignal.PlayerReachCheckpointSignal>();
    }
}