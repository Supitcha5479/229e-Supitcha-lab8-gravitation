using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic; //�������� List ��

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.00674f; //��ҷ����������¹
    public static List<Gravity> gravityObjectList;

    //orbit ⤨�
    [SerializeField] bool planets = false; //��Ǻ͡���������Ǩش�ٹ���ҧ
    [SerializeField] int orbitSpeed = 1000;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (gravityObjectList == null)
        {
            gravityObjectList = new List<Gravity>();
        }

        gravityObjectList.Add(this);

        //�����⤨á�͹�١�ٴ
        if (!planets)
        {
            rb.AddForce(Vector3.left * orbitSpeed);
        }
    }

    private void FixedUpdate()
    {
        foreach (var obj in gravityObjectList) //�ͧ�List �����ѹ�з����úҧ���ҧ� {}
        {
            if (obj != this) { Attract(obj); } //�ٴ�����
            
        }
    }
    void Attract(Gravity other)
    { 
    Rigidbody otherRb = other.rb;
    Vector3 direction = rb.position - otherRb.position; //�����зҧ�ͧ�ͧ��� �����СѺ���
        float distance = direction.magnitude; //��������зҧ����
        float forceMagnitude = G * (rb.mass * otherRb.mass)/ Mathf.Pow(distance,2); //Matf �ٵä�Ե�C# �ѹ�����੾���ç
        Vector3 finalForce = forceMagnitude * direction.normalized; //nor ��ͷ��
        otherRb.AddForce(finalForce);


    }

}
