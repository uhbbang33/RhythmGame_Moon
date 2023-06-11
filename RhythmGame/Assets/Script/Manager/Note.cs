using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400;
    TimingManager timingManger;

    private void Start()
    {
        timingManger = GetComponent<TimingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.down * noteSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note Collider"))
        {
            Destroy(gameObject);
        }
        if(collision.CompareTag("Timing Rect"))
        {
            timingManger.boxNoteList.Remove(gameObject);
        }
    }
}
