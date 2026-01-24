using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Const 
{
    public class PlayerInput
    {
        public const string HORIZONTAL_INPUT = "Horizontal";
        public const string VERTICAL_INPUT = "Vertical";
    }
    public class PlayerConstant
    {
        public const float INTERACT_DISTANCE = 1f;
    }
    public class  GameConstant
    {
        public const float GRAVITY = -25f;
        public const float GRAVITY_FACTOR = -2f;
    }
    public class Tag
    {
        public const string PLAYER_TAG = "Player";
        public const string MOVING_PLATFORM_TAG = "MovingPlatform";
    }
}
