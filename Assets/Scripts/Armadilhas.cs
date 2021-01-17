using System.Collections;
using UnityEngine;

public class Armadilhas : MonoBehaviour
{
    PlayerController player;
    public int dano;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void Dano()
    {
        player.Vida -= dano;
        Debug.Log(player.Vida);
    }
}
