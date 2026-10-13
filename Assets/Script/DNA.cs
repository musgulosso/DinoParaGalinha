using UnityEngine;

public class DNA : MonoBehaviour
{
    public Sprite   _dino;// variavel para pegar a Imagem Dino
    
    private void OnTriggerEnter2D(Collider2D collision) //Trigger, serve para objetos que vão fazer uma ação
    {   //verifico se quem colidiu foi o objeto tem a tag Player
        if (collision.tag == "Player")
        {
            //Puxo a caracteristica e coloco na variavel, nele pego o objeto que colidiu e procuro o componente de Sprite tb
            SpriteRenderer sr = collision.GetComponent<SpriteRenderer>();

            //vejo se oq foi encontrado é nada, mas como a galinha tem, então sempre vai rolar
            if (sr != null)
                sr.sprite = _dino; //mudo a imagem, está sem aspas pq só tem uma linha
            collision.transform.localScale = new Vector3(-0.6089486f, 0.5732f, 1f);

            Debug.Log("Evoluiu");
            Destroy(gameObject); //Após o toque rola a destruição
        }
    }
}
