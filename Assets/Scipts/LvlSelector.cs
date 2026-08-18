using UnityEngine;
using UnityEngine.SceneManagement;


public class LvlSelector : MonoBehaviour
{
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
}
