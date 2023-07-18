using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDeleteColliderManager : MonoBehaviour
{
    TimingManager timingManger;
    [SerializeField] EffectManager effectManager;

    private void Start()
    {
        timingManger = FindObjectOfType<TimingManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (collision.GetComponent<Note>().GetNoteFlag())
                effectManager.JudgementEffect(4);
            timingManger.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
