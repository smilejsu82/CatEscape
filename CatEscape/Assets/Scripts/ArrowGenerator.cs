using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;  //������ ���� ���� 
    private float elapsedTime; //��� �ð� 
    private bool isGameOver;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isGameOver) return;

        //�������Ӹ��� Time.deltaTime�� ����ð��� �����ش� 
        this.elapsedTime += Time.deltaTime;

        //����ð��� 1�ʸ� �������ٸ� 
        if (this.elapsedTime > 1f) {
            //ȭ���� ����� 
            this.CreateArrow();
            //����ð� �ʱ�ȭ 
            this.elapsedTime = 0;   //0�ʺ��� 1�ʱ����� ���� �ֵ��� 
        }
    }

    private void CreateArrow()
    {
        //arrowGo : ������ ������ (�ν��Ͻ�)
        GameObject arrowGo = Instantiate(this.arrowPrefab);
        //Random.Range(-7.5f, -7.5f)
        arrowGo.transform.position = new Vector3(Random.Range(-7, 8), 6f, 0);
    }

    public void StopGenerate()
    {
        this.isGameOver = true;
    }
}
