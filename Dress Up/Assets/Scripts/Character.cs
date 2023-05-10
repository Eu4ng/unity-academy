using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    // �Ӹ�, ����, ���� ������ �� ������ List�� �����Ͽ� ����
    List<GameObject> hairs = new List<GameObject>();
    List<GameObject> upBodys = new List<GameObject>();
    List<GameObject> downBodys = new List<GameObject>();

    // �ڽ����� �� �ִ� ������ �ǻ�鿡 �����ϱ� ���Ͽ�
    public Transform hairGroup;
    public Transform upBodyGroup;
    public Transform downBodyGroup;

    public int hairIndex = 0;
    public int upBodyIndex = 0;
    public int downBodyIndex = 0;
    public int animationIndex = 0;

    private void Awake()
    {
        ImportObjects(ref hairs, hairGroup);
        ImportObjects(ref upBodys, upBodyGroup);
        ImportObjects(ref downBodys, downBodyGroup);

        LoadCurrentDresses();
    }

    private void Start()
    {
        ShowDressAll();
        GetComponent<Animator>().SetInteger("AnimationIndex", animationIndex);
    }

    void ImportObjects(ref List<GameObject> gameObjects, Transform group)
    {
        foreach (Transform transform in group)
        {
            transform.gameObject.SetActive(false);
            gameObjects.Add(transform.gameObject);
        }
    }

    void ShowDress(ref List<GameObject> gameObjects, int index)
    {
        if (gameObjects.Count >= index + 1)
        {
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.SetActive(false);
            }
            gameObjects[index].SetActive(true);
        }
    }

    void ShowDressAll()
    {
        ShowDress(ref hairs, hairIndex);
        ShowDress(ref upBodys, upBodyIndex);
        ShowDress(ref downBodys, downBodyIndex);
    }

    public void ChangeHair()
    {
        hairIndex = hairIndex >= hairs.Count - 1 ? 0 : hairIndex + 1;
        ShowDress(ref hairs, hairIndex);
    }

    public void ChangeUpbody()
    {
        upBodyIndex = upBodyIndex >= upBodys.Count - 1 ? 0 : upBodyIndex + 1;
        ShowDress(ref upBodys, upBodyIndex);
    }

    public void ChangeDownBody()
    {
        downBodyIndex = downBodyIndex >= downBodys.Count - 1 ? 0 : downBodyIndex + 1;
        ShowDress(ref downBodys, downBodyIndex);
    }

    public void ChangeAnimation()
    {
        int animationCount = 4;
        animationIndex = animationIndex >= animationCount - 1 ? 0 : animationIndex + 1;
        GetComponent<Animator>().SetInteger("AnimationIndex", animationIndex);
    }

    public void SaveCurrentDresses()
    {
        PlayerPrefs.SetInt("hairIndex", hairIndex);
        PlayerPrefs.SetInt("upBodyIndex", upBodyIndex);
        PlayerPrefs.SetInt("downBodyIndex", downBodyIndex);
        PlayerPrefs.SetInt("animationIndex", animationIndex);
    }

    public void LoadCurrentDresses()
    {
        hairIndex = PlayerPrefs.GetInt("hairIndex");
        upBodyIndex = PlayerPrefs.GetInt("upBodyIndex");
        downBodyIndex = PlayerPrefs.GetInt("downBodyIndex");
        animationIndex = PlayerPrefs.GetInt("animationIndex");
    }
}
