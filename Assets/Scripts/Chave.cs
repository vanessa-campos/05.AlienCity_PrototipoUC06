using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : MonoBehaviour
{
    Porta porta;

    private void Start()
    {
        porta = FindObjectOfType<Porta>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            porta.Chaves -= 1;
            Destroy(gameObject);
        }
    }
}
