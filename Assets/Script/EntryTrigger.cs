using UnityEngine;
using UnityEngine.Events;

public class EntryTrigger : MonoBehaviour
{
    public UnityEvent onPlayerEnter;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPlayerEnter.Invoke();
        }
    }
}
