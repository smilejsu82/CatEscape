using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]    //SerializeField ��Ʈ����Ʈ�� ����ϸ� private �ɹ��� �ν����Ϳ� ���� 
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
        //�� �������� �Ÿ� 
        //Vector3 p1 = this.transform.position;//ȭ���� ���� 
        //Vector3 p2 = this.catGo.transform.position; //������� ���� 
        //Vector3 dir = p1 - p2;  //�������� (ũ��� ����)
        //float distance = dir.magnitude;
        //Debug.Log(distance);
        var dis = Vector3.Distance(this.transform.position, this.catGo.transform.position);
        Debug.LogFormat("�� �������� �Ÿ� : {0}", dis);

        //�������� �� 
        CatController catController = this.catGo.GetComponent<CatController>();
        var sumRadius = this.radius + catController.radius;
        Debug.LogFormat("�� ���� �������� �� : {0}", sumRadius);

        //�� �������� �Ÿ��� �� ���� �������� �պ��� ũ�� false (�ε����� �ʾҴ�)

        //�� ���� �������� �� �� �� �������� �Ÿ����� ũ�ٸ� �ε����� 
        return dis < sumRadius;

    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime : ���� �����Ӱ� ���� ������ ������ ���� �ð� 
        //Debug.Log(Time.deltaTime);

        //������ ��� �̵� 
        //this.gameObject.transform.Translate(0, -1, 0);

        //�ð���� �̵� 
        //�ӵ� * ���� * �ð� 
        //1f * new Vector3(0, -1, 0) * Time.deltaTime 
        //this.gameObject.transform.Translate(this.speed * Vector3.down * Time.deltaTime);
        this.transform.Translate(this.speed * Vector3.down * Time.deltaTime);

        if (this.transform.position.y <= -3.9f)
        {
            Destroy(this.gameObject);
        }

        if (this.IsCollide())
        {
            Debug.LogFormat("�浹�ߴ�!");

            //--------------------------------------------------------------------------
            //�浹�� HP�� ���� �Ѵ� 
            GameObject gameDirectorGo = GameObject.Find("GameDirector");
            GameDirector gameDirector =  gameDirectorGo.GetComponent<GameDirector>();
            gameDirector.DecreaseHp();
            //--------------------------------------------------------------------------

            Destroy(this.gameObject);   //ArrowController������Ʈ�� �پ��ִ� ���ӿ�����Ʈ�� ������ �����Ѵ� 
        }
        else 
        {
            Debug.LogFormat("�浹���� �ʾҴ�!");
        }
    }

    public float radius = 1;
    //�̺�Ʈ �Լ� 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }
}
 