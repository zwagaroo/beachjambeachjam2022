using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallProjectile : MonoBehaviour
{
    public Vector3 target;
    public Vector3 rotation;
    public int moveSpeed;
    public float dmg = 5;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 direction = Vector3.RotateTowards(transform.up, target, 7f, -7f);
        //target.y = 0;
        //transform.rotation = Quaternion.LookRotation(direction);
        //float angle = Mathf.Rad2Deg*(Mathf.Asin(target.z/target.magnitude));
        //transform.Rotate(0, 0, angle - 90);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Vector3 heading = target;
        transform.position += heading * moveSpeed * Time.deltaTime;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit player");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.GetComponent<Health>());
            other.GetComponent<Health>().changeHealth(-dmg);
            Destroy(gameObject);
        }
    }
}
