using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public MoveBase Base { get; set; }

    public Move(MoveBase mBase)
    {
        Base = mBase;
    }
}
