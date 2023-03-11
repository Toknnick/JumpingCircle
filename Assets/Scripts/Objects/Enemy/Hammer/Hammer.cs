using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] private Transform firstPosition;
    [SerializeField] private Transform secondPosition;
    [SerializeField] private float downTime = 0.3f;
    [SerializeField] private float upTime = 3;

    public bool IsMovingDown = true;

    private void Start()
    {
        StartCoroutine(HammerMovement());
    }

    private IEnumerator HammerMovement()
    {
        float timer;
        Vector3 startPos;
        Vector3 targetPos;
        float moveTime;

        while (true)
        {
            timer = 0f;

            if (IsMovingDown)
            {
                startPos = firstPosition.position;
                targetPos = secondPosition.position;
                moveTime = downTime;
            }
            else
            {
                startPos = secondPosition.position;
                targetPos = firstPosition.position;
                moveTime = upTime;
                yield return new WaitForSeconds(1);
            }

            while (timer < moveTime)
            {
                timer += Time.deltaTime;
                float t = Mathf.Clamp01(timer / moveTime);
                transform.position = Vector3.Lerp(startPos, targetPos, t);
                yield return null;
            }

            IsMovingDown = !IsMovingDown;
        }
    }
}
