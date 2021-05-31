using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] FloatingJoystick floatingJoystick;

    [SerializeField] Ball ball;
    [SerializeField] Weapon weapon;

    float idleAnimationTime = 3;
    float idleTimer = 0;

    void Update()
    {
        Vector3 ballDirection = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        ball.Move(ballDirection);
        
        Vector3 weaponDirection = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        weapon.Turn(weaponDirection);

        if (weaponDirection == Vector3.zero && !weapon.targetLocked)
        {
            // Idle
            if (idleTimer >= idleAnimationTime)
            {
                // Run idle animation
                ball.RunIdleAnimation();

                // Set idle to some negative number so it doesnt run every 2 seconds
                // Instead it will run first time after 2 seconds, every other time after 10 seconds
                idleTimer = -10;
            }
            else
            {
                idleTimer += Time.deltaTime;
            }
        } else
        {
            idleTimer = 0;
            ball.StopIdleAnimation();
        }
    }
}
