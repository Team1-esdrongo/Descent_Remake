using UnityEngine;

public class Open_Door : MonoBehaviour
{
    public string keyRequired; // Nome della chiave necessaria per aprire la porta
    private bool isOpen = false;

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
            // Logica per aprire la porta, per esempio disabilitando il collider o cambiando animazione
            GetComponent<Collider>().enabled = false; // Disabilita il collider della porta per permettere al giocatore di attraversarla
            Debug.Log("La porta è stata aperta.");
        }
    }
}
