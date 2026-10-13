using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    private GameController _gameController;

    void Start()
    {
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        MoveChao();
    }

    void MoveChao()
    {
        transform.Translate(Vector2.left * _gameController._chaoVelocidade * Time.deltaTime);
        /*tranform e o tranlate é para mudar a posição do objeto
        Vector2 é por causa que só usaremos X e Y, multiplicamos pelo valor da velocidade e o deltaTime é para não mudar de valor independente do tempo*/
    }
}
