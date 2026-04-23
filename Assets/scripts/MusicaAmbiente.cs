using UnityEngine;

public class MusicaAmbiente : MonoBehaviour
{
    public AudioClip musica;
    public float volumen = 0.5f;

    private AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        if (audioSrc == null)
            audioSrc = gameObject.AddComponent<AudioSource>();

        audioSrc.clip = musica;
        audioSrc.loop = true;
        audioSrc.playOnAwake = false;
        audioSrc.volume = volumen;

        if (musica != null)
            audioSrc.Play();
    }
}