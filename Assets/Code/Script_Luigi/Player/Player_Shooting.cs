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
    [SerializeField] private LayerMask hitLayers;

    // Metodo per sparare
    public void Fire()
    {
        if (canFire) // Verifica se è possibile sparare (controllo del delay)
        {
            StartCoroutine(ShootWithDelay());
        }
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        // Esegue il raycast
        if (Physics.Raycast(origin, direction, out hit, 100, hitLayers))
        {
            Debug.Log($"Ray hit: {hit.collider.name}");
            Debug.DrawLine(origin, hit.point, Color.red); // Disegna il raggio fino all'impatto
        }
        else
        {
            Debug.DrawLine(origin, origin + direction * 100, Color.red); // Disegna il raggio completo
        }

        //Debug.DrawLine(muzzles[0].position, muzzles[0].position + muzzles[0].forward *100f, Color.red);
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
