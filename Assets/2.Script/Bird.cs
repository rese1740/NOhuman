using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public static Bird Instance;

    public float speed = 2.0f; // �̵� �ӵ�
    public float distance = 15f; // �̵� �Ÿ�
    private Vector3 startPosition;
    private Vector3 targetPosition;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + new Vector3(distance, 0, 0);
    }

    public void DestroyBird()
    {
        PlayerUI.Instance.birdnow = true;
        Destroy(gameObject);
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

       
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            
            targetPosition = targetPosition == startPosition ? startPosition + new Vector3(distance, 0, 0) : startPosition;

            if (targetPosition == startPosition + new Vector3(distance, 0, 0))
            {
                transform.localScale = new Vector3(1, 1, 1); 
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1); 
            }
        }
    }

    IEnumerator Sadadad()
    {
        yield return null;
    }
}

