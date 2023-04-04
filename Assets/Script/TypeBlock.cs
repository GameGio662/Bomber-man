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
    const int enumSize = 4;
    SpriteRenderer sp;

    public colro[] symbolColors = new Renderer[enumSize];


    [SerializeField] public TypeBlock_ typeBlock;

    private void Awake()
    {
        Type();
    }

    private void Start()
    {
        sp = GetComponentInChildren<SpriteRenderer>();
    }

    void Type()
    {
        typeBlock = (TypeBlock_)Random.Range(0, 3);
        sp.color = symbolColors[(int)typeBlock];

    }
}
