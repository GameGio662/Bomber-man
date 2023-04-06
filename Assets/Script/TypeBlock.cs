using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class TypeBlock : MonoBehaviour
{
    public enum TypeBlock_
    {
        Distruttibili,
        Indistruttibili
    }

    public Vector3 pos;
    const int enumSize = 3;
    SpriteRenderer sp;

    public Color[] symbolColors = new Color[enumSize];


    [SerializeField] public TypeBlock_ typeBlock;

    private void Awake()
    {
        sp = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetType(TypeBlock_ type)
    {

        typeBlock = type;
        sp.material.color = symbolColors[(int)typeBlock];

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spawn")
        {
            Destroy(gameObject);
        }
    }


}
