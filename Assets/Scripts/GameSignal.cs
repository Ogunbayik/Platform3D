using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSignal
{
    public class TrapTriggeredSignal
    {
        public int TrapID;
        public TrapTriggeredSignal(int trapId) => TrapID = trapId;
    }
}
