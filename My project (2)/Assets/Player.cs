using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0.01f, 1f)] float moveDuration = 0.2f;
    [SerializeField, Range(0.01f, 1f)] float jumpHeight = 0.2f;
    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.UpArrow))
        //     Debug.Log("forward");

        // if (Input.GetKeyDown(KeyCode.DownArrow))
        //     Debug.Log("back");

        var moveDir = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.UpArrow))
            moveDir += new Vector3(0, 0, 1);

        if (Input.GetKeyDown(KeyCode.DownArrow))
            moveDir += new Vector3(0, 0, -1);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            moveDir += new Vector3(1, 0, 0);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            moveDir += new Vector3(-1, 0, 0);


        if (moveDir == Vector3.zero)
            return;

        if (isJumping() == false)
            Jump(moveDir);
    }

    private void Jump(Vector3 targetDirection)
    {
        var TargetPosition = transform.position + targetDirection;
        // x: dir.x,
        // y: 0,
        // z: dir.y);
        transform.LookAt(TargetPosition);

        var moveSeq = DOTween.Sequence(transform);
        moveSeq.Append(transform.DOMoveY(jumpHeight, moveDuration / 2));
        moveSeq.Append(transform.DOMoveY(0, moveDuration / 2));

        //transform.DOMoveY(2f, 0.1f)(TargetPosition, 0.5f, 0.1f.onComplete(() => transform.DOMoveY(0, 0.1f);

        transform.DOMoveX(TargetPosition.x, moveDuration);
        transform.DOMoveZ(TargetPosition.z, moveDuration);
    }

    private bool isJumping()
    {
        return DOTween.IsTweening(transform);
    }
}

