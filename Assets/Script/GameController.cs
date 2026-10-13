using UnityEngine;

public class GameController : MonoBehaviour
{
    public float        _velocidade; //essa velocidade pode mudar ao passar do tempo
    public float        _chaoTamanho;
    public float        _chaoDestruido;
    public float        _fogoDestruido;
    public float        _DNADestruido;
    public int          _evolucao = 0;
    public GameObject   _gamePrefabChao;
    public GameObject   _gamePrefabFogo;
    public GameObject   _gamePrefabDNA;
}
//Agora eu me Tornei a morte, o destruidor de Mundos