using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    int count;
    [SerializeField] GameObject Esplosione1, Esplosione2, Esplosione3, Esplosione4;
    Collider2D collider;

    UIManager UI;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        UI = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        TimerBoom();
    }

    float time;
    void TimerBoom()
    {
        time += Time.deltaTime;
        if (time >= 3.5f)
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
        if (count >= 0)
            Instantiate(Esplosione1, expos, Quaternion.identity);
        if (count >= 1)
            Instantiate(Esplosione2, expos, Quaternion.Euler(0, 0, -90));
        if (count >= 2)
            Instantiate(Esplosione3, expos, Quaternion.Euler(0, 0, 90));
        if (count >= 3)
            Instantiate(Esplosione4, expos, Quaternion.Euler(0, 0, 180));
        if (count >= 4)
            Destroy(gameObject);

        UI.bombCount++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collider.isTrigger = false;
        }
    }
}
