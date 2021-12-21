using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muzikoynatma : MonoBehaviour
{
    //Müzik oynatıcısı sayısını tutmak için değişkenimiz.
    //[SerializeField] int x = 0; --> objeye has bir değişken, obje yeniden oluştuğunda bu da yeniden oluşuyor.
    // static int x = 0; //--> geçici bellekte tutulan bir değişken
    //Bu serialize field yerine static kullanarak, değerin korunmasını sağladık
    //böylece müzik oynatmanın sayısını kontrol edebiliyoruz.

    static muzikoynatma TekMuzikOynaticisi = null;
    
    
    //Awake metodu start metodundan daha önce çalışır. Nereye yazarsan yaz, start fonksiyonundan önce çalışacak.+
    private void Awake()
    {
        Debug.Log("Awake metodu çalıştı...");
        //Asıl kodun yazılması, müzik oynatıcısı kontrolü ve sayısının sabitlenmesi.
        if (TekMuzikOynaticisi != null) //müzik oynatıcısı varsa
        {
            /* Buradaki kodda ID'ler farklı gelecektir.
             * Debug.Log(GetInstanceID());
            Debug.Log(TekMuzikOynaticisi.GetInstanceID());*/
            Destroy(gameObject);
        }
        else //müzik oynatıcısı yoksa
        {
            TekMuzikOynaticisi = this;
           /*Aşağıdaki kodda ID'ler aynı gelir.
            * Debug.Log(GetInstanceID());
            Debug.Log(TekMuzikOynaticisi.GetInstanceID());*/
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        //x++;
        //X sayısını konsola yazdırarak, müzik oynatıcımızın sayısını görüntülüyoruz.
       //Debug.Log(x);

       //Yaptığımız kontrol sonucu müzik oynatıcısının yeni obje adına oluştuğunu gördük.

        
    }

    
    void Update()
    {
        
    }
}
