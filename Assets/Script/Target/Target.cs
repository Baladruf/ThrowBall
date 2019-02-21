using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    [SerializeField] float points;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ball")
        {
            GameManager.Instance.Score = points;
            TargetManager.targetManager.CreateTarget(transform.parent);
            Destroy(gameObject);
        }
    }
}
