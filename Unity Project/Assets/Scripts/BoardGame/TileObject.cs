using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tile", menuName = "Tile")]
public class TileObject : ScriptableObject
{
    public string type;
    public string description;

    public Material artwork;


}
