using System.Collections;
using UnityEngine;

public class Lava : MonoBehaviour
{
    Armadilhas armadilha;
    bool tocando = false;
    float time = 0;
    int x = 0;

    private void Start()
    {
        armadilha = GetComponent<Armadilhas>();
    }

    private void Update()
    {
        if (tocando)
        {
            if (time > 0)
            {
                if ((x % 60) == 0)
                {
                    armadilha.Dano();
                }
            }
            time += Time.deltaTime;
            x += 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tocando = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tocando = false;
            time = 0;
            x = 0;
        }
    }
}


