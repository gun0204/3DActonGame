using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type { Ammo, Coin, Grende, Heart, Weapon };
    public Type type;
    public int value;

    Rigidbody rigid;
    SphereCollider sphereCollider;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * 10 * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            rigid.isKinematic = true;
            sphereCollider.enabled = false;
        }
    }
}
