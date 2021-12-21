using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunTopuKontrol : MonoBehaviour
{
    public OyunBariKontrol oyunBari;
    private bool oyunBasladiMi;
    private Vector3 TopIleBarArasiMesafe;

    private void Start()
    {
        TopIleBarArasiMesafe = this.transform.position - oyunBari.transform.position;
    }

    private void Update()
    {
        if (!oyunBasladiMi)
        {
            //Oyun topunun pozisyonu barın pozisyonu ile aralarındaki mesafenin toplamına eşittir.
            this.transform.position = oyunBari.transform.position + TopIleBarArasiMesafe;
            if (Input.GetMouseButtonDown(0))
            {
                oyunBasladiMi = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector3(2f, 9f, 0f);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Topun yönünü ufakça saptırıyoruz, böylece top bugda kalmayacak. 
        Vector2 ufakSapma = new Vector2(Random.Range(0f, 0.3f), Random.Range(0f, 0.3f));
        if (oyunBasladiMi)
        {
            GetComponent<AudioSource>().Play();
            //Yazdığımız sapma fonksiyonunu topa atayarak bug'u gideriyoruz.
            GetComponent<Rigidbody2D>().velocity += ufakSapma;
        }
    }
}
