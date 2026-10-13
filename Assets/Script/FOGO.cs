using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class FOGO : MonoBehaviour
{
    public Sprite       _frango;
    public Sprite       _dinoMorto;

    // é um jeito de aparecer no inspetor, mas que não afete o código, ou que eu manipule em outras classes, afinal, é private
    [SerializeField] private bool _fogoInstanciado = false;

    
    private GameController _gameController;

    void Start()
    {
        _gameController = FindAnyObjectByType<GameController>();
    }

    void Update()
    {
        if (_fogoInstanciado == false)
        {
            if (transform.position.x <= 0)
            {
                _fogoInstanciado = true;

                GameObject fogo = Instantiate(_gameController._gamePrefabFogo);
                fogo.transform.position = new Vector3(transform.position.x + 30, transform.position.y, transform.position.z);
            }
        }
        if (transform.position.x < _gameController._fogoDestruido)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {   //Nova forma para verificar quem bateu no objeto com Trigger ativo
        if (collison.CompareTag("Player"))
        {
            if (_gameController._evolucao == 0)
            {
                SpriteRenderer sr = collison.GetComponent<SpriteRenderer>();
                if (sr != null)
                    sr.sprite = _frango;
                collison.transform.localScale = new Vector3(-0.6106539f, 0.6609f, 1f);

                _gameController._velocidade = 0;
                Destroy(gameObject);
                Debug.Log("Morreu");
            }
            else
            {
                SpriteRenderer sr = collison.GetComponent<SpriteRenderer>();
                if (sr != null)
                    sr.sprite = _dinoMorto;
                collison.transform.localScale = new Vector3(-0.6106539f, 0.6609f, 1f);

                _gameController._velocidade = 0;
                Destroy(gameObject);
                Debug.Log("Morreu");
            }
        }
    }
    private void FixedUpdate()
    {
        MoveFogo();
    }
    private void MoveFogo()
    {
        transform.Translate(Vector2.left * _gameController._velocidade  * Time.deltaTime);
    }
}
