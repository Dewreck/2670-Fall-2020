using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : FloatData
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        value = 1f;
    }
}
