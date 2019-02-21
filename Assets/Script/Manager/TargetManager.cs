using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {

    public static TargetManager targetManager;

    [SerializeField] Transform right, center, left;
    [SerializeField] Target[] targetPrefabs;
    [SerializeField] float delaySpawnTarget = 0.5f;

    public void Initialize()
    {
        targetManager = this;
        CreateTarget(right);
        CreateTarget(center);
        CreateTarget(left);
    }

    public void CreateTarget(Transform _spawn)
    {
        StartCoroutine(CreateTargetCoroutine(_spawn));
    }

    private IEnumerator CreateTargetCoroutine(Transform _spawn)
    {
        yield return new WaitForSeconds(delaySpawnTarget);
        Object.Instantiate<Target>(targetPrefabs.GetRandomElement(), _spawn);
    }
}
