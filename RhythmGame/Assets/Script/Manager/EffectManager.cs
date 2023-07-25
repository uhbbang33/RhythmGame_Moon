using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] Animator[] noteHitAnimator;
    string hit;
    string judgementHit;

    [SerializeField] Animator judgementAnimator;
    [SerializeField] UnityEngine.UI.Image judgementImage;
    [SerializeField] Sprite[] judgementSprite;

    void Start()
    {
        hit = "Hit";
        judgementHit = "Hit";
    }

    public void NoteHitEffect(int lineNum)
    {
        noteHitAnimator[lineNum].SetTrigger(hit);
    }

    public void JudgementEffect(int num)
    {
        judgementImage.sprite = judgementSprite[num];
        judgementAnimator.SetTrigger(judgementHit);
    }
}
