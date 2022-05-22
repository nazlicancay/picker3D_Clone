using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : Singleton<PlayerMovement>
{
    public float rotateMultiplier;
    public float swipeSpeed;
    public float maxLeftX;
    public float maxRightX;
    public float speed;
    private bool Swipe = false;
    private bool once = true;
    public float clampval;
    public bool Moveforward;

    [SerializeField] private Transform transformWihtoutlerp;
    [SerializeField] private Transform playerTransform;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        UpdatePlayerPos();

        if (Moveforward)
        {
            transform.position += Vector3.forward * speed * Time.fixedDeltaTime;
        }
    }

    public void MoveForward()
    {
        Moveforward = true;
    }


    public void RotateCharacter(Vector2 position)
    {
        position = position.normalized;
        Quaternion rotation = Quaternion.AngleAxis(position.x * rotateMultiplier, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.fixedDeltaTime * 2);
    }


    public void InputUpdate(Vector2 delta)


    {
        float newDelta = Mathf.Clamp(delta.x, -clampval, clampval);
        Swipe = true;
            Vector3 newPos = transformWihtoutlerp.localPosition + new Vector3(newDelta * swipeSpeed, 0, 0);
            newPos.x = Mathf.Clamp(newPos.x, maxRightX, maxLeftX);
            transformWihtoutlerp.localPosition = newPos;

    }

    private void UpdatePlayerPos()
    {
        playerTransform.localPosition = Vector3.SmoothDamp(transform.localPosition, transformWihtoutlerp.localPosition, ref velocity, smoothTime);
    }

    public void SpeedUp()
    {
        DOTween.To(() => speed, x => speed = x, 4f, 0.5f);

    }

    public void speedDown()
    {
        DOTween.To(() => speed, x => speed = x, 0f, 1f);
    }
}
