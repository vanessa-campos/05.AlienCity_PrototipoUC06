using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController: MonoBehaviour
{
    public float MoveSpeed;
    public float RotationSpeed;
    public int Vida = 100;
    private CharacterController _characterController;
    private Animator _animator;
    Vector3 move = Vector3.zero;
    Vector3 gravidade = Vector3.zero;
    private bool jump = false;

    //public Text pontosText;

    private int pontos = 0;
    public int Pontos
    {
        get { return pontos; }
        set { pontos = value;
            //pontosText.text = "PONTUAÇÃO: " + pontos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        pontos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Input.GetAxis("Vertical") * transform.TransformDirection(Vector3.forward) * MoveSpeed;
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime, 0));

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
        Anima();
    }

    // FixedUpdate is called once per physics update (default 100 times per second)
    private void FixedUpdate()
    {
    }

    void Anima()
    {
        if (!Input.anyKey)
        {
            _animator.SetTrigger("Parado");
        }
        else
        {
            if (Input.GetKeyDown("space"))
            {
                _animator.SetTrigger("Pula");
                jump = true;
            }
            else
            {
                _animator.SetTrigger("Corre");
            }
        }
    }
}
