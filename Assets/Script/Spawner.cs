using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Player;
    float time;
    void Start()
    {
        Vector2 dir = transform.position;
        dir.x = Mathf.Round(dir.x);
        dir.y = Mathf.Round(dir.y);

        Instantiate(Player, dir, Quaternion.identity);

    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time > 0.3f)
            Destroy(gameObject);
    }

}
