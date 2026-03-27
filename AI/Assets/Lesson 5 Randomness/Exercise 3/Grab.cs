using UnityEngine;
using UnityEngine.InputSystem;

public class Grab : MonoBehaviour
{
    [SerializeField] private Transform _playerCameraTransform;
    [SerializeField] private LayerMask _pickUpLayerMask;
    [SerializeField] private float _pickUpDistance = 2f;
    [SerializeField] private Transform _objectGrabPointTransform;
    
    private PlayerInput playerInput;
    private InputAction pickUpAction;
    private InputAction dropItemAction;
    private ObjectGrabBehaviour currentGrabbableItem;
    
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        pickUpAction = playerInput.actions["PickUp"];
        dropItemAction = playerInput.actions["DropItem"];
    }
    
    void Update()
    {
        if (pickUpAction.WasPressedThisFrame() && currentGrabbableItem == null)
        {
            Debug.Log("hi Up");
            Debug.DrawLine(_playerCameraTransform.position, _playerCameraTransform.forward, Color.red);

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo,
                    _pickUpDistance, _pickUpLayerMask))
            {
                Debug.Log("hi Up" + hitInfo.transform.name);
                if (hitInfo.transform.TryGetComponent(out ObjectGrabBehaviour objectGrabBehaviour))
                {
                    currentGrabbableItem = objectGrabBehaviour;
                    currentGrabbableItem.Grab(this);
                    Debug.Log("Grabbed");
                }
            }
        }

        if (dropItemAction.WasPressedThisFrame())
        {
            if(currentGrabbableItem != null)
            {
                currentGrabbableItem.Drop();
                currentGrabbableItem = null;
            }

        }
    }
}
