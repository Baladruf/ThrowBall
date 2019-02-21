using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCircleMove : Target {

    [SerializeField] float speed = 5;
    [SerializeField] float sizeCircle = 2;
    private int sense;

    private void Awake()
    {
        sense = Random.Range(0, 100) < 50 ? -1 : 1;
    }

    void Update () {
        float cos = sizeCircle * Mathf.Cos(speed * Time.time * sense);
        float sin = sizeCircle * Mathf.Sin(speed * Time.time * sense);

        transform.localPosition = new Vector3(cos, sin, 0);
	}
}
