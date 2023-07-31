using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimingManager : MonoBehaviour
{
    int score = 0;
    int lineMaxNum = 6;
    public List<GameObject>[] boxNoteList;

    [SerializeField] Transform Center;
    [SerializeField] RectTransform[] timingRect;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int[] scoreList;

    Vector2[] timingBoxs;
    EffectManager effect;

    AudioSource popSound;

    void Start()
    {
        boxNoteList = new List<GameObject>[lineMaxNum];

        for (int i = 0; i < lineMaxNum; ++i)
            boxNoteList[i] = new List<GameObject>();

        effect = FindObjectOfType<EffectManager>();

        // 타이밍 박스 설정
        timingBoxs = new Vector2[timingRect.Length];

        for (int i = 0; i < timingRect.Length; ++i)
        {
            timingBoxs[i].Set(Center.localPosition.y - timingRect[i].rect.height / 2, // 최소값: 중심 - (이미지의 높이 / 2)
                Center.localPosition.y + timingRect[i].rect.height / 2);    // 최대값: 중심 + (이미지의 높이 / 2)
        }

        popSound = GetComponent<AudioSource>();
    }

    public void CheckTiming(int noteLocationNum)
    {
        for (int i = 0; i < boxNoteList[noteLocationNum].Count; ++i)    // 나중에 없애야 할듯??
        {
            float notePosY 
                = boxNoteList[noteLocationNum][i].transform.localPosition.y 
                + boxNoteList[noteLocationNum][i].transform.parent.localPosition.y; // parent.position 영향을 없애기 위한 코드
            
            for (int j = 0; j < timingBoxs.Length; ++j)
            {
                if (timingBoxs[j].x <= notePosY && notePosY <= timingBoxs[j].y)
                {
                    // 노트 제거
                    boxNoteList[noteLocationNum][i].GetComponent<Note>().HideNote();
                    boxNoteList[noteLocationNum].RemoveAt(i);

                    // 이펙트 연출
                    if (j < timingBoxs.Length - 1)
                        effect.NoteHitEffect(noteLocationNum);
                    effect.JudgementEffect(j);

                    // 소리 
                    popSound.Play();

                    // score
                    score += scoreList[j];
                    scoreText.text = score.ToString();
                    return;
                }
            }
        }
    }
}
