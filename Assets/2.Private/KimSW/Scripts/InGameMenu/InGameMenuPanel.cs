using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class InGameMenuPanel : FadePanel
{
    [Inject]
    InGameUI inGameUI;

    private void Awake()
    {
        SetComponent();
    }
  

    public void ResumeGame()
    {
        // ���� ����
        inGameUI.OffInGameMenu();

    }

    public void OnOptionMenu()
    {
        // �ɼ� �޴� Ȱ��ȭ
    }

    public void TutorialEnd()
    {
        // Ʃ�丮�� ����
    }

    public void ExitGameScene()
    {
        // ���Ӿ� ������
    }



 
}
