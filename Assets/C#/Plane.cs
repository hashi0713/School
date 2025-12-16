using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using Unity.VisualScripting;

public class Plane : Agent
{
    public Rigidbody rd;
    public DashCamera dashcamera;
    public PlaneRen ren;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotSpeed_x = 1f;
    [SerializeField] private float rotSpeed_y = 2f;
    [SerializeField] private float dashForce = 10f;

    private bool startDash = true;
    public bool tern = false;
    private float x, y;

    public int dashPoint;
    public int lifePoint;

    private int prevDash = 0;           
    private bool dashRequested = false; 
    [SerializeField] private float dashCooldown = 0.15f;
    private float nextDashTime = 0f;

    float lifeT;

    public bool ringReset = false;

    public enum RewardMode
    {
        A, B, C, D
    }

    [SerializeField] private RewardMode rm;

    private void Awake() => rd = GetComponent<Rigidbody>();

    public override void OnEpisodeBegin()
    {
        transform.position = new Vector3(0, 100, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rd.velocity = Vector3.zero;
        rd.angularVelocity = Vector3.zero;

        ren.enabled = false;
        ren.ResetLastVec(transform.position);
        ren.enabled = true;

        dashPoint = 3;
        lifePoint = 3;
        PointManeger.Instance.ResetScore();

        startDash = true;
        lifeT = 0;

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(transform.rotation.eulerAngles / 360f);
        sensor.AddObservation(rd.velocity / 20f);
        sensor.AddObservation(dashPoint);
        sensor.AddObservation(lifePoint);

        Transform ring = GetNearestRing();
        Vector3 diff = Vector3.zero;
        if (ring != null)
        {
            diff = transform.InverseTransformPoint(ring.position);
            diff /= 500f;
        }

        sensor.AddObservation(diff);
    }

    public void FixedUpdate()
    {
        StartDash();
        Move();
        Dash();

        lifeT += Time.fixedDeltaTime;
    }

    void StartDash()
    {
        if (startDash)
        {
            rd.AddForce(transform.forward * dashForce, ForceMode.VelocityChange);
            startDash = false;
        }
    }

    void Dash()
    {
        if (dashRequested && Time.time >= nextDashTime && dashPoint > 0)
        {
            if (!dashcamera.isDash) dashcamera.isDash = true;
            if (dashcamera.isDash) dashcamera.isDash2 = true;
            tern = true;

            rd.AddForce(transform.forward * dashForce, ForceMode.VelocityChange);
            dashPoint--;

            dashRequested = false;
            nextDashTime = Time.time + dashCooldown;
        }
    }

    void Move()
    {


        float _x = 0, _y = 0;

        if (y < 0 && (transform.rotation.eulerAngles.x <= 95 || transform.rotation.eulerAngles.x >= 290)) _y = -y;
        if (y > 0 && (transform.rotation.eulerAngles.x <= 80 || transform.rotation.eulerAngles.x >= 265)) _y = -y;
        if (x > 0 && (transform.rotation.eulerAngles.y <= 60 || transform.rotation.eulerAngles.y >= 260)) _x = x;
        if (x < 0 && (transform.rotation.eulerAngles.y <= 100 || transform.rotation.eulerAngles.y >= 300)) _x = x;

        Vector3 p = transform.rotation.eulerAngles;
        if (p.x < 270 && p.x > 180) transform.rotation = Quaternion.Euler(80, p.y, p.z);
        if (p.y > 85 && p.y <= 180) transform.rotation = Quaternion.Euler(p.x, 85, p.z);
        if (p.y < 305 && p.y >= 180) transform.rotation = Quaternion.Euler(p.x, 305, p.z);
        Quaternion rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x - rotSpeed_y * _y,
            transform.rotation.eulerAngles.y + rotSpeed_x * _x,
            0f
        );

        Vector3 forward = rotation * Vector3.forward;

        float speed = rd.velocity.magnitude;
        Vector3 newVelocity = forward * speed;

        rd.velocity = newVelocity;

    }

    [SerializeField] float alignRewardScale = 0.005f; 
    [SerializeField] float maxAlignDist = 500f;       
    [SerializeField] float minSpeedForAlign = 2f;

    void RewardFacingNearestRing()
    {
        var target = GetNearestRing();
        if (target == null) return;

        Vector3 toRing = (target.position - transform.position);
        float dist = toRing.magnitude;
        if (dist < 0.001f) return;

        float alignment = Vector3.Dot(transform.forward, toRing.normalized);

        float dist01 = Mathf.InverseLerp(0f, maxAlignDist, dist);
        float distWeight = 1f - dist01;  // 近いほど1

        if (rd.velocity.magnitude >= minSpeedForAlign)
        {
            float shaped = alignment * distWeight;
            AddReward(shaped * alignRewardScale);
        }
    }

    Transform GetNearestRing()
    {
        GameObject[] rings = GameObject.FindGameObjectsWithTag("Ring");
        Transform best = null;
        float bestDist = float.PositiveInfinity;
        Vector3 p = transform.position;

        foreach (var r in rings)
        {
            float d = (r.transform.position - p).sqrMagnitude;
            if (d < bestDist && p.z < r.transform.position.z)
            {
                bestDist = d;
                best = r.transform;
            }
        }
        return best;
    }

    void DashReward()
    {
        var target = GetNearestRing();
        if (target == null) return;

        Vector3 toRing = (target.position - transform.position);
        float dist = toRing.magnitude;
        if (dist < 0.001f) return;

        float alignment = Vector3.Dot(transform.forward, toRing.normalized);

        if (rd.velocity.magnitude >= minSpeedForAlign)
        {
            if (alignment > 0.9397f && dashRequested && Time.time >= nextDashTime && dashPoint > 0)
            {
                AddReward(0.3f);
            }
        }
    }

    [SerializeField] float stepBonus = 0.0005f;
    void FWBonus()
    {
        if(rd.velocity.z>30)AddReward(stepBonus);
    }

    [SerializeField] float minusBonus = -0.0005f;
    void Danger()
    {
        if (transform.position.y <= 25) AddReward(minusBonus);
    }


    public override void OnActionReceived(ActionBuffers actions)
    {
        int actionX = actions.DiscreteActions[0]; // 0: left, 1: stay, 2: right
        int actionY = actions.DiscreteActions[1]; // 0: down, 1: stay, 2: up
        int dash = actions.DiscreteActions[2];    // 0: no dash, 1: dash

        //Debug.Log(actionX + "," + actionY+ "," + dash);

        x = 0f;
        y = 0f;
        
        x = actionX == 0 ? -1 : (actionX == 2 ? 1 : 0);
        y = actionY == 0 ? -1 : (actionY == 2 ? 1 : 0);

        if (dash == 1 && prevDash == 0)
        {
            dashRequested = true;
        }
        prevDash = dash;

        //リワードモード
        switch (rm)
        {
            case RewardMode.A:
                
                break;

            case RewardMode.B:
                FWBonus();
                RewardFacingNearestRing();
                Danger();
                DashReward();
                break;
        }

        if (lifePoint <= 0 || transform.position.y < 0)
        {
            ringReset = true;
            Debug.Log($"[{StepCount}] Reward so far: {GetCumulativeReward():F4}");
            Academy.Instance.StatsRecorder.Add("GameScore", PointManeger.Instance.Score);
            EndEpisode();
        }
    }

    //マスク
    public override void WriteDiscreteActionMask(IDiscreteActionMask actionMask)
    {

        //if (1.0f<lifeT&&lifeT<7.0f)
        //{
        //    actionMask.SetActionEnabled(1, 2, false);  
        //}

        //if (Physics.Raycast(transform.position, Vector3.down, 20f))
        //{
        //    actionMask.SetActionEnabled(1, 2, false);
        //}

        
    }


    //キーボード操作
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActions = actionsOut.DiscreteActions;

        discreteActions[0] = Input.GetAxisRaw("Horizontal") < 0 ? 0 :
                             Input.GetAxisRaw("Horizontal") > 0 ? 2 : 1;
        discreteActions[1] = Input.GetAxisRaw("Vertical") < 0 ? 0 :
                             Input.GetAxisRaw("Vertical") > 0 ? 2 : 1;
        discreteActions[2] = Input.GetKey(KeyCode.Space) ? 1 : 0;
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ring"))
        {
            AddReward(1.0f);
            dashPoint++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Limit"))
        {
            AddReward(-0.5f);
        }
        else
        {
            ringReset = true;
            AddReward(-1f);
            Debug.Log($"[{StepCount}] Reward so far: {GetCumulativeReward():F4}");
            Academy.Instance.StatsRecorder.Add("GameScore", PointManeger.Instance.Score);
            EndEpisode();
        }
    }
}
