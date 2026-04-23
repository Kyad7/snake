using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnerCarne : MonoBehaviour
{
    public Tilemap mapaCesped;
    public GameObject prefabCarne;

    [Header("Cantidad")]
    public int cantInicial = 3;

    [Header("Intentos")]
    public int maxIntentos = 100;

    private BoundsInt area;

    void Start()
    {
        if (mapaCesped != null)
        {
            area = mapaCesped.cellBounds;

            for (int i = 0; i < cantInicial; i++)
            {
                CrearCarne();
            }
        }
    }

    public void CrearCarne()
    {
        if (mapaCesped == null || prefabCarne == null) return;

        for (int i = 0; i < maxIntentos; i++)
        {
            int x = Random.Range(area.xMin, area.xMax);
            int y = Random.Range(area.yMin, area.yMax);

            Vector3Int celda = new Vector3Int(x, y, 0);

            if (mapaCesped.HasTile(celda))
            {
                Vector3 pos = mapaCesped.GetCellCenterWorld(celda);

                Collider2D hit = Physics2D.OverlapCircle(pos, 0.2f);

                if (hit == null)
                {
                    Instantiate(prefabCarne, pos, Quaternion.identity);
                    return;
                }
            }
        }

        Debug.Log("No se encontró una posición válida para carne.");
    }
}