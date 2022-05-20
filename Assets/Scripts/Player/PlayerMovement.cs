using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public float rotateMultiplier;
    public float swipeSpeed;
    public float maxLeftX;
    public float maxRightX;
    public float speed;
    private bool Swipe = false;
    private bool once = true;

    [SerializeField] private Transform transformWihtoutlerp;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        UpdatePlayerPos();
    }

    public void MoveForward()
    {
        transform.DOMoveZ(32,10f).SetUpdate(UpdateType.Fixed);
    }


    public void RotateCharacter(Vector2 position)
    {
        position = position.normalized;
        Quaternion rotation = Quaternion.AngleAxis(position.x * rotateMultiplier, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 2);
    }


    public void InputUpdate(Vector2 delta)
    {
        Swipe = true;
            Vector3 newPos = transformWihtoutlerp.localPosition + new Vector3(delta.x * swipeSpeed, 0, 0);
            newPos.x = Mathf.Clamp(newPos.x, maxRightX, maxLeftX);
            transformWihtoutlerp.localPosition = newPos;

    }

    private void UpdatePlayerPos()
    {
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, transformWihtoutlerp.localPosition, ref velocity, smoothTime);
    }
}
