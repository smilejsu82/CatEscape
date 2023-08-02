using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public float radius = 1;

    private int maxHp = 10;
    private int hp;

    // Start is called before the first frame update
    void Start()
    {
        this.hp = this.maxHp;

        Debug.LogFormat("����� ü�� : <color=yellow>{0}/{1}</color>", this.hp, this.maxHp);
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
        if (this.hp <= 0) return;

        this.transform.Translate(-3, 0, 0);
        this.Clamp();
    }

    public void MoveRight()
    {
        if (this.hp <= 0) return;

        this.transform.Translate(3, 0, 0);
        this.Clamp();
    }

    public bool IsDie() {
        return this.hp <= 0;
    }

    public int GetHp() {
        return this.hp;
    }
    public int GetMaxHp()
    {
        return this.maxHp;
    }

    private void Clamp()
    {
        var x = Mathf.Clamp(this.transform.position.x, -7.84f, 7.84f);
        var pos = this.transform.position;
        pos.x = x;
        this.transform.position = pos;
    }

    public void DecreaseHp(int damage)
    {
        this.hp -= damage;
        if (this.hp <= 0) {
            Debug.Log("Cat Die");
            this.hp = 0;

            GameObject gameDirectorGo = GameObject.Find("GameDirector");
            GameDirector gameDirector =  gameDirectorGo.GetComponent<GameDirector>();
            gameDirector.GameOver();
        }
    }

    //�̺�Ʈ �Լ� 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }
}
