using UnityEngine;

public class SeguidorMonje : MonoBehaviour
{
    public Transform obj;
    public float distMin = 0.45f;
    public float vel = 8f;

    private SpriteRenderer sp;
    private Animator anim;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (obj == null) return;

        Vector3 dir = obj.position - transform.position;
        dir.z = 0;

        if (dir.magnitude > distMin)
        {
            Vector3 mov = dir.normalized * vel * Time.deltaTime;
            transform.position += mov;

            if (anim != null)
                anim.SetBool("correr", true);

            if (sp != null)
            {
                if (mov.x < -0.01f) sp.flipX = true;
                else if (mov.x > 0.01f) sp.flipX = false;
            }
        }
        else
        {
            if (anim != null)
                anim.SetBool("correr", false);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, obj.position.z);
    }
}