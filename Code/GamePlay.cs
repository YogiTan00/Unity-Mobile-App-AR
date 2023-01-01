using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    public GameObject CameR;
    public GameObject CameP;
    public GameObject Island;
    public GameObject Hewan;
    public GameObject Water;
    public TextAsset tData;
    public Toggle tBeranak;
    public Toggle tBerantena;
    public Toggle tBerbulu;
    public Toggle tBercangkang;
    public Toggle tBergigi;
    public Toggle tBerkaki2;
    public Toggle tBerkaki4;
    public Toggle tBerkakiBanyak;
    public Toggle tBerkuku;
    public Toggle tBerkulit;
    public Toggle tBerkumis;
    public Toggle tBerparuh;
    public Toggle tBersayap;
    public Toggle tBerselaput;
    public Toggle tBersirip;
    public Toggle tBersisik;
    public Toggle tBertanduk;
    public Toggle tBertaring;
    public Toggle tBertelur;
    public Button bFind;

    [SerializeField] public Text _dEkos;
    [SerializeField] public Text _dDeskripsi;

    int[] Ciric = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    float[] Hasil = new float[90];
    float nHasil;
    int cFind;
    float nMin;
    float nAir;
    float nDarat;
    float nDaratAir;

    [System.Serializable]

    public class DataSet
    {
        public string Nama;
        public int bAnak;
        public int bAntena;
        public int bBulu;
        public int bCangkang;
        public int bGigi;
        public int bKaki2;
        public int bKaki4;
        public int bKakiB;
        public int bKuku;
        public int bKulit;
        public int bKumis;
        public int bParuh;
        public int bSayap;
        public int bSelaput;
        public int bSirip;
        public int bSisik;
        public int bTanduk;
        public int bTaring;
        public int bTelur;
        public string Kelas;
    }

    [System.Serializable]
    public class DataSetList
    {
        public DataSet[] dataset;
    }

    public DataSetList myDataList = new DataSetList();


    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();
    }

    void Update()
    {
        ActiveToggle();
        cFind = Ciric.Sum();
        if (cFind == 0)
        {
            bFind.interactable = false;
        }
        else
        if (cFind != 0)
        {
            bFind.interactable = true;
        }
    }

    public void ActiveToggle()
    {
        if (tBeranak.isOn)
        {
            Ciric[0] = 1;
        }
        if (tBerantena.isOn)
        {
            Ciric[1] = 1;
        }
        if (tBerbulu.isOn)
        {
            Ciric[2] = 1;
            tBerkulit.isOn = true;
        }
        if (tBercangkang.isOn)
        {
            Ciric[3] = 1;
            tBerkulit.isOn = true;
        }
        if (tBergigi.isOn)
        {
            Ciric[4] = 1;
        }
        if (tBerkaki2.isOn)
        {
            Ciric[5] = 1;
            tBerkaki4.isOn = false;
            tBerkakiBanyak.isOn = false;
        }
        else
        if (tBerkaki4.isOn)
        {
            Ciric[6] = 1;
            tBerkaki2.isOn = false;
            tBerkakiBanyak.isOn = false;
        }
        else
        if (tBerkakiBanyak.isOn)
        {
            Ciric[7] = 1;
            tBerkaki2.isOn = false;
            tBerkaki4.isOn = false;
        }

        if (tBerkuku.isOn)
        {
            Ciric[8] = 1;
        }
        if (tBerkulit.isOn)
        {
            Ciric[9] = 1;
        }
        if (tBerkumis.isOn)
        {
            Ciric[10] = 1;
        }
        if (tBerparuh.isOn)
        {
            Ciric[11] = 1;
        }
        if (tBersayap.isOn)
        {
            Ciric[12] = 1;
        }
        if (tBerselaput.isOn)
        {
            Ciric[13] = 1;
        }
        if (tBersirip.isOn)
        {
            Ciric[14] = 1;
        }
        if (tBersisik.isOn)
        {
            Ciric[15] = 1;
            tBerkulit.isOn = true;
        }
        if (tBertanduk.isOn)
        {
            Ciric[16] = 1;
        }
        if (tBertaring.isOn)
        {
            Ciric[17] = 1;
        }
        if (tBertelur.isOn)
        {
            Ciric[18] = 1;
        }
    }

    void ReadCSV()
    {
        string[] data = tData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 21 - 1;
        myDataList.dataset = new DataSet[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myDataList.dataset[i] = new DataSet();
            myDataList.dataset[i].Nama = data[21 * (i + 1)];
            myDataList.dataset[i].bAnak = int.Parse(data[21 * (i + 1) + 1]);
            myDataList.dataset[i].bAntena = int.Parse(data[21 * (i + 1) + 2]);
            myDataList.dataset[i].bBulu = int.Parse(data[21 * (i + 1) + 3]);
            myDataList.dataset[i].bCangkang = int.Parse(data[21 * (i + 1) + 4]);
            myDataList.dataset[i].bGigi = int.Parse(data[21 * (i + 1) + 5]);
            myDataList.dataset[i].bKaki2 = int.Parse(data[21 * (i + 1) + 6]);
            myDataList.dataset[i].bKaki4 = int.Parse(data[21 * (i + 1) + 7]);
            myDataList.dataset[i].bKakiB = int.Parse(data[21 * (i + 1) + 8]);
            myDataList.dataset[i].bKuku = int.Parse(data[21 * (i + 1) + 9]);
            myDataList.dataset[i].bKulit = int.Parse(data[21 * (i + 1) + 10]);
            myDataList.dataset[i].bKumis = int.Parse(data[21 * (i + 1) + 11]);
            myDataList.dataset[i].bParuh = int.Parse(data[21 * (i + 1) + 12]);
            myDataList.dataset[i].bSayap = int.Parse(data[21 * (i + 1) + 13]);
            myDataList.dataset[i].bSelaput = int.Parse(data[21 * (i + 1) + 14]);
            myDataList.dataset[i].bSirip = int.Parse(data[21 * (i + 1) + 15]);
            myDataList.dataset[i].bSisik = int.Parse(data[21 * (i + 1) + 16]);
            myDataList.dataset[i].bTanduk = int.Parse(data[21 * (i + 1) + 17]);
            myDataList.dataset[i].bTaring = int.Parse(data[21 * (i + 1) + 18]);
            myDataList.dataset[i].bTelur = int.Parse(data[21 * (i + 1) + 19]);
            myDataList.dataset[i].Kelas = data[21 * (i + 1) + 20];
        }
    }

    public void Find()
    {
        Start();
        ActiveToggle();
        ReadCSV();
        for (int i = 0; i < Hasil.Length; i++)
        {

            Hasil[i] = (Mathf.Pow((myDataList.dataset[i].bAnak - Ciric[0]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bAntena - Ciric[1]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bBulu - Ciric[2]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bCangkang - Ciric[3]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bGigi - Ciric[4]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bKaki2 - Ciric[5]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bKaki4 - Ciric[6]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bKakiB - Ciric[7]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bKuku - Ciric[8]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bKulit - Ciric[9]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bKumis - Ciric[10]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bParuh - Ciric[11]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bSayap - Ciric[12]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bSelaput - Ciric[13]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bSirip - Ciric[14]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bSisik - Ciric[15]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bTanduk - Ciric[16]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bTaring - Ciric[17]), 2)
                         + Mathf.Pow((myDataList.dataset[i].bTelur - Ciric[18]), 2));


            Hasil[i] = Mathf.Sqrt(Hasil[i]);
        }

        //Ekosistem
        List<float> sAir = new List<float>()
        {
            Hasil[0], Hasil[1], Hasil[2], Hasil[3], Hasil[4], Hasil[5],
            Hasil[6], Hasil[7], Hasil[8], Hasil[9], Hasil[10], Hasil[11],
            Hasil[12], Hasil[13], Hasil[14], Hasil[15], Hasil[16], Hasil[17],
            Hasil[18], Hasil[19], Hasil[20], Hasil[21], Hasil[22], Hasil[23],
            Hasil[24], Hasil[25], Hasil[26], Hasil[27], Hasil[28], Hasil[29]
        };
        sAir.Sort();
        List<float> sDarat = new List<float>()
        {
            Hasil[30], Hasil[31], Hasil[32], Hasil[33], Hasil[34], Hasil[35],
            Hasil[36], Hasil[37], Hasil[38], Hasil[39], Hasil[40], Hasil[41],
            Hasil[42], Hasil[43], Hasil[44], Hasil[45], Hasil[46], Hasil[47],
            Hasil[48], Hasil[49], Hasil[50], Hasil[51], Hasil[52], Hasil[53],
            Hasil[54], Hasil[55], Hasil[56], Hasil[57], Hasil[58], Hasil[59]
        };
        sDarat.Sort();
        List<float> sDaratAir = new List<float>()
        {
            Hasil[60], Hasil[61], Hasil[62], Hasil[63], Hasil[64], Hasil[65],
            Hasil[66], Hasil[67], Hasil[68], Hasil[69], Hasil[70], Hasil[71],
            Hasil[72], Hasil[73], Hasil[74], Hasil[75], Hasil[76], Hasil[77],
            Hasil[78], Hasil[79], Hasil[80], Hasil[81], Hasil[82], Hasil[83],
            Hasil[84], Hasil[85], Hasil[86], Hasil[87], Hasil[88], Hasil[89]
        };
        sDaratAir.Sort();

        nAir = (sAir[0] + sAir[1] + sAir[2] + sAir[3] + sAir[4] + sAir[5]) / 6;
        nDarat = (sDarat[0] + sDarat[1] + sDarat[2] + sDarat[3] + sDarat[4] + sDarat[5]) / 6;
        nDaratAir = (sDaratAir[0] + sDaratAir[1] + sDaratAir[2] + sDaratAir[3] + sDaratAir[4] + sDaratAir[5]) / 6;
        nHasil = Mathf.Min(nAir, nDarat, nDaratAir);
    }
 
    public void nBack()
    {
        Ciric[0] = 0;
        Ciric[1] = 0;
        Ciric[2] = 0;
        Ciric[3] = 0;
        Ciric[4] = 0;
        Ciric[5] = 0;
        Ciric[6] = 0;
        Ciric[7] = 0;
        Ciric[8] = 0;
        Ciric[9] = 0;
        Ciric[10] = 0;
        Ciric[11] = 0;
        Ciric[12] = 0;
        Ciric[13] = 0;
        Ciric[14] = 0;
        Ciric[15] = 0;
        Ciric[16] = 0;
        Ciric[17] = 0;
        Ciric[18] = 0;

        tBeranak.isOn = false;
        tBerantena.isOn = false;
        tBerbulu.isOn = false;
        tBercangkang.isOn = false;
        tBergigi.isOn = false;
        tBerkaki2.isOn = false;
        tBerkaki4.isOn = false;
        tBerkakiBanyak.isOn = false;
        tBerkuku.isOn = false;
        tBerkulit.isOn = false;
        tBerkumis.isOn = false;
        tBerparuh.isOn = false;
        tBersayap.isOn = false;
        tBerselaput.isOn = false;
        tBersirip.isOn = false;
        tBersisik.isOn = false;
        tBertanduk.isOn = false;
        tBertaring.isOn = false;
        tBertelur.isOn = false;
        CameR.transform.rotation = Quaternion.identity;
        Island.SetActive(false);
        Hewan.SetActive(false);
        Water.SetActive(false);
    }

    public void EkosMenu()
    {
        if (nAir == nHasil)
        {
            CameP.transform.position = new Vector3(-30, 5, 24); 
            _dEkos.text = "Air";
            _dDeskripsi.text = "Ekosistem Air merupakan hewan yang hidup sebagian besar atau seluruhnya di dalam air";
        }
        else
        if (nDarat == nHasil)
        {
            CameP.transform.position = new Vector3(-14, 13, 11);
            _dEkos.text = "Darat";
            _dDeskripsi.text = "Ekosistem Darat merupakan hewan yang hidup sebagian " +
                "besar atau seluruhnya di darat atau tempat terestrial";
        }
        else
        if (nDaratAir == nHasil)
        {
            CameP.transform.position = new Vector3(-24, 11, 15);
            _dEkos.text = "Darat & Air";
            _dDeskripsi.text = "Ekosistem Darat & Air merupakan hewan yang hidup mengandalkan pada kombinasi habitat akuatik dan darat.";
        }
        Island.SetActive(true);
        Hewan.SetActive(true);
        Water.SetActive(true);
    }

    public void EkoAR()
    {
        if (nAir == nHasil)
        {
            SceneManager.LoadScene("SAir");
        }
        else
        if (nDarat == nHasil)
        {
            SceneManager.LoadScene("SDarat");
        }
        else
        if (nDaratAir == nHasil)
        {
            SceneManager.LoadScene("SDaratAndAir");
        }
    }
}
