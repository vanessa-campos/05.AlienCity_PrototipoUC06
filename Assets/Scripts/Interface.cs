using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Interface: MonoBehaviour
{
    public Text vidasText;
    public Text pedrasText;
    public Image[] IconesChaves;
    Porta porta;

    private int pedras;
    public int Pedras 
    {
        get { return pedras; }
        set { pedras = value;
            pedrasText.text = "x" + pedras;
        }
     }

    private void Start()
    {        
        porta = FindObjectOfType<Porta>();
        foreach(Image chave in IconesChaves)
            chave.color = new Vector4(0, 0, 0, 0); 
    }
    private void Update()
    {
        vidasText.text = "VIDAS: " + PlayerPrefs.GetInt("PPVida");
    }

    public void IconeChave()
    {
        IconesChaves[porta.chaves].color = new Vector4(1, 1, 1, 1);
    }
}
