using UnityEngine;

public class StatsMonje : MonoBehaviour
{
    [Header("Vida")]
    public int vidaMax = 3;
    public int vidaAct = 3;

    [Header("Velocidad")]
    public float velNormal = 4f;
    public float velLenta = 2f;
    public float velAct = 4f;

    private void Awake()
    {
        vidaAct = vidaMax;
        velAct = velNormal;
    }

    public void PonerLenta()
    {
        velAct = velLenta;
    }

    public void PonerNormal()
    {
        velAct = velNormal;
    }

    public void QuitarVida(int daño)
    {
        vidaAct -= daño;

        if (vidaAct < 0)
            vidaAct = 0;

        Debug.Log("Vida restante: " + vidaAct);

        if (vidaAct <= 0)
        {
            Debug.Log("El monje murió");
            // Aquí luego podemos poner Game Over
        }
    }
}