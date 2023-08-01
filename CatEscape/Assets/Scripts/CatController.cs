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
        //Ű �Է� �ޱ� 
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //���� ȭ��ǥ�� �����ٸ� x������ -3���ָ�ŭ �̵� 
            this.transform.Translate(-3, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //������ ȭ��ǥ�� �����ٸ� x������ 3���ָ�ŭ �̵� 
            this.transform.Translate(3, 0, 0);
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
