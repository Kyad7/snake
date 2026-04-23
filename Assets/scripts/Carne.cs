using UnityEngine;

public class Carne : MonoBehaviour
{
    public SpawnerCarne spawner;
    public AudioClip sonidoComer;

    private void OnTriggerEnter2D(Collider2D otro)
    {
        CrecimientoMonje crec = otro.GetComponent<CrecimientoMonje>();

        if (crec != null)
        {
            // sonido independiente
            if (sonidoComer != null)
                AudioSource.PlayClipAtPoint(sonidoComer, transform.position);

            crec.Crecer();

            if (spawner != null)
                spawner.CrearCarne();

            Destroy(gameObject);
        }
    }
}