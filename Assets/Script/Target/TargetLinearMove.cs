using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetLinearMove : Target {

    private enum Direction
    {
        HORIZONTAL,
        VERTICAL,
        DIAGONAL_UP,
        DIAGANAL_DOWN
    }
    private Vector3 direction;

    [SerializeField] Direction pattern;
    [SerializeField] float speed = 1;
    [SerializeField] float distance = 10;

    private void Awake()
    {
        switch (pattern)
        {
            case Direction.HORIZONTAL:
                direction = Vector2.right;
                break;
            case Direction.VERTICAL:
                direction = Vector2.up;
                break;
            case Direction.DIAGONAL_UP:
                direction = Vector2.one;
                break;
            case Direction.DIAGANAL_DOWN:
                direction = new Vector2(1, -1);
                break;
        }
        direction *= distance;
        Move(speed * 0.5f);
    }

    private void Move(float _speed)
    {
        transform.DOLocalMove(direction, _speed).SetEase(Ease.Linear).OnComplete(() =>
        {
            direction *= -1;
            Move(speed);
        });
    }
}
