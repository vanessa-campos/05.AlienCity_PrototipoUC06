using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedra : MonoBehaviour
{
    PlayerController player;
    Interface hud;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        hud = FindObjectOfType<Interface>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.Pontos += 20;
            hud.Pedras += 1;
            Destroy(gameObject);
        }
    }
}
