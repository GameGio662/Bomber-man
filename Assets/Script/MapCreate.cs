using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TypeBlock;

public class MapCreate : MonoBehaviour
{
    public const int sizeX = 17;
    const int sizeY = 11;

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
                Spawn(x, y);

            }
        }
    }

    void Spawn(int x, int y)
    {
        if (x == 0 || x == sizeX - 1 || y == 0 || y == sizeY - 1)
        {
            SpawnSymbol(x, y);
            myGrid[x, y].SetType(TypeBlock_.Indistruttibili);
            var typeName = myGrid[x, y];
            typeName.name = "Indistruttibile";
        }
        else if (y % 2 == 0 || x % 2 == 0)
        {
            SpawnSymbol(x, y);
            myGrid[x, y].SetType(TypeBlock_.Distruttibili);
            var typeName = myGrid[x, y];
            typeName.name = "Distruttibile";
        } else
        {
            SpawnSymbol(x, y);
            myGrid[x, y].SetType(TypeBlock_.Indistruttibili);
            var typeName = myGrid[x, y];
            typeName.name = "Indistruttibile";
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
