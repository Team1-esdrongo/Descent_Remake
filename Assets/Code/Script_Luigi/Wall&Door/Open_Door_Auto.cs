using UnityEngine;

public class Open_Door_Auto : MonoBehaviour
{
    private bool isOpen = false;
    public float moveDistance = 3f; // Distanza verso il basso in cui la porta si sposterà
    public float moveSpeed = 1f; // Velocità con cui la porta si muove
    public float openDelay = 3f; // Tempo in secondi che la porta rimarrà aperta
    public float activationRange = 5f; // Distanza a cui il giocatore può aprire la porta

    private Vector3 closedPosition; // Posizione iniziale (chiusa)
    private Vector3 openPosition; // Posizione finale (aperta)

    private Transform player; // Riferimento al giocatore

    private void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition - new Vector3(0, moveDistance, 0); // Spostamento verso il basso
        player = GameObject.FindWithTag("Player").transform; // Trova il giocatore
    }

    private void Update()
    {
        // Controlla se il giocatore è abbastanza vicino per aprire la porta
        if (Vector3.Distance(player.position, transform.position) <= activationRange)
        {
            if (!isOpen)
            {
                OpenDoor();
            }
        }
        else
        {
            if (isOpen)
            {
                // Se il giocatore si allontana, richiudi la porta
                CloseDoor();
            }
        }
    }

    private void OpenDoor()
    {
        if (!isOpen)
        {
            isOpen = true;
            // Inizia a muovere la porta verso il basso
            StartCoroutine(MoveDoor(openPosition));
            Debug.Log("La porta è stata aperta.");
            StartCoroutine(CloseDoorAfterDelay(openDelay)); // Richiudi dopo un certo tempo
        }
    }

    private void CloseDoor()
    {
        if (isOpen)
        {
            isOpen = false;
            // Inizia a muovere la porta verso l'alto
            StartCoroutine(MoveDoor(closedPosition));
            Debug.Log("La porta è stata richiusa.");
        }
    }

    private System.Collections.IEnumerator MoveDoor(Vector3 targetPosition)
    {
        float timeElapsed = 0f;
        Vector3 initialPosition = transform.position;

        // Muovi la porta verso la posizione finale (aperta o chiusa)
        while (timeElapsed < (Vector3.Distance(initialPosition, targetPosition) / moveSpeed))
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, timeElapsed / (Vector3.Distance(initialPosition, targetPosition) / moveSpeed));
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Assicurati che la porta arrivi esattamente alla posizione finale
        transform.position = targetPosition;
    }

    private System.Collections.IEnumerator CloseDoorAfterDelay(float delay)
    {
        // Attendi un certo tempo prima di richiudere la porta
        yield return new WaitForSeconds(delay);
        CloseDoor();
    }
}
