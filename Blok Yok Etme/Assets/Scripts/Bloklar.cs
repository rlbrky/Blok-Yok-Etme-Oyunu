using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloklar : MonoBehaviour
{
    public GameObject blokKirilmaEfekti;
    public static int breakableBlockCount = 0;
    public int hit;
    private SahneKontrolu sahneYoneticisi;
    public Sprite[] blokGorunumleri;
    bool kirilabilirMi;
    // Start is called before the first frame update
    void Start()
    {
        //Çarptığı objenin tag'i breakable ise true değer alır.
        kirilabilirMi = (this.tag == "Breakable");

        //Her kırılabilir blok oluştuğunda sayaç çalışacak.
        if (kirilabilirMi)
        {
            breakableBlockCount++;
        }
        hit = 0;
        sahneYoneticisi = GameObject.FindObjectOfType<SahneKontrolu>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
        if (kirilabilirMi)
        {
            HitControl();
        }
    }

    public void HitControl()
    {
        int hp = blokGorunumleri.Length + 1;
        hit++;
        //Algoritma açısından, bug olma ihtimaline karşı bir önlem.
        if (hit >= hp)
        {
            breakableBlockCount--;
            createEffect();
            //this yaparsan class'a ulaşır ancak bloğu yok edemezsin, o yüzden gameObject kullanıyoruz.
            Destroy(gameObject);
            //Her bir blok yok olduğunda kontrol ediyoruz, böylece blok sayısı 0 olduğunda yeni seviyeye geçeceğiz.
            sahneYoneticisi.BloklarinYokOlmasi();
        }
        else
        {
            BlokGoruntusunuDegistir();
        }
    }

    void createEffect()
    {
        //Efektin bloğun kırıldığı yerde oluşması için pozisyonu da yolladık, Quaternon hakkında bilgilendirme yapılmadı.
        GameObject efektGercekleme = Instantiate(blokKirilmaEfekti, gameObject.transform.position, Quaternion.identity) as GameObject;
        //Kırılan bloğun rengini efekte atamayı deniyoruz
        efektGercekleme.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    public void BlokGoruntusunuDegistir()
    {
        //hit = 1 iken 0. indexteki görüntüye ulaşmalıyız.(Element 0)
        this.GetComponent<SpriteRenderer>().sprite = blokGorunumleri[hit - 1];
    }

    public void sonrakiSahne()
    {
        sahneYoneticisi.sonrakiSahne();
    }
}
