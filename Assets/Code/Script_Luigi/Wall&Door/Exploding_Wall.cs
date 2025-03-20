using UnityEngine;

public class Exploding_Wall : MonoBehaviour
{
    public GameObject destroyEffect; // Particella o effetto visivo per la distruzione del muro

    private void OnTriggerEnter(Collider other)
    {
        // Controlla se l'oggetto che ha colpito il muro ha il nome del prefab specificato
        if (other.gameObject.name == "razzo")
        {
            Destroy(this.gameObject);
        }
    }
}