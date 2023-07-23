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
                effectManager.JudgementEffect(4);   // 매직넘버 추후 수정

            int noteLineNum = collision.gameObject.GetComponent<Note>().noteLineNum;
            timingManger.boxNoteList[noteLineNum].Remove(collision.gameObject);

            Destroy(collision.gameObject);
        }
    }
}
