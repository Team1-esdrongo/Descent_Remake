using System;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    [SerializeField] private float lifeTime = 6f;
    private float _currentLifeTime = 0;
    internal void SetVelocity(Vector3 direction)
    {
        throw new NotImplementedException();
    }

    public int damage = 1; // Danno inflitto dal proiettile


    private void OnTriggerEnter(Collider other)
    {
        // Verifica se l'oggetto con cui il proiettile è entrato in contatto è un nemico
        if (other.CompareTag("Enemy"))
        {
            // Infliggi danno al nemico
            other.GetComponent<Enemy_Health>().TakeDamage(damage);

            // Distruggi il proiettile
            Destroy(gameObject);
        }
        else
        {
            // Distruggi il proiettile
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        _currentLifeTime += Time.deltaTime;

        if (_currentLifeTime >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
