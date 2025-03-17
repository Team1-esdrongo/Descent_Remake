using UnityEngine;

public class Exploding_Reactor : MonoBehaviour
{
    private float maxHealth = 10f; // La salute massima del muro
    public float currentHealth; // La salute attuale del muro

    public string[] damagingPrefabs; // Array di nomi di prefab che danneggiano il muro
    public GameObject destroyEffect; // Particella o effetto visivo per la distruzione del muro

    private void Start()
    {
        currentHealth = maxHealth; // Inizializza la salute attuale del muro
    }

    private void OnTriggerEnter(Collider other)
    {
        // Controlla se l'oggetto che ha colpito il muro è uno dei prefab che danneggiano il muro
        foreach (string prefabName in damagingPrefabs)
        {
            if (other.gameObject.name == prefabName)
            {
                TakeDamage(1f); // Applicare danno ogni volta che il prefab colpisce il muro (puoi cambiare il valore del danno)
                break;
            }
        }
    }

    private void TakeDamage(float damage)
    {
        // Ridurre la salute del muro
        currentHealth -= damage;

        // Se la salute è minore o uguale a zero, distruggiamo il muro
        if (currentHealth <= 0)
        {
            DestroyWall();
        }
    }

    private void DestroyWall()
    {
        // Se è stato specificato un effetto di distruzione, istanziarlo
        if (destroyEffect != null)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }

        // Distruggi il muro (l'oggetto a cui è attaccato questo script)
        Destroy(gameObject);
        Debug.Log("Il muro è stato distrutto!");
    }
}
