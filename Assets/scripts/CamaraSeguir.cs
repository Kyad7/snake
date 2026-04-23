using UnityEngine;

public class CamaraSeguir : MonoBehaviour
{
    public Transform obj;
    public float vel = 5f;
    public Vector3 offset;

    private float zFijo;

    void Start()
    {
        zFijo = transform.position.z; // guarda el Z inicial
    }

    void LateUpdate()
    {
        if (obj == null) return;

        Vector3 posDeseada = obj.position + offset;

        // 👇 aquí bloqueamos el Z
        posDeseada.z = zFijo;

        Vector3 posSuave = Vector3.Lerp(transform.position, posDeseada, vel * Time.deltaTime);

        transform.position = posSuave;
    }
}