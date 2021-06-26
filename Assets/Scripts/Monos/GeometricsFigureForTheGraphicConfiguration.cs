using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bellseboss/GeometricsFigureForTheGraphicConfiguration", fileName = "GeometricsFigureForTheGraphicConfiguration", order = 0)]
public class GeometricsFigureForTheGraphicConfiguration : ScriptableObject
{
    [SerializeField] private List<GameObject> listToGeometricGraphics;

    public GameObject GetFigure()
    {
        var random = Random.Range(0, listToGeometricGraphics.Count);
        return listToGeometricGraphics[random];
    }
}