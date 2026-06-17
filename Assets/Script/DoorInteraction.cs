using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public bool isOpen = false;
    public float openAngle = 90f;
    public float smooth = 5f;

    private Quaternion openRotation;
    private Quaternion closeRotation;

    void Start()
    {
        closeRotation = transform.rotation;
        openRotation = Quaternion.Euler(
            transform.eulerAngles.x,
            transform.eulerAngles.y + openAngle,
            transform.eulerAngles.z
        );
    }

    void Update()
    {
        if (isOpen)
            transform.rotation = Quaternion.Slerp(
                transform.rotation, openRotation, Time.deltaTime * smooth);
        else
            transform.rotation = Quaternion.Slerp(
                transform.rotation, closeRotation, Time.deltaTime * smooth);
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }
}
