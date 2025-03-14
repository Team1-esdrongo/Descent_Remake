using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_Shooting : MonoBehaviour
{
    public GameObject bullet; // Il prefab del proiettile
    public List<Transform> muzzles; // Lista di posizioni da cui sparare (due o più)
    public float bulletForce; // La forza con cui il proiettile viene sparato
    public float fireRate = 0.5f; // Il tempo di attesa tra i colpi
    private bool canFire = true; // Controlla se il giocatore può sparare
    private int _currentIndex = 0; // Indice che alterna tra i muzzles nella lista

    // Metodo per sparare
    public void Fire()
    {
        if (canFire) // Verifica se è possibile sparare (controllo del delay)
        {
            StartCoroutine(ShootWithDelay());
        }
    }

    // Coroutine che gestisce il ritardo tra i colpi
    private IEnumerator ShootWithDelay()
    {
        canFire = false; // Disabilita la possibilità di sparare immediatamente

        // Sceglie il tipo di muzzle dalla lista in base all'indice corrente
        Transform currentMuzzle = muzzles[_currentIndex];

        // Instanzia il proiettile dalla posizione selezionata
        GameObject projectile = Instantiate(bullet, currentMuzzle.position, currentMuzzle.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(currentMuzzle.forward * bulletForce, ForceMode.Impulse);

        // Incrementa l'indice per alternare tra i muzzles nella lista
        _currentIndex = (_currentIndex + 1) % muzzles.Count;

        // Aspetta il tempo di ritardo specificato prima di consentire un altro colpo
        yield return new WaitForSeconds(fireRate);

        canFire = true; // Ora il giocatore può sparare di nuovo
    }
}
