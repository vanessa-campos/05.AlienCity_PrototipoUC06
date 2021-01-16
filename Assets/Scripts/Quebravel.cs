using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quebravel : MonoBehaviour
{
    public int resistencia;

    private void Update()
    {
        if(resistencia <= 0)
        {
            Destroy(gameObject);
        }
    }
}
