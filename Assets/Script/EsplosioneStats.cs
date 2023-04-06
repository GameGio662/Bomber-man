using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/EsplosioneStats/Stats", fileName = "EsplosioneStats")]

public class EsplosioneStats : ScriptableObject
{
    [SerializeField] private float up;
    [SerializeField] private float right;


    public float Up { get => up; }
    public float Right { get => right; }
}
