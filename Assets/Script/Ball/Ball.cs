using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody body;
    [SerializeField] AnimationCurve curve;
    private float power = 0;
    private bool isEnable = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
 //   void Update () {
 //       if (isEnable)
 //       {
 //           power = Mathf.Min(power + Time.deltaTime, curve.keys[curve.keys.Length - 1].time);
 //           body.velocity += new Vector3(0, curve.Evaluate(power), 0);
 //       }
	//}

    private void FixedUpdate()
    {
        if (isEnable)
        {
            power = Mathf.Min(power + Time.fixedDeltaTime, curve.keys[curve.keys.Length - 1].time);
            body.velocity += new Vector3(0, curve.Evaluate(power), 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    public void SetVelocity(Vector3 _velo)
    {
        body.velocity = _velo;
        isEnable = true;
    }
}
