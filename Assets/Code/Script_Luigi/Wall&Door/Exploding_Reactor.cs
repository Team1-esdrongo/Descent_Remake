using UnityEngine;
using TMPro;

public class Exploding_Reactor : MonoBehaviour
{
    public float reactorHealth = 20f;              // Salute del reattore
    public TextMeshProUGUI winText;                // Riferimento al testo di vittoria
    public string[] damagingPrefabs;               // Prefabs di colpi che danneggiano il reattore

    void Start()
    {
        // Inizializza il testo a schermo: all'inizio il testo di vittoria è invisibile
        if (winText != null)
        {
            winText.text = ""; // Nessun testo iniziale
        }
    }

    void Update()
    {
        // Puoi rimuovere la logica legata al timer e alla porta di uscita, se non è più necessaria
    }

    private void OnTriggerEnter(Collider other)
    {
        // Controlla se l'oggetto che colpisce il reattore è uno dei prefab dannosi
        foreach (string prefabName in damagingPrefabs)
        {
            if (other.gameObject.name == prefabName)
            {
                TakeDamage(1f); // Infligge 1 danno per ogni colpo che entra in contatto con il reattore
                break;
            }
        }
    }

    private void TakeDamage(float damage)
    {
        // Riduce la salute del reattore, ma non scende mai sotto zero
        reactorHealth = Mathf.Max(reactorHealth - damage, 0f);

        if (reactorHealth <= 0)
        {
            ReactorDestroyed();
        }
    }

    // Funzione chiamata quando il reattore viene distrutto
    void ReactorDestroyed()
    {
        // Dichiarazione di vittoria
        if (winText != null)
        {
            winText.text = "Hai vinto! Il reattore è stato distrutto!";
        }

        // Distruggi il GameObject del reattore (se necessario)
        Destroy(gameObject); // Oppure, puoi disabilitarlo se non vuoi distruggerlo completamente
    }
}

//public class ReactorController : MonoBehaviour
//{
//    public int reactorHealth = 20;      // Salute del reattore
//    public GameObject exitDoor;         // Porta di uscita
//    public float exitTimer = 60f;       // Timer per l'uscita
//    public bool isReactorDestroyed = false; // Se il reattore è distrutto
//    private bool exitDoorOpen = false;  // Se la porta è stata aperta
//    private float currentExitTime;      // Timer attuale per la porta

//    void Start()
//    {
//        // Assicurati che la porta sia chiusa all'inizio
//        exitDoor.SetActive(false);
//        currentExitTime = exitTimer;
//    }

//    void Update()
//    {
//        // Se il reattore è stato distrutto, avvia il timer
//        if (isReactorDestroyed && !exitDoorOpen)
//        {
//            currentExitTime -= Time.deltaTime;

//            // Se il timer è scaduto, il giocatore perde
//            if (currentExitTime <= 0)
//            {
//                LoseGame();
//            }
//        }

//        // Controllo se il giocatore è arrivato alla porta
//        if (exitDoorOpen && PlayerIsAtExit())
//        {
//            WinGame();
//        }
//    }

//    // Funzione per danneggiare il reattore (viene chiamata dai prefab)
//    public void TakeDamage(int damage)
//    {
//        if (reactorHealth > 0)
//        {
//            reactorHealth -= damage;

//            // Se la salute del reattore arriva a 0 o meno
//            if (reactorHealth <= 0)
//            {
//                ReactorDestroyed();
//            }
//        }
//    }

//    // Funzione chiamata quando il reattore viene distrutto
//    void ReactorDestroyed()
//    {
//        isReactorDestroyed = true;
//        // Apri la porta di uscita
//        OpenExitDoor();
//        Debug.Log("Reattore distrutto! Timer avviato.");
//    }

//    // Funzione per aprire la porta di uscita
//    void OpenExitDoor()
//    {
//        exitDoor.SetActive(true); // Porta aperta
//        exitDoorOpen = true;
//        Debug.Log("Porta di uscita aperta! Vai velocemente!");
//    }

//    // Funzione per verificare se il giocatore è alla porta
//    bool PlayerIsAtExit()
//    {
//        // Aggiungi qui il codice che verifica se il giocatore è vicino alla porta
//        // Per esempio, usando un collider o una distanza
//        return Vector3.Distance(Player.Instance.transform.position, exitDoor.transform.position) < 5f;
//    }

//    // Funzione chiamata quando il giocatore vince
//    void WinGame()
//    {
//        Debug.Log("Hai vinto! Sei riuscito a raggiungere la porta in tempo!");
//        // Aggiungi qui il codice per terminare il gioco e dichiarare la vittoria
//    }

//    // Funzione chiamata quando il giocatore perde
//    void LoseGame()
//    {
//        Debug.Log("Hai perso! Il tempo è scaduto.");
//        // Aggiungi qui il codice per terminare il gioco e dichiarare la sconfitta
//    }
//}
