using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.00674f; //��ҷ����������¹

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
