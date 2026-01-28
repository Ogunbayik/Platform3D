using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;

public class PlayerPhysicsHandler : MonoBehaviour
{
    private SignalBus _signalBus;
    private CheckpointManager _checkPointManager;

    [Inject]
    public void Construct(SignalBus signalBus, CheckpointManager checkPointManager)
    {
        _signalBus = signalBus;
        _checkPointManager = checkPointManager;
    }
    private void OnEnable() => _signalBus.Subscribe<GameSignal.PlayerDiedSignal>(HandleDeadTrigger);
    private void OnDisable() => _signalBus.Unsubscribe<GameSignal.PlayerDiedSignal>(HandleDeadTrigger);
    private void HandleDeadTrigger(GameSignal.PlayerDiedSignal signal) => RespawnSequence();
    private async void RespawnSequence()
    {
        var token = this.GetCancellationTokenOnDestroy();

        //Ýlk önce yokolma animasyonu ekleyeceðiz ve animasyon süresi kadar bekleyeceðiz.
        //Bir yandan da ölüm kamerasýna geçiþ yapabiliriz.
        await UniTask.Delay(2000, cancellationToken: token);
        //Player'ý chekpoint'e ýþýnlýyoruz.
        transform.position = _checkPointManager.CheckpointPosition;
        _signalBus.Fire(new GameSignal.PlayerRespawnSignal());
    }
    public IEnumerator HandleTest()
    {
        Debug.Log("Need Teleport");
        yield return new WaitForSeconds(2f);
        Debug.Log("Need Teleport");
        transform.position = _checkPointManager.CheckpointPosition;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        HandleMovingPlatform(hit);

        HandleCrumblingPlatform(hit);
    }
    private void HandleMovingPlatform(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag(Const.Tag.MOVING_PLATFORM_TAG))
        {
            if (transform.parent != null)
                transform.parent = hit.transform;
        }
        else
        {
            if (transform.parent != null)
                transform.parent = null;
        }
    }
    private void HandleCrumblingPlatform(ControllerColliderHit hit)
    {
        if (hit.gameObject.TryGetComponent<CrumblingPlatform>(out CrumblingPlatform crumblingPlatform))
            crumblingPlatform.TriggerFall();
    }


}
