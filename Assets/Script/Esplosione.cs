using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esplosione : MonoBehaviour
{

    [SerializeField] private EsplosioneStats esplosioneStats;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(esplosioneStats.Right, esplosioneStats.Up);
        rb.AddForce(new Vector2(esplosioneStats.Right, esplosioneStats.Up), ForceMode2D.Impulse);
        Timer();
    }

    float time;
    void Timer()
    {
        time += Time.deltaTime;

        if (time >= 0.5f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Distruttibile")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if(collision.gameObject.name == "Indistruttibile")
            Destroy(gameObject);

        if (collision.gameObject.name == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
