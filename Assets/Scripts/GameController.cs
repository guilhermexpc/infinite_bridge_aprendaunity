using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [Header("Player")]
    public float velocidadeMovimento;
    [Header("Player Limite Movimentacao")]
    public float limiteXMin;
    public float limiteXMax;
    public float limiteYMin;
    public float limiteYMax;

    [Header("Config Objetos")]
    public float velocidadePonte;
    public float objetoDistanciaDestruir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
