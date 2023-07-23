using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimingManager : MonoBehaviour
{
    int score = 0;
    static int lineMaxNum = 6;
    public List<GameObject>[] boxNoteList = new List<GameObject>[lineMaxNum];

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int[] scoreList;

    Vector2[] timingBoxs = null;
    EffectManager effect;

    void Start()
    {
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
    }

    public void CheckTiming(int noteLocationNum)
    {
        for (int i = 0; i < boxNoteList[noteLocationNum].Count; ++i)    // 나중에 없애야 할듯??
        {
            float notePosY = boxNoteList[noteLocationNum][i].transform.localPosition.y;
            for (int j = 0; j < timingBoxs.Length; ++j)
            {
                if (timingBoxs[j].x <= notePosY && notePosY <= timingBoxs[j].y)
                {
                    // 노트 제거
                    boxNoteList[noteLocationNum][i].GetComponent<Note>().HideNote();
                    boxNoteList[noteLocationNum].RemoveAt(i);

                    // 이펙트 연출
                    if (j < timingBoxs.Length - 1)
                        effect.NoteHitEffect();
                    effect.JudgementEffect(j);

                    // score
                    score += scoreList[j];
                    scoreText.text = score.ToString();
                    return;
                }
            }
        }
    }
}
