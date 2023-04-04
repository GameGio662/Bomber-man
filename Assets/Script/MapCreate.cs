using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    public const int sizeX = 18;
    const int sizeY = 10;

    [SerializeField]
    public TypeBlock[,] myGrid = new TypeBlock[sizeX, sizeY];

    [SerializeField] GameObject item;

    void Awake()
    {
        InizializeMatrix();
    }

    void Update()
    {

    }

    void InizializeMatrix()
    {
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                SpawnSymbol(x, y);

            }
        }
    }

    void SpawnSymbol(int x, int y)
    {
        GameObject tmp = Instantiate(item);

        tmp.transform.SetParent(this.transform);
        tmp.transform.localPosition = new Vector2(x, y);
        TypeBlock symbolTmp = tmp.GetComponentInChildren<TypeBlock>();

        symbolTmp.pos = new Vector2(x, y);

        myGrid[x, y] = symbolTmp;
    }

}
