using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    public static MouseEvent Instance;


    public CameraShake cameraShake;

    public AnimManager animManager;
    public AnimManager animManager1;
    public AnimManager animManager2;

    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Update()
    {
        MouseClick();
    }

    void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Pos, Vector2.zero, 0f);

            switch (hit.collider.name)
            {
                case "Tree":
                    DataBaseManager.Instance.TreeCount += 1;
                    Instantiate(DataBaseManager.Instance.Wood, PlayerUI.Instance.Tree_Tr.position, Quaternion.identity);
                    animManager.TreeAnim();
                    audioSource.PlayOneShot(audioClip);
                    break;

                case "Stone":
                    DataBaseManager.Instance.StoneCount += 1;
                    Instantiate(DataBaseManager.Instance.Stone, PlayerUI.Instance.Stone_Tr.position, Quaternion.identity);
                    animManager1.StoneAnim();
                    audioSource.PlayOneShot(audioClip);
                    break;

                case "WillSonBack":
                    DataBaseManager.Instance.MentalCount += 1;
                    Instantiate(DataBaseManager.Instance.Mental, PlayerUI.Instance.WillSon_Tr.position, Quaternion.identity);
                    animManager2.PlayAnim();
                    audioSource.PlayOneShot(audioClip);
                    break;

                case "Bird(Clone)":
                    Debug.Log("Bird hit detected.");
                    cameraShake.Shake();
                    Bird.Instance.DestroyBird();
                    break;

                default:
                    Debug.Log("Unrecognized object: " + hit.collider.name);
                    break;

            }
        }
    }
}


