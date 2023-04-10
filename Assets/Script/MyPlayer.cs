using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyPlayer : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] GameObject Bomb;

    Rigidbody2D rb;
    UIManager UI;
    GameManager GM;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UI = FindObjectOfType<UIManager>();
        GM = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (GM.gameStatus == GameManager.GameStatus.gameRunning)
        {
            Move();
            SetBomb();

        }
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
        if (Input.GetKeyDown(KeyCode.Space) && UI.bombCount > 0)
        {
            Vector2 bombpos = transform.position;
            bombpos.x = Mathf.Round(bombpos.x);
            bombpos.y = Mathf.Round(bombpos.y);
            Instantiate(Bomb, bombpos, Quaternion.identity);
            UI.bombCount--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomb" || collision.gameObject.tag == "Enemy")
            SceneManager.LoadScene("Napoli", LoadSceneMode.Single);
    }
}
