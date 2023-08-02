using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;  //프리팹 원본 파일 
    private float elapsedTime; //경과 시간 
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

        //매프레임마다 Time.deltaTime을 경과시간에 더해준다 
        this.elapsedTime += Time.deltaTime;

        //경과시간이 1초를 지나갔다면 
        if (this.elapsedTime > 1f) {
            //화살을 만든다 
            this.CreateArrow();
            //경과시간 초기화 
            this.elapsedTime = 0;   //0초부터 1초까지를 셀수 있도록 
        }
    }

    private void CreateArrow()
    {
        //arrowGo : 프리팹 복제본 (인스턴스)
        GameObject arrowGo = Instantiate(this.arrowPrefab);
        //Random.Range(-7.5f, -7.5f)
        arrowGo.transform.position = new Vector3(Random.Range(-7, 8), 6f, 0);
    }

    public void StopGenerate()
    {
        this.isGameOver = true;
    }
}
