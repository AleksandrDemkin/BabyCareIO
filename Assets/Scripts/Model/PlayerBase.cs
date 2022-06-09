using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    public float _speed;
    public static bool isCry;
    public static bool isClap;
    public static bool isWalk;
    public static bool isIdle;
    public static int _countCube;
    public static int _countCastlePlace;
    public abstract void Move(float x, float y, float z);
    public abstract void BabyAnim();
    public abstract void RotationMove();
}
