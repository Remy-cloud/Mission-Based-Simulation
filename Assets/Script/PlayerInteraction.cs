using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float raycastDistance = 3f;
    public TMP_Text interactText;
    public LineRenderer lineRenderer;

    private Camera playerCamera;
    private PlayerInputActions inputActions;

    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Interact.performed += ctx => TryInteract();
    }

    void OnDisable()
    {
        inputActions.Player.Disable();
    }

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        interactText.gameObject.SetActive(false);
    }

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position,
                         playerCamera.transform.forward);
        RaycastHit hit;

        lineRenderer.SetPosition(0, playerCamera.transform.position);

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            lineRenderer.SetPosition(1, hit.point);

            if (hit.collider.CompareTag("Door"))
            {
                interactText.text = "Press E to Open/Close Door";
                interactText.gameObject.SetActive(true);
            }
            else
            {
                interactText.gameObject.SetActive(false);
            }
        }
        else
        {
            lineRenderer.SetPosition(1,
                playerCamera.transform.position +
                playerCamera.transform.forward * raycastDistance);
            interactText.gameObject.SetActive(false);
        }
    }

    void TryInteract()
    {
        Ray ray = new Ray(playerCamera.transform.position,
                         playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Door"))
            {
                hit.collider.GetComponent<DoorInteraction>().ToggleDoor();
            }
        }
    }
}
