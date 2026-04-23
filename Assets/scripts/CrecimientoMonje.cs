using System.Collections.Generic;
using UnityEngine;

public class CrecimientoMonje : MonoBehaviour
{
    public GameObject prefabMonje;
    public List<Transform> cola = new List<Transform>();

    public void Crecer()
    {
        if (prefabMonje == null)
        {
            Debug.LogError("Falta asignar el prefabMonje.");
            return;
        }

        Vector3 posNueva = transform.position;

        if (cola.Count > 0)
            posNueva = cola[cola.Count - 1].position;

        posNueva.z = transform.position.z; // mismo Z que el monje principal

        GameObject nuevo = Instantiate(prefabMonje, posNueva, Quaternion.identity, transform.parent);

        nuevo.name = "MonjeCola_" + cola.Count;

        SpriteRenderer sr = nuevo.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sortingLayerName = GetComponent<SpriteRenderer>().sortingLayerName;
            sr.sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + 1;
        }

        SeguidorMonje seg = nuevo.GetComponent<SeguidorMonje>();
        if (seg == null)
            seg = nuevo.AddComponent<SeguidorMonje>();

        if (cola.Count == 0)
            seg.obj = transform;
        else
            seg.obj = cola[cola.Count - 1];

        seg.distMin = 0.45f;
        seg.vel = 8f;

        cola.Add(nuevo.transform);
    }
}