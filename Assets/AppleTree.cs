using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in inspector")]
    public GameObject applePrefab;
    public float speed = 10f;
    public float leftAndRightEdge = 25f;
    public float chanceToChangeDirections = 0.02f;
    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //сбрасывать яблоки раз в секунду
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        //перемещение
        Vector3 pos = transform.position;
        if (pos.x < -leftAndRightEdge) { speed = Mathf.Abs(speed); }
        else if (pos.x > leftAndRightEdge) { speed = -Mathf.Abs(speed); }
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
    private void FixedUpdate()
    {
        //изменение направления
        if (Random.value < chanceToChangeDirections) { speed *= -1; } //[0..1]
    }
}
