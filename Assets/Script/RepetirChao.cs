using UnityEngine;

public class RepetirChao : MonoBehaviour
{
    private GameController _gameController; //puxando a classe em uma variavel

    public bool _chaoInstanciado = false;

    void Start()
    {   //Find procura um onjetc de algum tipo usando o typeof que ai mostrando onde procurar e o as Game[...] ele pega o script da classe
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    void Update()
    {   //vejo se o chao que criei está falso, para a primeira vez sim
        if (_chaoInstanciado == false)
        {   //vejo se a posição do objeto é menor que X
            if (transform.position.x <= 0)
            {   //então mudo o valor dele já que vou instanciar ele
                _chaoInstanciado = true;

                //Então crio um variavel da classe GameObject que recebe a instancia com os devidos valores, que tem o objeto préfabricado
                GameObject ObjetoTemporarioChao = Instantiate(_gameController._gamePrefabChao);

                /*
                To pegando o objeto que vai ser criado e dando uma nova posição, para isso eu pego a posição e dou mais o tamanho dele,
                matenho o eixo Y e o eixo Z é desnecessário
                */
                ObjetoTemporarioChao.transform.position = new Vector3(transform.position.x + _gameController._chaoTamanho, transform.position.y, 0);
            }
        }

        if (transform.position.x < _gameController._chaoDestruido)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        MoveChao();
    }
    
    void MoveChao()
    {   
        transform.Translate(Vector2.left * _gameController._velocidade * Time.deltaTime);
        /*tranform e o tranlate é para mudar a posição do objeto
        Vector2 é por causa que só usaremos X e Y, multiplicamos pelo valor da velocidade e o deltaTime é para não mudar de valor independente do tempo*/
    }
}
//Agora eu me Tornei a morte, o destruidor de Mundos