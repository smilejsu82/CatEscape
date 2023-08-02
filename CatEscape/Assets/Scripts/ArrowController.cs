using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]    //SerializeField 애트리뷰트를 사용하면 private 맴버도 인스펙터에 노출 
    private float speed;

    private GameObject catGo;

    // Start is called before the first frame update
    void Start()
    {
        this.catGo = GameObject.Find("cat");
        Debug.Log("catGo: {0}", this.catGo);

    }

    private bool IsCollide()
    {
        //두 원사이의 거리 
        //Vector3 p1 = this.transform.position;//화살의 중점 
        //Vector3 p2 = this.catGo.transform.position; //고양이의 중점 
        //Vector3 dir = p1 - p2;  //물리벡터 (크기와 방향)
        //float distance = dir.magnitude;
        //Debug.Log(distance);
        var dis = Vector3.Distance(this.transform.position, this.catGo.transform.position);
        Debug.LogFormat("두 원사이의 거리 : {0}", dis);

        //반지름의 합 
        CatController catController = this.catGo.GetComponent<CatController>();
        var sumRadius = this.radius + catController.radius;
        Debug.LogFormat("두 원의 반지름의 합 : {0}", sumRadius);

        //두 원사이의 거리가 두 원의 반지름의 합보다 크면 false (부딪히지 않았다)

        //두 원의 반지름의 합 이 두 원사이의 거리보다 크다면 부딪혔다 
        return dis < sumRadius;

    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime : 이전 프레임과 현제 프레임 사이의 간격 시간 
        //Debug.Log(Time.deltaTime);

        //프레임 기반 이동 
        //this.gameObject.transform.Translate(0, -1, 0);

        //시간기반 이동 
        //속도 * 방향 * 시간 
        //1f * new Vector3(0, -1, 0) * Time.deltaTime 
        //this.gameObject.transform.Translate(this.speed * Vector3.down * Time.deltaTime);
        this.transform.Translate(this.speed * Vector3.down * Time.deltaTime);

        if (this.transform.position.y <= -3.9f)
        {
            Destroy(this.gameObject);
        }

        if (this.IsCollide())
        {
            Debug.LogFormat("충돌했다!");

            //--------------------------------------------------------------------------
            //충돌시 HP를 감소 한다 
            GameObject gameDirectorGo = GameObject.Find("GameDirector");
            GameDirector gameDirector =  gameDirectorGo.GetComponent<GameDirector>();
            gameDirector.DecreaseHp();
            //--------------------------------------------------------------------------

            Destroy(this.gameObject);   //ArrowController컴포넌트가 붙어있는 게임오브젝트를 씬에서 제거한다 
        }
        else 
        {
            Debug.LogFormat("충돌하지 않았다!");
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
 