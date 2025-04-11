using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type { Melee, Range};
    public Type type;
    public int damage;
    public float rate;
    public int maxAmmo;
    public int curAmmo;

    public BoxCollider meleeArea;
    public TrailRenderer trailEffect;
    public Transform bulletPos;
    public GameObject bullet;
    public Transform bulletCasePos;
    public GameObject bulletCase;

    public void Use()
    {
        if(type == Type.Melee)
        {
            StopCoroutine("Swing");
            StartCoroutine("Swing");
        }
        else if (type == Type.Range && curAmmo > 0)
        {
            curAmmo--;
            StartCoroutine("Shot");
        }
    }

   
    IEnumerator Swing()
    {
        //1
        yield return new WaitForSeconds(0.1f); //0.1�� ���
        meleeArea.enabled = true;
        trailEffect.enabled = true;
        //2
        yield return new WaitForSeconds(0.2f); //0.2�� ���
        meleeArea.enabled = false;
        //3
        yield return new WaitForSeconds(0.3f); //0.3�� ���
        trailEffect.enabled = false;
    }

    // Use() ���η�Ʈ -> Swing() �����ƾ -> Use() ���η�Ʈ
    // Use() ���η�Ʈ + Swing() �ڷ�ƾ(co-Op)


    IEnumerator Shot()
    {
        //#1.�Ѿ� �߻� 
        GameObject instantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody bulletRigid = instantBullet.GetComponent<Rigidbody>();
        bulletRigid.linearVelocity = bulletPos.forward * 50;

        yield return null;
        //#2.ź�� ���� 
        GameObject instantCase = Instantiate(bulletCase, bulletCasePos.position, bulletCasePos.rotation);
        Rigidbody caseRigid = instantCase.GetComponent<Rigidbody>();
        Vector3 caseVec = bulletCasePos.forward * Random.Range(-3, -2) + Vector3.up * Random.Range(2, 3);
        caseRigid.AddForce(caseVec, ForceMode.Impulse);
    }
}
