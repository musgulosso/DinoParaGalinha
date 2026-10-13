using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentaPlayer : MonoBehaviour
{
    private Rigidbody2D rb; //Pego faço essa variavel ser um objeto do Rb

    public float _jumpForca = 650f; //Coloco uma força

    private void Awake() //Isso vem antes de frame ou o Start, ele é um metodo unico, usado mais para o rb mesmo
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {   //seto o direcionamento da tecla espaço
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Jump();
        }
    }

    public void Jump()
    {   //serve para mudar a direção do eixo
        rb.AddForce(new Vector2(0, _jumpForca));
    }
}
//Agora eu me tornei a morte, o destruidor de Mundos