using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSignal
{
    public class PlayerDiedSignal { }
    public class PlayerRespawnSignal { }
    public class PlayerReachCheckpointSignal 
    {
        //Sharing Checkpoint Position
        public Transform Checkpoint;
        public PlayerReachCheckpointSignal(Transform checkpoint) => Checkpoint = checkpoint;
    }        
    public class TrapTriggeredSignal
    {
        //Interacting with Trap Trigger
        public int TrapID;
        public TrapTriggeredSignal(int trapId) => TrapID = trapId;
    }
    public class InteractedSignal
    {
        //Interacting with the button
        public IInteractable Interactable;
        public InteractedSignal(IInteractable interactable) => Interactable = interactable;
    }
}
