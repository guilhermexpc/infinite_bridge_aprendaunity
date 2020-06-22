﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private PlayerController _PlayerController;

    [Header("Player")]
    public float velocidadeMovimento;
    [Header("Player Limite Movimentacao")]
    public float limiteXMin;
    public float limiteXMax;
    public float limiteYMin;
    public float limiteYMax;

    [Header("Config Objetos")]
    public GameObject gbPontePrefab;
    public GameObject gbBarrilPrefab;

    public float velocidadePonte;
    public float objetoDistanciaDestruir;
    public float tamanhoPonte;

    [Header("Config Barril")]
    public float barrilPosYTop;
    public float barrilPosYDown;
    public int barrilOrderTop;
    public int barrilOrderDown;
    public float barrilTempoSpawn;

    [Header("Globals")]
    public float score;
    public float posXPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _PlayerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;

        StartCoroutine(SpawnBarril());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        posXPlayer = _PlayerController.transform.position.x;
    }

    public void InstanciarPonte()
    {

    }

    public void Pontuar(int qtdPontos)
    {
        score += qtdPontos;
    }

    IEnumerator SpawnBarril()
    {
        yield return new WaitForSeconds(barrilTempoSpawn);

        float posY;
        int order;
        int rng = Random.Range(0, 100);
        if (rng < 50)
        {
            posY = barrilPosYTop;
            order = barrilOrderTop;
        }
        else
        {
            posY = barrilPosYDown;
            order = barrilOrderDown;
        }

        GameObject barrilTemp = Instantiate(gbBarrilPrefab);
        barrilTemp.transform.position = new Vector3(barrilTemp.transform.position.x, posY, 0);
        barrilTemp.GetComponent<SpriteRenderer>().sortingOrder = order;

        StartCoroutine(SpawnBarril());
    }
}
