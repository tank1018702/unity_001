using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beefcake : MonoBehaviour
{
    public GameObject body;
    public GameObject hammer;


    Rigidbody body_rig;
    Rigidbody hammer_rig;
    Transform hammer_anchor;

    public float MaxDistance;
    float RelativeDistance;

    void Start()
    {
        body_rig = body.GetComponent<Rigidbody>();
        hammer_rig = hammer.GetComponent<Rigidbody>();
        hammer_anchor = hammer.transform.GetChild(2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        HammerControl();
    }

     void HammerControl()
    {
        //获取鼠标在屏幕上的坐标并转换为世界坐标,若相对距离大于最大距离则获得转换后的坐标
        Vector2 MousePosition = GetConfinedPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        //通过修改锤子身上刚体的速度让锤子移动,向量的起点用锤头的坐标
        //注意这里要让锤头的锚点与锤子本身的坐标的Z值相等,为了让旋转轴与世界坐标的Z轴平行,同理鼠标坐标的Z值也直接使用锤子的坐标的Z值
        hammer_rig.velocity = (new Vector3(MousePosition.x, MousePosition.y, hammer.transform.position.z) - hammer_anchor.position) * 10;


        if (hammer.GetComponent<CollisionDetection>().IsCollision)
        {
            //BodyControl(hammer.GetComponent<CollisionDetection>().velocity);
            BodyControl(hammer_rig.velocity);
        }

        //获取身体到鼠标的方向
        Vector3 direction = (new Vector3(MousePosition.x, MousePosition.y, hammer_anchor.position.z) - new Vector3(body.transform.position.x, body.transform.position.y, hammer_anchor.position.z)).normalized;

        //让锤子沿着锤头锚点转向身体的方向
        hammer.transform.RotateAround(hammer_anchor.position, Vector3.Cross(hammer_anchor.up, direction), Vector3.Angle(hammer_anchor.up, direction));
    }
    //单独抽出一个函数获取最大距离以外的转换后的鼠标坐标
     Vector2 GetConfinedPosition(Vector2 mouseposition)
    {

        Vector2 Confined_MousePosition;

        //去掉body坐标的Z值,避免计算距离时的影响
        Vector2 body_position = new Vector2(body.transform.position.x, body.transform.position.y);

        //计算当前鼠标位置和身体位置的相对距离
        RelativeDistance = Vector2.Distance(mouseposition, body_position);

        if (RelativeDistance > MaxDistance)
        {
            //当相对距离大于自己设置的最大距离时,获取转换以后的目标坐标
            //这里的思路需要稍稍转一个弯,一开始是获取的是长度为最大距离,方向为身体到鼠标方向的向量。
            //在这个基础上加上身体的当前坐标,其等于是将这个向量的起始点设置为身体的坐标。
            //最后向量与坐标点可以直接相互转换,此时转换后的目标坐标就等于这个向量。
            Confined_MousePosition = (mouseposition - body_position).normalized * MaxDistance + body_position;
        }
        else
        {
            //若相对距离小于最大距离那么鼠标当前坐标就是目标坐标
            Confined_MousePosition = mouseposition;
        }
        return Confined_MousePosition;
    }

     void BodyControl(Vector3 velociy)
    {
        body_rig.velocity = -velociy * 0.5f;
        //body_rig.AddForce(velociy * 2,ForceMode.Impulse);
    }
}
