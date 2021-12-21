using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneKontrolu : MonoBehaviour
{
   public void sonrakiSahne()
    {
        int mevcutSahneIndeksi = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(mevcutSahneIndeksi + 1);
    }

    public void SahneyeYonlen(string sahneIsmi)
    {
        SceneManager.LoadScene(sahneIsmi);
    }

    public void OyunSahnesineYonlen()
    {
        SceneManager.LoadScene(1);
    }

    public void OyundanCikis()
    {
        Application.Quit();
    }

    public void MenuSahnesineYonlen()
    {
        SceneManager.LoadScene(0);
    }

    public void BloklarinYokOlmasi()
    {
        if (Bloklar.breakableBlockCount <= 0)
        {
            sonrakiSahne();
        }
    }
}
