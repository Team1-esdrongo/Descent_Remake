using System.Collections;
using UnityEngine;

public class AudioChanger : MonoBehaviour
{
    public AudioSource backgroundAudioSource; // Audio iniziale di background
    public AudioSource radioAudioSource; // AudioSource della radio
    public AudioClip[] radioClips; // Array di clip audio per la radio
    public float delay = 1f; // Ritardo in secondi prima di cambiare audio
    public string targetTag = "Projectile"; // Tag dei prefab che attivano il cambio
    private bool firstChange = true; // Flag per il primo cambio

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag)) // Controlla se l'oggetto ha il tag corretto
        {
            StartCoroutine(ChangeAudioWithDelay());
        }
    }

    private IEnumerator ChangeAudioWithDelay()
    {
        yield return new WaitForSeconds(delay);

        if (firstChange && backgroundAudioSource.isPlaying)
        {
            backgroundAudioSource.Stop(); // Ferma la musica di background solo la prima volta
            firstChange = false;
        }

        if (radioClips.Length > 0)
        {
            radioAudioSource.clip = radioClips[Random.Range(0, radioClips.Length)];
            radioAudioSource.Play();
        }
    }
}
