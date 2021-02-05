using System.Collections;
using UnityEngine;

public class Lava : Armadilhas
{
    float time = 0;
    int x = 0;

    private void Update()
    {
        if (ativada)
        {
            if (time > 0)
            {
                if ((x % 60) == 0)
                {
                    Dano();
                }
            }
            time += Time.deltaTime;
            x += 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ativada = false;
            time = 0;
            x = 0;
        }
    }
}


