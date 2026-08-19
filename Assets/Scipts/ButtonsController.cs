using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class BtnsController : MonoBehaviour
{
    public GameObject GuideWindow;
    void Start()
    {
        GuideWindow.SetActive(false);
    }
    public void LoadEasy()
    {
        SceneManager.LoadScene("EasyMap");
    }
    public void LoadMedium()
    {
        SceneManager.LoadScene("MediumMap");
    }
    public void LoadHard()
    {
        SceneManager.LoadScene("HardMap");
    }
    public void ShowGuide()
    {
        GuideWindow.SetActive(true);
    }
    public void HideGuide()
    {
        GuideWindow.SetActive(false);
    }
}
