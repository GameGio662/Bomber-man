using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Bomb : MonoBehaviour
{
    int count;
    [SerializeField] GameObject Esplosione1, Esplosione2, Esplosione3, Esplosione4;
    private void Start()
    {

    }

    private void Update()
    {

        TimerBoom();
        Destruction();
    }

    float time;
    void TimerBoom()
    {
        time += Time.deltaTime;
        if (time >= 5)
            Destruction();

    }
    void Destruction()
    {
        //Destroy(gameObject);
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, transform.right, 1f);
        Debug.DrawRay(transform.position, transform.right * 1, Color.black);
        hit = Physics2D.Raycast(transform.position, transform.right, -1f);
        Debug.DrawRay(transform.position, transform.right * -1, Color.black);
        hit = Physics2D.Raycast(transform.position, transform.up, 1f);
        Debug.DrawRay(transform.position, transform.up * 1, Color.black);
        hit = Physics2D.Raycast(transform.position, transform.up, -1f);
        Debug.DrawRay(transform.position, transform.up * -1, Color.black);

        if (hit.collider.tag == "Distruttibile")
            Explosion();
        if (hit.collider.tag == "Player")
            Explosion();
    }

    void Explosion()
    {
        Vector2 expos = transform.position;
        expos.x = Mathf.Round(expos.x);
        expos.y = Mathf.Round(expos.y);

        for (int i = 0; i < 4; i++)
        {
            count++;
        }
        if (count == 0)
            Instantiate(Esplosione1, expos, Quaternion.identity);
        if (count == 1)
            Instantiate(Esplosione2, expos, Quaternion.identity);
        if (count == 2)
            Instantiate(Esplosione3, expos, Quaternion.identity);
        if (count == 3)
            Instantiate(Esplosione4, expos, Quaternion.identity);
        if (count == 4)
            Destroy(gameObject);
    }
}
