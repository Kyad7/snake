using UnityEngine;

public class ChoqueSnake : MonoBehaviour
{
    public StatsMonje st;

    private void Start()
    {
        if (st == null)
            st = GetComponent<StatsMonje>();
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Muro"))
        {
            st.QuitarVida(1);
            Debug.Log("Vida actual: " + st.vidaAct);
        }
    }
}