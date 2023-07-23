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

        // Ÿ�̹� �ڽ� ����
        timingBoxs = new Vector2[timingRect.Length];

        for (int i = 0; i < timingRect.Length; ++i)
        {
            timingBoxs[i].Set(Center.localPosition.y - timingRect[i].rect.height / 2, // �ּҰ�: �߽� - (�̹����� ���� / 2)
                Center.localPosition.y + timingRect[i].rect.height / 2);    // �ִ밪: �߽� + (�̹����� ���� / 2)
        }
    }

    public void CheckTiming(int noteLocationNum)
    {
        for (int i = 0; i < boxNoteList[noteLocationNum].Count; ++i)    // ���߿� ���־� �ҵ�??
        {
            float notePosY = boxNoteList[noteLocationNum][i].transform.localPosition.y;
            for (int j = 0; j < timingBoxs.Length; ++j)
            {
                if (timingBoxs[j].x <= notePosY && notePosY <= timingBoxs[j].y)
                {
                    // ��Ʈ ����
                    boxNoteList[noteLocationNum][i].GetComponent<Note>().HideNote();
                    boxNoteList[noteLocationNum].RemoveAt(i);

                    // ����Ʈ ����
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
