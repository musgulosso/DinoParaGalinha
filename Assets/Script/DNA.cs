using UnityEngine;

public class DNA : MonoBehaviour
{
    public GameObject _dinoPrefab;    //variavel para pegar a Imagem do Dino
    public GameObject _galinhaPrefab; //variavel para pegar a Imagem da Galinha
    private bool _DNAInstanciad = false;
    private GameController _gameController;

    void Start()
    {   //outro jeito de puxar as informações da classe, esse modelo é o atual, não precisa ter tanto comando quanto FindObjectOfType
        _gameController = FindAnyObjectByType<GameController>();
    }

    void Update()
    {
        if (_DNAInstanciad == false)
        {
            if(transform.position.x <= 0)
            {
                _DNAInstanciad = true;
                GameObject dnaTemporario = Instantiate(_gameController._gamePrefabDNA);
                dnaTemporario.transform.position = new Vector3(transform.position.x + 30, transform.position.y, transform.position.z);
            }
        }
        if (transform.position.x < _gameController._DNADestruido)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //Trigger, serve para objetos que vão fazer uma ação
    {   //verifico se quem colidiu foi o objeto tem a tag Player
        if (collision.tag == "Player")
        {   
            //isso aqui é para galinha virar dino
            if (_gameController._evolucao == 0)
            {
                _gameController._evolucao = 1;
                
                //vejo se oq foi encontrado é nada, mas como a galinha tem, então sempre vai rolar
                GameObject dnaDino = Instantiate(_dinoPrefab);
                collision.transform.localScale = new Vector3(-0.6089486f, 0.5732f, 1f);

                Debug.Log("Evoluiu");
                Destroy(collision.gameObject); //destroi a galinha
                Destroy(gameObject); //Após o toque rola a destruição
            }
            //dino virar galinha
            else 
            {
                _gameController._evolucao = 0;
                GameObject dnaGalinha = Instantiate(_galinhaPrefab);
                collision.transform.localScale = new Vector3(-0.3341638f, 0.3123f, 1f);

                Debug.Log("Evoluiu");
                Destroy(collision.gameObject); //destroi o dino
                Destroy(gameObject); //Após o toque rola a destruição
            }
        }
    }
    private void FixedUpdate()
    {
        MoviDNA();
    }
    private void MoviDNA()
    {
        transform.Translate(Vector2.left * _gameController._velocidade * Time.deltaTime);
    }
}
