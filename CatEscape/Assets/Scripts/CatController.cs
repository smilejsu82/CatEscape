using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public float radius = 1;

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
            this.MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //������ ȭ��ǥ�� �����ٸ� x������ 3���ָ�ŭ �̵� 
            this.MoveRight();
        }

    }

    public void MoveLeft()
    {
        this.transform.Translate(-3, 0, 0);
    }

    public void MoveRight()
    {   
        this.transform.Translate(3, 0, 0);
    }

    //�̺�Ʈ �Լ� 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }
}
