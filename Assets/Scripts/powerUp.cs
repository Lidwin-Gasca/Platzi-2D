using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    public enum PowerUpType//In the C# language, enum (also called enumeration) is a user-defined value type used to represent a list of named integer constants. It is created using the enum keyword inside a class, structure, or namespace. It improves a program’s readability, maintainability and reduces complexity.
    {
        FireRateIncrease,  //enum_name (PowerUpType) is the name you want to give to your enum list. We use a comma (,) to separate the items in the enumeration list.
        PowerShot
    }
    public PowerUpType powerUpType;
}
