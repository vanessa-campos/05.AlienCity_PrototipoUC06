using System.Collections;
using UnityEngine;

public class Armadilhas : MonoBehaviour
{
    public int dano;
    public bool ativada = false;
    PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ativada = true;
        }
    }

    public void Dano()
    {
        player.Energia -= dano;
        player.barraVida.value -= dano * .01f;
    }
}
