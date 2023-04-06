using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    [SerializeField] float speed;
    [HideInInspector] public int bombCount = 3;

    [SerializeField] GameObject Bomb;

    Vector2 dir;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        Move();
        SetBomb();
    }

    void Move()
    {
        float ws = Input.GetAxis("Horizontal");
        float ad = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(ws, ad);

        rb.velocity = move * speed;
    }

    void SetBomb()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bombCount > 0)
        {
            Vector2 bombpos = transform.position;
            bombpos.x = Mathf.Round(bombpos.x);
            bombpos.y = Mathf.Round(bombpos.y);
            Instantiate(Bomb, bombpos, Quaternion.identity);
            bombCount--;
        }
    }
}
