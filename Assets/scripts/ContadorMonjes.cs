using UnityEngine;
using TMPro;

public class ContadorMonjes : MonoBehaviour
{
    public CrecimientoMonje crec;
    public TextMeshProUGUI txt;

    void Update()
    {
        if (crec == null || txt == null) return;

        int total = 1 + crec.cola.Count;

        txt.text = "Monjes: " + total;
    }
}