using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum tileType
{
    Ship, 
    Water,
    Turret,
    Porthole
}
public class Tiles : MonoBehaviour
{
    [SerializeField]
    tileType TileType;
    

    
}
