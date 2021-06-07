using UnityEngine;

public class PlayerController : Character
{
    FloatingJoystick floatingJoystick;

    float cameraZoomedIn = 12.2f;
    float cameraZoomedOut = 20.2f;

    float idleAnimationTime = 3;
    float idleTimer = 0;

    Transform towerSpotToSnap;

    // When in construction mode, hide weapon and show blueprint in hand
    bool constructionMode = false;

    // TODO: make it a list of all items like with all other things
    [SerializeField] GameObject stoneTowerPrefab;

    // This is to remove the item when blueprint is closed or when item is built
    GameObject constructionItem;

    void Start()
    {
        floatingJoystick = FindObjectOfType<FloatingJoystick>();
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (constructionMode)
            {
                StopConstructionMode();
            }
            else
            {
                StartConstructionMode();
            }
        }

        if (constructionItem != null)
        {
            if (towerSpotToSnap != null)
            {
                // Snap the tower to the tower spot
                constructionItem.transform.position = towerSpotToSnap.position;
                constructionItem.transform.rotation = towerSpotToSnap.rotation;
            }
            else
            {
                // Snap it back to the player sight
                constructionItem.transform.position = sight.transform.position;
            }
        }
        
        //if (weaponDirection == Vector3.zero && !weapon.targetLocked)
        //{
        //    // Idle
        //    if (idleTimer >= idleAnimationTime)
        //    {
        //        // Run idle animation
        //        ball.RunIdleAnimation();

        //        // Set idle to some negative number so it doesnt run every 2 seconds
        //        // Instead it will run first time after 2 seconds, every other time after 10 seconds
        //        idleTimer = -10;
        //    }
        //    else
        //    {
        //        idleTimer += Time.deltaTime;
        //    }
        //} else
        //{
        //    idleTimer = 0;
        //    ball.StopIdleAnimation();
        //}
    }

    #region Public Methods
    // Called when in backpack player clicks on constructable item.
    // such as Blueprint of something
    public void StartConstructionMode()
    {
        constructionMode = true;

        // Hide weapon and show blueprint
        blueprint.SetActive(true);
        rightArm.gameObject.SetActive(false);
        // TODO: make it dynamic based on what you touch in backpack
        constructionItem = Instantiate(stoneTowerPrefab, sight.transform.position, Quaternion.identity);
        constructionItem.GetComponent<BoxCollider>().enabled = false;
        constructionItem.GetComponent<Rigidbody>().isKinematic = true;
        constructionItem.transform.SetParent(sight.transform);
    }

    public void StopConstructionMode()
    {
        constructionMode = false;

        // Hide weapon and show blueprint
        blueprint.SetActive(false);
        rightArm.gameObject.SetActive(true);

        Destroy(constructionItem);
    }

    public void SnapTower(Transform _transform)
    {
        towerSpotToSnap = _transform;
    }

    public void UnsnapTower(Transform _transform)
    {
        // If this is the tower spot it was snapping to, then remove it and unsnap the tower from the spot
        if (towerSpotToSnap == _transform)
        {
            towerSpotToSnap = null;
        }
    }
    #endregion
}
