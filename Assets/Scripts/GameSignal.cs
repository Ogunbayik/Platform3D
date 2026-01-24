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
    public class InteractButton
    {
        public int ButtonID;
        public InteractButton(int buttonID) => ButtonID = buttonID;
    }
}
