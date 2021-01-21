using System.Collections;
using UnityEngine;

public class Armadilhas : MonoBehaviour
{
    public int dano;
    PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void Dano()
    {
        player.Energia -= dano;
        player.barraVida.value -= dano * .01f;
    }
}
