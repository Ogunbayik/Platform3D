using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    [Header("Player Data")]
    public PlayerDataSO PlayerData;

    public override void InstallBindings()
    {
        Container.BindInstance(PlayerData).AsSingle();
    }
}