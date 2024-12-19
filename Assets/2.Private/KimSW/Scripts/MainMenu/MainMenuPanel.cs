using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class MainMenuPanel : FadePanel, IOpenCloseMenu
{
    [Inject]
    MainSceneUI mainUI;


    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(selectButton.gameObject);
    }



    private void OnDisable()
    {

        if (mainUI.CurrentMenu.Equals(this) == false)
        {
            mainUI.CurrentMenu.OpenUIPanel();
        }
    }

    public void LoadGame()
    {
        FadeOutUI();
        mainUI.CurrentMenu = mainUI.LoadGamePanel;
       
        // ����ϱ� Ȱ��ȭ 
    }

    public void NewGame()
    {
        FadeOutUI();
        mainUI.CurrentMenu = mainUI.NewGamePanel;
       
        // �����ϱ� Ȱ��ȭ
    }

    public void OnOptionMenu()
    {
        // �ɼ� �޴� Ȱ��ȭ
    }

    public void ExitGame()
    {
        // ���� ������
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }



    public void CloseUIPanel()
    {
        
    }

 

    public void OpenUIPanel()
    {
        gameObject.SetActive(true);
        FadeInUI();
    }
}
