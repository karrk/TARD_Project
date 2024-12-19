using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class DamageText : MonoBehaviour, IPooledObject
{
    [ColorUsageAttribute(true, true)]
    [SerializeField] private Color normalColor;

    [ColorUsageAttribute(true, true)]
    [SerializeField] private Color skillColor;

    [SerializeField] int normalFontSize;
    [SerializeField] int skillFontSize;

    [SerializeField] float duration;
    [SerializeField] float delay;
    [SerializeField] float moveDistance;

    [Inject]
    PoolManager poolManager;

    TMP_Text damageText;

   

    Enum IPooledObject.MyType => E_VFX.DamageText;

    GameObject IPooledObject.MyObj => gameObject;

    private void Awake()
    {
        damageText = GetComponent<TMP_Text>();
    }
 

    /// <summary>
    /// 데미지 텍스트 세팅 후 애니메이션 시작
    /// str = 텍스트, vec = 생성 위치, isSkill 스킬 텍스트 구분
    /// </summary>
    public void SetText(string str, Vector3 vec, bool isSkill)
    {
        damageText.text = str;

        if (isSkill)
        {
            damageText.color = skillColor;
            damageText.fontSize = skillFontSize;
        }
        else
        {
            damageText.color = normalColor;
            damageText.fontSize = normalFontSize;
        }

        StartTextAnimation(vec);
    }

    public void StartTextAnimation(Vector3 vec)
    {
        transform.position = vec;

        vec.y += moveDistance;

        

        transform.DOMove(vec, duration).SetDelay(delay);
        damageText.DOFade(1f, 0).OnComplete(() => {
            damageText.DOFade(0, duration).SetDelay(delay).OnComplete(() => {
                Return();
            });
        });
    }

    public void Return()
    {
        poolManager.Return(this);
    }
}