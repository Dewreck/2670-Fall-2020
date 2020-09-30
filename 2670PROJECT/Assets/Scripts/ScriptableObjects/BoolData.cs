using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolData : ScriptableObject
{
    public bool value;

    public void SetTrue()
    {
        value = true;
    }

    public void SetFalse()
    {
        value = false;
    }
}
