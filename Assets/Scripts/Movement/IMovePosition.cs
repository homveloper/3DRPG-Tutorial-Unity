using UnityEngine;

namespace SD.Movement{

public interface IMovePosition
{
    public void SetMovePosition(Vector3 movePosition);
    public void Stop(bool condition);
    public Vector3 GetVelocity();
    public float GetMaxMoveSpeed();
}

}

