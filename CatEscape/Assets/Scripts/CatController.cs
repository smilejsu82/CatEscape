using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //키 입력 받기 
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //왼쪽 화살표를 눌렀다면 x축으로 -3유닛만큼 이동 
            this.transform.Translate(-3, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //오른쪽 화살표를 눌렀다면 x축으로 3유닛만큼 이동 
            this.transform.Translate(3, 0, 0);
        }
            
    }

    public float radius = 1;
    //이벤트 함수 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }
}
