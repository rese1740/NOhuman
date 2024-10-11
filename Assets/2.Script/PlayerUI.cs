using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("�ؽ�Ʈ")]
    public Text Treetxt;
    public Text Stonetxt;
    public Text Mentaltxt;
    public Text Timetxt;

    [Header("��ġ")]
    public Transform Tree_Tr;
    public Transform Stone_Tr;
    public Transform Spawn_Tr;
    public Transform WillSon_Tr;
    public GameObject MainCamera;

    [Header("������")]
    public DataBaseManager dataBaseManager;

    

    [Header("��")]
    public GameObject bird;
    public float birdCount;
    public Transform BirsSpawn;
    public bool birdnow = true;

    [Header("UI")]
    public GameObject SettingUi;
    public GameObject BoatUi;
    public GameObject ErrorUi;
    public GameObject MapUI;
    public float sec;
    public int min;

    #region Singleton
    public static PlayerUI Instance;

    private void Awake()
    {
        dataBaseManager.Init();
        Instance = this;
    }
    #endregion

    void Update()
    {
        Treetxt.text = ":" + $"{DataBaseManager.Instance.TreeCount}";
        Stonetxt.text = ":" + $"{DataBaseManager.Instance.StoneCount}";
        Mentaltxt.text = ":" + $"{DataBaseManager.Instance.MentalCount:N0}";
        Timetxt.text = min + ":" + $"{sec:N0}";


        //���ŷ°���
        DataBaseManager.Instance.MentalCount -= Time.deltaTime;

        //�÷���Ÿ��
        sec += Time.deltaTime;
        if (sec >= 59)
        {
            min += 1;
            sec = 0;
        }

        //��Ż��
        if (DataBaseManager.Instance.MentalCount >= 100)
        {
            DataBaseManager.Instance.MentalCount = 100f;
        }
        else if (DataBaseManager.Instance.MentalCount <= 0)
        {
            SceneManager.LoadScene("Fail");
        }

        //��
        birdCount += Time.deltaTime;

        if (birdnow == true)
        {
            if (birdCount >= 5)
            {
                birdCount = 0;
                Instantiate(bird, BirsSpawn);
                birdnow = false;
            }

        }
    }

    public void Teleport1()
    {
        MainCamera.transform.position = Tree_Tr.transform.position;
        MainCamera.transform.position = MainCamera.transform.position + new Vector3(0, 0, -100);
    }

    public void Teleport2()
    {
        MainCamera.transform.position = Stone_Tr.transform.position;
        MainCamera.transform.position = MainCamera.transform.position + new Vector3(0, 0, -100);
    }
    public void Teleport3()
    {
        MainCamera.transform.position = Spawn_Tr.transform.position;
        MainCamera.transform.position = MainCamera.transform.position + new Vector3(0, 0, -100);
    }
    public void Teleport4()
    {
        MainCamera.transform.position = WillSon_Tr.transform.position;
        MainCamera.transform.position = MainCamera.transform.position + new Vector3(0, 0, -100);
    }

    public void BoatEnding1()
    {
        BoatUi.SetActive(true);
    }

    public void BoatEnding2()
    {
        if (DataBaseManager.Instance.TreeCount > 99 && DataBaseManager.Instance.StoneCount > 99)
        {
            SceneManager.LoadScene("Ending");
        }
        else
        {
            ErrorUi.SetActive(true);
        }
    }

    public void BoatUiX()
    {
        BoatUi.SetActive(false);
        ErrorUi.SetActive(false);
    }

    public void SettingOpen()
    {
        SettingUi.SetActive(true);
    }
    public void SettingClose()
    {
        SettingUi.SetActive(false);
    }

    //��
    public void MapUIOpen()
    {
        MapUI.SetActive(!MapUI.activeSelf);
    }
}
