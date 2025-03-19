using UnityEngine;

public class Exploding_Wall : MonoBehaviour
{
    public string prefabName = "NomeDelPrefab"; // Nome del prefab che deve colpire il muro
    public GameObject destroyEffect; // Particella o effetto visivo per la distruzione del muro

    private void OnTriggerEnter(Collider other)
    {
        // Controlla se l'oggetto che ha colpito il muro ha il nome del prefab specificato
        if (other.gameObject.name == prefabName)
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
