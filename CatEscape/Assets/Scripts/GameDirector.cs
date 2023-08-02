using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private GameObject catGo;
    private GameObject hpGaugeGo;
    public GameObject gameOverGo;
    public Text txtScoreGo;
    private int score;
    private bool isGameOver;

    void Start()
    {
        this.gameOverGo.SetActive(false);
        this.catGo = GameObject.Find("cat");
        this.hpGaugeGo = GameObject.Find("hpGauge");

        Debug.LogFormat("this.catGo: {0}, this.hpGaugeGo: {1}", this.catGo, this.hpGaugeGo);
        this.UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        this.txtScoreGo.text = this.score.ToString();
    }

    //public void DecreaseHp()
    //{
    //    Image hpGauge = this.hpGaugeGo.GetComponent<Image>();
    //    hpGauge.fillAmount -= 0.1f;
    //}

    public void UpdateHpGauge()
    {
        CatController catController = this.catGo.GetComponent<CatController>();
        int hp = catController.GetHp();
        int maxHp = catController.GetMaxHp();
        float fillAmount = (float)hp / maxHp;

        Debug.LogFormat("{0}/{1} ({2})", hp, maxHp, fillAmount);

        Image hpGauge = this.hpGaugeGo.GetComponent<Image>();
        hpGauge.fillAmount = fillAmount;
    }

    public void GameOver()
    {
        this.isGameOver = true;
        GameObject arrowGeneratorGo = GameObject.Find("ArrowGenerator");
        ArrowGenerator arrowGenerator = arrowGeneratorGo.GetComponent<ArrowGenerator>();
        arrowGenerator.StopGenerate();

        this.ShowGameOverUI();
    }

    public void AddScore(int score) {

        if (this.isGameOver) return;

        this.score += score;

        Debug.LogFormat("score: {0}", this.score);
        this.UpdateScoreUI();
    }

    public void ShowGameOverUI()
    {
        this.gameOverGo.SetActive(true);
    }
}
