using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerController: MonoBehaviour
{
    public float MoveSpeed;
    public float RotationSpeed;
    public Slider barraVida;
    public Text pontosText;
    public Text energiaText;
    public GameManager GM;
    public AudioSource pedraSound;
    public AudioSource chaveSound;
    public AudioSource sirenSound;

    Vector3 move = Vector3.zero;
    Vector3 gravidade = Vector3.zero;
    private bool jump = false;
    private int vida;
    CharacterController _characterController;
    Animator _animator;
    Porta porta;
    AudioSource jumpSound;

    private int pontos;
    public int Pontos
    {
        get { return pontos; }
        set { pontos = value;
            pontosText.text = "Pontuação: " + pontos;
        }
    }

    private int energia;
    public int Energia
    {
        get { return energia; }
        set { energia = value;
            energiaText.text = energia.ToString(); 
            if(energia < 0)
            {
                energia = 0;
            }
        }
    }

    private void Awake()
    { 
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();
        porta = FindObjectOfType<Porta>();
    }

    // Start is called before the first frame update
    void Start() 
    { 
        Pontos = 0;
        Energia = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //Movimentação
        Vector3 move = Input.GetAxis("Vertical") * transform.TransformDirection(Vector3.forward) * MoveSpeed;
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime, 0));

        //Pulo
        if (!_characterController.isGrounded)
        {
            gravidade += Physics.gravity * Time.deltaTime;
        }
        else
        {
            gravidade = Vector3.zero;
            if (jump)
            {
                gravidade.y = 10f;
                jump = false;
            }
        }
        move += gravidade;
        _characterController.Move(move * Time.deltaTime);

        //Chamar o método para animar
        Anima();

        //Tirar uma vida quando a barra esvaziar e salvar o valor em PlayerPrefs
        vida = PlayerPrefs.GetInt("PPVida");
        if (energia <= 0)
        {
            vida -= 1;
            PlayerPrefs.SetInt("PPVida", vida);
            GM.Jogo();
        }
        if (vida <=0)
        {
            GM.Fim();
        }
    }

    //Método para configurar os parâmetros do Animator
    void Anima()
    {
        if (!Input.anyKey)
        {
            _animator.SetTrigger("Parado");
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                _animator.SetTrigger("Pula");
                jump = true;
                jumpSound.Play();
            }
            else
            {
                _animator.SetTrigger("Corre");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Chave"))
        {
            chaveSound.Play();
            if (porta.chaves <= 0)
            {
                sirenSound.Play();
            }
        }
        if (other.gameObject.CompareTag("Pedra"))
        {
            pedraSound.Play();
        }
    }
}
