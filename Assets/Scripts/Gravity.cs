using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic; //ไว้ให้ใช้ List ได้

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.00674f; //ค่าที่ห้ามเปลี่ยน
    public static List<Gravity> gravityObjectList;

    //orbit โคจร
    [SerializeField] bool planets = false; //ตัวบอกว่าไม่ใช่ตัวจุดศูนย์กลาง
    [SerializeField] int orbitSpeed = 1000;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (gravityObjectList == null)
        {
            gravityObjectList = new List<Gravity>();
        }

        gravityObjectList.Add(this);

        //เริ่มโคจรก่อนถูกดูด
        if (!planets)
        {
            rb.AddForce(Vector3.left * orbitSpeed);
        }
    }

    private void FixedUpdate()
    {
        foreach (var obj in gravityObjectList) //ของในList แต่ละอันจะทำอะไรบางอย่างใน {}
        {
            if (obj != this) { Attract(obj); } //ดูดคนอื่น
            
        }
    }
    void Attract(Gravity other)
    { 
    Rigidbody otherRb = other.rb;
    Vector3 direction = rb.position - otherRb.position; //หาระยะทางของสองสิ่ง ได้ระยะกับทิศ
        float distance = direction.magnitude; //เอาแค่ระยะทางมาใช้
        float forceMagnitude = G * (rb.mass * otherRb.mass)/ Mathf.Pow(distance,2); //Matf สูตรคณิตในC# อันนี้มีเฉพาะแรง
        Vector3 finalForce = forceMagnitude * direction.normalized; //nor คือทิศ
        otherRb.AddForce(finalForce);


    }

}
