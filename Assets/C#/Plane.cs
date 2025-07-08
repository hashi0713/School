using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Plane : Agent
{
    public Rigidbody rd;
    public DashCamera dashcamera;
    public PlaneRen ren;

    [SerializeField] private float speed = 30f;
    [SerializeField] private float rotSpeed_x = 1f;
    [SerializeField] private float rotSpeed_y = 2f;
    [SerializeField] private float dashForce = 30f;

    private float roty;
    private float rotx;
    private float addZ, addZ_z, addZ_x, addY;
    private float kari;
    private bool isFirst = true;
    private bool limit_y = false;
    public bool tern = false;

    public int dashPoint;
    public int lifePoint;

    public override void Initialize()
    {
        rd = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        // リセット処理
        transform.position = new Vector3(0, 100, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rd.velocity = Vector3.zero;
        rd.angularVelocity = Vector3.zero;

        dashPoint = 3;
        lifePoint = 3;
        isFirst = true;
        limit_y = false;

        ren.enabled = true;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(transform.rotation.eulerAngles / 360f);
        sensor.AddObservation(rd.velocity / 20f);
        sensor.AddObservation(dashPoint);
        sensor.AddObservation(lifePoint);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int actionX = actions.DiscreteActions[0]; // 0: left, 1: stay, 2: right
        int actionY = actions.DiscreteActions[1]; // 0: down, 1: stay, 2: up
        int dash = actions.DiscreteActions[2];    // 0: no dash, 1: dash

        float x = 0f;
        float y = 0f;

        if (actionX == 0) x = -1f;
        else if (actionX == 2) x = 1f;

        if (actionY == 0) y = -1f;
        else if (actionY == 2) y = 1f;

        // Dash
        if (dash == 1 && dashPoint > 0)
        {
            if (!dashcamera.isDash) dashcamera.isDash = true;
            if (dashcamera.isDash) dashcamera.isDash2 = true;
            tern = true;

            rd.AddForce(transform.forward * dashForce, ForceMode.VelocityChange);
            dashPoint--;
        }

        // 高さ制限制御（もとのMove処理の再現）
        if (transform.position.y >= 240 && isFirst) { limit_y = true; isFirst = false; }
        if (transform.position.y >= 240) { if (limit_y) { kari = -10; limit_y = false; } kari *= 0.98f; y = kari; }
        if (transform.position.y < 240) { isFirst = true; }

        roty = transform.rotation.eulerAngles.x - rotSpeed_y * y;
        rotx = transform.rotation.eulerAngles.y + rotSpeed_x * x;

        addZ = rd.velocity.magnitude * Mathf.Cos(roty * Mathf.Deg2Rad);
        addZ_z = addZ * Mathf.Cos(rotx * Mathf.Deg2Rad);
        addZ_x = addZ * Mathf.Sin(rotx * Mathf.Deg2Rad);
        addY = rd.velocity.magnitude * Mathf.Sin(roty * Mathf.Deg2Rad);

        rd.velocity = new Vector3(addZ_x, -addY, addZ_z);

        // 毎ステップ少し報酬
        AddReward(0.01f);
        if(lifePoint<=0) EndEpisode();
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActions = actionsOut.DiscreteActions;

        discreteActions[0] = Input.GetAxisRaw("Horizontal") < 0 ? 0 :
                             Input.GetAxisRaw("Horizontal") > 0 ? 2 : 1;
        discreteActions[1] = Input.GetAxisRaw("Vertical") < 0 ? 0 :
                             Input.GetAxisRaw("Vertical") > 0 ? 2 : 1;
        discreteActions[2] = Input.GetKeyDown(KeyCode.Space) ? 1 : 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ring"))
        {
            AddReward(rd.velocity.z/10);  // リング通過で報酬
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //AddReward(-1.0f); // 衝突でペナルティF
        EndEpisode();     // エピソード終了
    }
}
