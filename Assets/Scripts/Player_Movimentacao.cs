using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movimentacao : MonoBehaviour
{
    private Rigidbody2D playerRb;

    [Header("Atributos")]
    public float velocidadeMovimento;

    [Header ("Limite Movimentacao")]
    public float limiteXMin;
    public float limiteXMax;
    public float limiteYMin;
    public float limiteYMax;

    public Vector3 vt3LimiteMovimentacao;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ConfigurarQualidade();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        playerRb.velocity = new Vector2(moveHorizontal * velocidadeMovimento, moveVertical * velocidadeMovimento);
        LimitarMovimento(transform.position.x, transform.position.y);
    }
    
    private void LimitarMovimento(float posicaoX, float posicaoY)
    {
        vt3LimiteMovimentacao = new Vector3(Mathf.Clamp(posicaoX, limiteXMin, limiteXMax),
                                        Mathf.Clamp(posicaoY, limiteYMin, limiteYMax), 0);
        transform.position = vt3LimiteMovimentacao;
    }

    private void ConfigurarQualidade()
    {
        QualitySettings.vSyncCount = 1;
    }
}
