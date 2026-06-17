using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public float slideDistance = 2f;
    public float slideSpeed = 3f;
    public float triggerDistance = 3f;
    public Transform player;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpen = false;
    private bool playerEntered = false;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = transform.position + transform.right * slideDistance;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < triggerDistance && !playerEntered)
        {
            isOpen = true;
        }

        if (isOpen && !playerEntered)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                openPosition,
                Time.deltaTime * slideSpeed
            );

            if (Vector3.Distance(transform.position, openPosition) < 0.05f)
            {
                playerEntered = true;
                isOpen = false;
            }
        }

        if (playerEntered && distance > triggerDistance + 1f)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                closedPosition,
                Time.deltaTime * slideSpeed
            );
        }
    }
}
