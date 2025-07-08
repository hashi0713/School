using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] private float force = 0;
    private Plane plane;
    private PointCounter counter;
    private DashCamera dashcamera;
    public GameObject se;
    private void Start()
    {
        plane = GameObject.Find("PlanePos").GetComponent<Plane>();
        counter = GameObject.Find("Point").GetComponent<PointCounter>();
        dashcamera = GameObject.Find("PlaneCamera").GetComponent<DashCamera>();
    }
    private void Update()
    {
        if (transform.position.z + 30 <= plane.transform.position.z)
        {
            plane.lifePoint--;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Plane plane))
        {
            if (plane.dashPoint < 3) plane.dashPoint++;
            counter.point += (int)plane.rd.velocity.z / 10;
            plane.rd.AddForce(Vector3.forward * force, ForceMode.VelocityChange);
            if (!dashcamera.isDash) dashcamera.isDash = true;
            if (dashcamera.isDash) dashcamera.isDash2 = true;
            Instantiate(se, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
        
    }
}
