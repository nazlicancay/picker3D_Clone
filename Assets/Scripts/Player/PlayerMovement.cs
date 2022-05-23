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
    public bool Moveup;
    private bool Jump;


    [SerializeField] private Transform transformWihtoutlerp;
    public Transform playerTransform;
    public Rigidbody rb;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    
    private void FixedUpdate()
    {
        UpdatePlayerPos();

        if (Moveforward)
        {
            transform.position += Vector3.forward * speed * Time.fixedDeltaTime;
        }

        if (Moveup)
        {
            transform.position += new Vector3(0, 0.5f, 0.5f) * speed * Time.fixedDeltaTime;
            
        }

        if (Jump)
        {
            Moveup = false;
            Moveforward = false;
            playerTransform.DORotate(new Vector3(0, 0, 0), 0.5f);
            transform.DOJump(new Vector3(transform.position.x, 1f, transform.position.z + 15f), 10f, 1, 1f);
            Jump = false;
            Debug.Log("jumpp");
        }
    }


   
    public void JumpMove()
    {
        Jump = true;
    }
    public void MoveForward()
    {
        Moveforward = true;
    }

    public void MoveUp()
    {
        Moveup = true;
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
