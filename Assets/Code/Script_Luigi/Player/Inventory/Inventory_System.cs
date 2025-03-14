using System.Collections.Generic;
using UnityEngine;

public class Inventory_System : MonoBehaviour
{
    // Lista delle chiavi raccolte dal giocatore
    public List<string> collectedKeys = new List<string>();

    // Metodo per aggiungere una chiave all'inventario
    public void AddKey(string key)
    {
        if (!collectedKeys.Contains(key))
        {
            collectedKeys.Add(key);
            Debug.Log("Chiave " + key + " aggiunta all'inventario.");
        }
    }

    // Metodo per verificare se il giocatore ha una chiave specifica
    public bool HasKey(string key)
    {
        return collectedKeys.Contains(key);
    }
}
