using UnityEngine;
using System.Collections;

public class Player_Shooting : MonoBehaviour
{
    public GameObject bullet; // Il prefab del proiettile
    public Transform muzzle; // La posizione da cui il proiettile verr� sparato
    public float bulletForce; // La forza con cui il proiettile viene sparato
    public float fireRate = 0.5f; // Il tempo di attesa tra i colpi
    private bool canFire = true; // Controlla se il giocatore pu� sparare

    // Metodo per sparare
    public void Fire()
    {
        if (canFire) // Verifica se � possibile sparare (controllo del delay)
        {
            StartCoroutine(ShootWithDelay());
        }
    }

    // Coroutine che gestisce il ritardo tra i colpi
    private IEnumerator ShootWithDelay()
    {
        canFire = false; // Disabilita la possibilit� di sparare immediatamente

        // Instanzia il proiettile e aggiunge la forza
        GameObject projectile = Instantiate(bullet, muzzle.position, muzzle.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(muzzle.forward * bulletForce, ForceMode.Impulse);

        // Aspetta il tempo di ritardo specificato prima di consentire un altro colpo
        yield return new WaitForSeconds(fireRate);

        canFire = true; // Ora il giocatore pu� sparare di nuovo
    }
}
