using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.00674f; //ค่าที่ห้ามเปลี่ยน

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
