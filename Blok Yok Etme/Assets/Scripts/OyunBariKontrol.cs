using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunBariKontrol : MonoBehaviour
{
    public bool otomatikOynama = false;
    private OyunTopuKontrol top;
    // Start is called before the first frame update
    void Start()
    {
        top = GameObject.FindObjectOfType<OyunTopuKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        if (otomatikOynama)
        {
            otomatikHareket();
        }
        else
        {
            mouseSync();
        }
    }

    //Oyun barının farenin hareketini takip etmesini sağlıyoruz.
    void mouseSync()
    {
        //OyunBariKontrol scriptine sahip olan nesneye this ile ulaşıyoruz.
        Vector3 oyunBariKonum = new Vector3(0f, this.transform.position.y, 0f);
        float mouseKonumX = Input.mousePosition.x / Screen.width * 16;
        oyunBariKonum.x = Mathf.Clamp(mouseKonumX, 1f, 15f);

        this.transform.position = oyunBariKonum;
    }

    //Otomatik oynanmanın gerçeklenmesi.
    void otomatikHareket()
    {
        Vector3 oyunBariKonum = new Vector3(0f, this.transform.position.y, 0f);
        //Otomatik oynanış.
        Vector3 topKonum = top.transform.position;
        oyunBariKonum.x = Mathf.Clamp(topKonum.x, 1f, 15f);

        this.transform.position = oyunBariKonum;
    }
}
