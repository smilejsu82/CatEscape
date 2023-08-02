using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private GameObject catGo;
    private GameObject hpGaugeGo;

    void Start()
    {
        this.catGo = GameObject.Find("cat");
        this.hpGaugeGo = GameObject.Find("hpGauge");

        Debug.LogFormat("this.catGo: {0}, this.hpGaugeGo: {1}", this.catGo, this.hpGaugeGo);

    }

    public void DecreaseHp()
    {
        Image hpGauge = this.hpGaugeGo.GetComponent<Image>();
        hpGauge.fillAmount -= 0.1f;
    }
}
