using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    public GameObject panelMenu;
    public GameObject panelCreditos;
    public GameObject levelCompletedText;
    public GameObject gameOverText;
    int _vida = 2;
    int som = 1;

    public void PlayClicked()
    {
        PlayerPrefs.DeleteKey("PPVida");
        PlayerPrefs.DeleteKey("PPAberto");
        PlayerPrefs.SetInt("PPVida", _vida);
        Jogo();
    }

    public void CreditsClicked()
    {
        panelMenu.SetActive(false);
        panelCreditos.SetActive(true);
    }

    public void SairClicked()
    {
        Application.Quit();
    }

    public void VoltarClicked()
    {
        panelCreditos.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void Toggle()
    {
        if (som == 0)
        {
            som = 1;
        }
        else
        {
            som = 0;
        }
        PlayerPrefs.SetInt("PPSom", som);
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerPrefs.SetInt("PPSom", som);
            Invoke("Menu", 5f);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (PlayerPrefs.GetInt("PPAberto") == 1)
            {
                levelCompletedText.SetActive(true);
            }
            else
            {
                gameOverText.SetActive(true);
            }

            if (Input.anyKeyDown)
            {
                Menu();
            }
        }
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                Menu();
            }
        }
    }

    void Menu()
    {
        SceneManager.LoadScene("1.Menu");
    }

    public void Jogo()
    {
        SceneManager.LoadScene("2.Jogo");
    }

    public void Fim()
    {
        SceneManager.LoadScene("3.Fim");
    }

}
