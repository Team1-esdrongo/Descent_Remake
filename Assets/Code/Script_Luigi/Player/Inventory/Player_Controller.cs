using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Player_Controller : MonoBehaviour
{
    public Inventory_System inventory;
    public float interactDistance = 3f;

    void Update()
    {
        // Rilevamento della pressione del tasto di interazione
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        RaycastHit hit;

        // Creiamo un raggio in avanti dal giocatore per vedere se colpisce una porta
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance))
        {
            Open_Door door = hit.collider.GetComponent<Open_Door>();

            if (door != null)
            {
                // Prova ad aprire la porta usando l'inventario del giocatore
                door.TryToOpen(inventory);
            }
        }
    }
}
