using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] GameObject destructObject;
    [SerializeField] float health;

    public void Crush()
    {
        Instantiate(destructObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody == null)
            return;

        float accel = collision.relativeVelocity.magnitude;
        float mass = collision.rigidbody.mass;
        if (accel < 1)
            return;

        Debug.Log($"{collision.collider.name} : {collision.rigidbody.velocity.magnitude}");

        //���� �浹�� ��ü�� rigidbody�� ������ ���� * �ӷ�(F=MA)���� ���� ���Ѵ�
        float force = accel * mass;
        health = Mathf.Clamp(health - force, 0.0f, float.MaxValue);

        if(health <= 0.0f )
            Crush();
    }
}
