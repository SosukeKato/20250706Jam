using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitelManger : MonoBehaviour
{
    private AudioSource _audiosource;

    private AudioClip _Buttan;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartGame()//�^�C�g���V�[���ֈړ�
    {
        // "GameScene" �͑J�ڐ�̃V�[����
        SceneManager.LoadScene("StageScene");
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // �r���h��ɃA�v���P�[�V�������I��
        Application.Quit();
#endif
    }
}
