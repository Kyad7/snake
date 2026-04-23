using UnityEngine;

public class ZonaLenta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otro)
    {
        StatsMonje st = otro.GetComponent<StatsMonje>();
        if (st != null) st.PonerLenta();
    }

    private void OnTriggerExit2D(Collider2D otro)
    {
        StatsMonje st = otro.GetComponent<StatsMonje>();
        if (st != null) st.PonerNormal();
    }
}