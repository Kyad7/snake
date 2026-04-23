using System.Collections.Generic;
using UnityEngine;

public class MoverMonje : MonoBehaviour
{
    public StatsMonje st;
    public Animator anim;
    public SpriteRenderer sp;

    [Header("Movimiento")]
    public Vector2 dir;
    public float distHist = 0.2f;

    [HideInInspector] public List<Vector3> hist = new List<Vector3>();

    private void Start()
    {
        if (st == null) st = GetComponent<StatsMonje>();
        if (anim == null) anim = GetComponent<Animator>();
        if (sp == null) sp = GetComponent<SpriteRenderer>();

        hist.Add(transform.position);
    }

    private void Update()
    {
        LeerInput();
        Mover();
        Animar();
        GuardarHistorial();
    }

    void LeerInput()
    {
        float x = 0f;
        float y = 0f;

        if (Input.GetKey(KeyCode.A)) x = -1f;
        if (Input.GetKey(KeyCode.D)) x = 1f;
        if (Input.GetKey(KeyCode.W)) y = 1f;
        if (Input.GetKey(KeyCode.S)) y = -1f;

        dir = new Vector2(x, y).normalized;
    }

    void Mover()
    {
        if (dir != Vector2.zero)
        {
            transform.position += (Vector3)(dir * st.velAct * Time.deltaTime);
        }
    }

    void Animar()
    {
        bool mov = dir != Vector2.zero;

        if (anim != null)
        {
            anim.SetBool("correr", mov);
        }

        if (sp != null)
        {
            if (dir.x < 0) sp.flipX = true;
            else if (dir.x > 0) sp.flipX = false;
        }
    }

    void GuardarHistorial()
    {
        if (hist.Count == 0)
        {
            hist.Add(transform.position);
            return;
        }

        float d = Vector3.Distance(hist[hist.Count - 1], transform.position);

        if (d >= distHist)
        {
            hist.Add(transform.position);
        }
    }
}