using UnityEngine;

//Só para deixar claro, essa classe não vai ser usada, criei ela por uma questão de estudo, estudo esse para usar um cronometro

public class EstudoDeScript : MonoBehaviour
{
    public float        _tempoAtivacao = 3f;
    public float        _tempoIntervalo = 1f;
    void Start()
    {   /*
            invoca uma petição, usamos o nameof para indicar a função,
            o primeiro valor é o tempo que ele vai ser ativado para rodar, o segunfo é quantas vezes ele vai ser ativado
        */
        InvokeRepeating(nameof(Tempo_tick), _tempoAtivacao, _tempoIntervalo);
    }

    // Já fiz isso no forms nas aulas do Enildo, só fui atrás para me adapitar 
    private void Tempo_tick()
    {
        Debug.Log("Ativou"); //A onde vai rolar o código quando foi ativado
    }
}
