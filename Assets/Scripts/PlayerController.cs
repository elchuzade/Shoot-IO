using UnityEngine;

public class PlayerController : Character
{
    FloatingJoystick floatingJoystick;

    PlayerCanvas playerCanvas;

    [SerializeField] GameObject appearParticles;

    float cameraZoomedIn = 14.2f;
    float cameraZoomedOut = 22.2f;

    float idleAnimationTime = 3;
    float idleTimer = 0;

    void Start()
    {
        playerCanvas = FindObjectOfType<PlayerCanvas>();
        floatingJoystick = FindObjectOfType<FloatingJoystick>();

        Destroy(appearParticles, 2);
    }

    void Update()
    {
        Vector3 ballDirection = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        Move(ballDirection);

        Vector3 weaponDirection = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        Turn(weaponDirection);

        // Zoom in and out camera when entering and exitting city
        if (cameraInCity && Vector3.Distance(transform.position, playerCamera.transform.position) < cameraZoomedOut)
        {
            playerCamera.transform.position += new Vector3(0, 0.2f, -0.2f);
        } else if (!cameraInCity && Vector3.Distance(transform.position, playerCamera.transform.position) > cameraZoomedIn)
        {
            playerCamera.transform.position -= new Vector3(0, 0.2f, -0.2f);
        }
    }

    #region Private Methods

    #endregion

    #region Public Methods
    public void DealDamage(float damage)
    {
        playerCanvas.DealDamage(damage);
    }
    #endregion
}
