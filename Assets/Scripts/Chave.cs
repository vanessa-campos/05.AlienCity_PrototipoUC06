using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Chave : MonoBehaviour
{
    Porta porta;
    Interface hud;

    private void Start()
    {
        porta = FindObjectOfType<Porta>();
        hud = FindObjectOfType<Interface>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            porta.chaves -= 1;
            Destroy(gameObject);
            hud.IconeChave();
        }
    }
}
