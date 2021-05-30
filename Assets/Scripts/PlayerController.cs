using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] FloatingJoystick floatingJoystick;

    [SerializeField] Ball ball;
    [SerializeField] Weapon weapon;

    void Update()
    {
        Vector3 ballDirection = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;

        ball.Move(ballDirection);

        Vector3 weaponDirection = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;

        weapon.Turn(weaponDirection);
    }
}
