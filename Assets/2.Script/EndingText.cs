using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingText : MonoBehaviour
{
    public Text uiText; // UI Text ������Ʈ
    public float typingSpeed = 0.5f; // Ÿ���� �ӵ�

    void Awake()
    {
        Debug.Log(13213213132123.2);
        string message = "End........?";
        StartCoroutine(TypeText(message));
    }

    IEnumerator TypeText(string message)
    {
        uiText.text = ""; // �ؽ�Ʈ �ʱ�ȭ
        foreach (char letter in message.ToCharArray())
        {
            uiText.text += letter; // �� ���ھ� �߰�
            yield return new WaitForSeconds(typingSpeed); // ���
        }

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Start");
    }
}

