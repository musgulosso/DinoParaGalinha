using UnityEngine;

public class FOGO : MonoBehaviour
{
    public Sprite _frango;
    public Sprite _dinoMorto;

    private GameController _gameController;

    void Start()
    {
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    void Update()
    {
        
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

                _gameController._chaoVelocidade = 0;
                Destroy(gameObject);
                Debug.Log("Morreu");
            }
            else
            {
                SpriteRenderer sr = collison.GetComponent<SpriteRenderer>();
                if (sr != null)
                    sr.sprite = _dinoMorto;
                collison.transform.localScale = new Vector3(-0.6106539f, 0.6609f, 1f);

                _gameController._chaoVelocidade = 0;
                Destroy(gameObject);
                Debug.Log("Morreu");
            }
        }
    }
}
