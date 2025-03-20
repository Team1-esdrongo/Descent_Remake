using UnityEngine;
using TMPro;

public class Exploding_Reactor : MonoBehaviour
{
    public float reactorHealth = 20f;              // Salute del reattore
    public TextMeshProUGUI runText;                // Riferimento al testo di vittoria
    public string[] damagingPrefabs;               // Prefabs di colpi che danneggiano il reattore

    void Start()
    {
        // Inizializza il testo a schermo: all'inizio il testo di vittoria è invisibile
        if (runText != null)
        {
            runText.text = ""; // Nessun testo iniziale
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
        if (runText != null)
        {
            runText.text = "Fuggi dai comunisti!!!";
        }

        // Distruggi il GameObject del reattore (se necessario)
        Destroy(gameObject); // Oppure, puoi disabilitarlo se non vuoi distruggerlo completamente
    }
}

