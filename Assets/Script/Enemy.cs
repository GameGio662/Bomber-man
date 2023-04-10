using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int Turn, hitCount;
    float speed = 2.5f;

    Rigidbody2D rb;
    UIManager UI;
    GameManager GM;
    void Start()
    {
        time = 1;
        rb = GetComponent<Rigidbody2D>();
        UI = FindObjectOfType<UIManager>();
        GM = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        if (GM.gameStatus == GameManager.GameStatus.gameRunning)
            Move();
    }

    float time;
    void Move()
    {

        time += Time.deltaTime;
        if (time >= 1)
        {
            time = 0;
            Turn = Random.Range(0, 4);
            TurnEnemy(Turn);
        }
    }

    void TurnEnemy(int n)
    {
        switch (n)
        {
            case 0:
                rb.velocity = Vector2.down * speed;
                break;
            case 1:
                rb.velocity = Vector2.up * speed;
                break;
            case 2:
                rb.velocity = Vector2.left * speed;
                break;
            case 3:
                rb.velocity = Vector2.right * speed;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Distruttibile")
        {
            Turn = Random.Range(0, 3);
            hitCount++;
            if (hitCount >= 5)
            {
                hitCount = 0;
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.name == "Indistruttibile")
        {
            Turn = Random.Range(0, 3);
        }

        if (collision.gameObject.tag == "Bomb")
        {
            Destroy(gameObject);
            UI.EnemyScore();
            UI.EnemyCount -= 1;
        }
    }
}
