using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowBall : MonoBehaviour {

    [SerializeField] Image loadPower;
    [SerializeField] Ball[] ball;

    [SerializeField] float powerMin = 100;
    [SerializeField] float powerMax = 250;

    [SerializeField] float delayLoad = 8;

    private float timer;
    private float lerpTimer { get { return timer / delayLoad; } }
    private Ball currentBall = null;
    [SerializeField] float delaySpawnBall = 0.1f;

	// Use this for initialization
	void Awake () {
        currentBall = Object.Instantiate<Ball>(ball[0], transform);
    }
	
	// Update is called once per frame
	void Update () {
        if(currentBall == null)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            timer = Mathf.Min(timer + Time.deltaTime, delayLoad);
            loadPower.fillAmount = lerpTimer;
        }

        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, 500);

            currentBall.SetVelocity((hit.point - transform.position).normalized * Mathf.Lerp(powerMin, powerMax, lerpTimer));
            currentBall = null;
            StartCoroutine(SpawnBall());

            timer = 0;
            loadPower.fillAmount = 0;
        }
	}

    private IEnumerator SpawnBall()
    {
        yield return new WaitForSeconds(delaySpawnBall);
        currentBall = Object.Instantiate<Ball>(ball.GetRandomElement(), transform);
    }
}
