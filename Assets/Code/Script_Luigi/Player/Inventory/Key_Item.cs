using UnityEngine;

public class Key_Item : MonoBehaviour
{
    public string keyName;

    void OnTriggerEnter(Collider other)
    {
        // Se il giocatore entra in collisione con la chiave, aggiungila all'inventario
        if (other.CompareTag("Player"))
        {
            Inventory_System inventory = other.GetComponent<Inventory_System>();
            inventory.AddKey(keyName);
            Destroy(gameObject); // Distruggi la chiave dopo che è stata raccolta
        }
    }
}
