using UnityEngine;

public class Open_Door : MonoBehaviour
{
    public string keyRequired; // Nome della chiave necessaria per aprire la porta
    private bool isOpen = false;
    public float moveDistance = 3f; // Distanza verso il basso in cui la porta si sposterà
    public float moveSpeed = 1f; // Velocità con cui la porta si muove

    private Vector3 closedPosition; // Posizione iniziale (chiusa)
    private Vector3 openPosition; // Posizione finale (aperta)

    private void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition - new Vector3(0, moveDistance, 0); // Spostamento verso il basso
    }

    public void TryToOpen(Inventory_System playerInventory)
    {
        if (playerInventory.HasKey(keyRequired))
        {
            OpenDoor();
        }
        else
        {
            Debug.Log("Non hai la chiave per aprire questa porta.");
        }
    }

    private void OpenDoor()
    {
        if (!isOpen)
        {
            isOpen = true;
            // Inizia a muovere la porta verso il basso
            StartCoroutine(MoveDoor());
            Debug.Log("La porta è stata aperta.");
        }
    }

    private System.Collections.IEnumerator MoveDoor()
    {
        float timeElapsed = 0f;

        // Sposta la porta dalla posizione chiusa alla posizione aperta
        while (timeElapsed < moveDistance / moveSpeed)
        {
            transform.position = Vector3.Lerp(closedPosition, openPosition, timeElapsed / (moveDistance / moveSpeed));
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Assicurati che la porta arrivi esattamente alla posizione finale
        transform.position = openPosition;
    }
}