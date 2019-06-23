using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warcaby;
using System.Windows;


namespace MetodyTest
{
    [TestClass]
    public class MetodyTest
    {
        [TestMethod]
        public void zwroc_wartosc_test()
        {
            Metody rozgrywka = new Metody();
            rozgrywka.Wartosc_x = 0;
            rozgrywka.Wartosc_y = 0;
            int[,] mac = new int[1, 1];
            mac[0, 0] = 2;
            int oczekiwana = 2;
            int z = rozgrywka.zwroc_wartosc(rozgrywka.Wartosc_x, rozgrywka.Wartosc_y, mac);
            Assert.AreEqual( oczekiwana,  z);
            
        }

        [TestMethod]
        public void zmien_wartosc_test()
        {
            int x = 0;
            int y = 0;
            int[,] mac = new int[1, 1];
            int z = 5;
            int oczekiwana = 5;
            Metody test = new Metody();
            test.zmien_wartosc(x, y, mac, z);
            Assert.AreEqual(oczekiwana, mac[0, 0]);
        }

        [TestMethod]
        public void sprawdz_lewo_gora_test_2np()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 0;
            int y = 2;
            int[,] z = new int[3, 3];
            z[1, 1] = 1;
            z[2, 0] = 1;
            test.sprawdz_lewo_gora(x, y, z);
            int ocz = 0;
            Assert.AreEqual(ocz, test.Lewo_gora);


        }
        [TestMethod]
        public void sprawdz_lewo_gora_test_1np_s()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 0;
            int y = 2;
            int[,] z = new int[3, 3];
            z[1, 1] = 2;
            
            test.sprawdz_lewo_gora(x, y, z);
            int ocz = 0;
            Assert.AreEqual(ocz, test.Lewo_gora);


        }

        [TestMethod]
        public void sprawdz_lewo_gora_test_1np_1p()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 0;
            int y = 2;
            int[,] z = new int[3, 3];
            z[1, 1] = 1;
            z[2, 0] = 0;
            test.sprawdz_lewo_gora(x, y, z);
            int ocz = 2;
            Assert.AreEqual(ocz, test.Lewo_gora);


        }
        [TestMethod]
        public void sprawdz_lewo_gora_test_1p()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 0;
            int y = 2;
            int[,] z = new int[3, 3];
            z[1, 1] = 0;
            
            test.sprawdz_lewo_gora(x, y, z);
            int ocz = 1;
            Assert.AreEqual(ocz, test.Lewo_gora);


        }
        [TestMethod]
        public void sprawdz_lewo_gora_test_lk()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 0;
            int y = 0;
            int[,] z = new int[3, 3];
            
            test.sprawdz_lewo_gora(x, y, z);
            int ocz = 0;
            Assert.AreEqual(ocz, test.Lewo_gora);


        }
        [TestMethod]
        public void sprawdz_lewo_gora_test_gk()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 7;
            int y = 1;
            int[,] z = new int[8, 3];

            test.sprawdz_lewo_gora(x, y, z);
            int ocz = 0;
            Assert.AreEqual(ocz, test.Lewo_gora);


        }

        [TestMethod]
        public void sprawdz_lewo_dol_test_2np()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 2;
            int y = 2;
            int[,] z = new int[3, 3];
            z[1, 1] = 1;
            z[0, 0] = 1;
            test.sprawdz_lewo_dol(x, y, z);
            int ocz = 0;
            Assert.AreEqual(ocz, test.Lewo_dol);


        }
        [TestMethod]
        public void sprawdz_lewo_dol_test_1np_s()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 2;
            int y = 2;
            int[,] z = new int[3, 3];
            z[1, 1] = 2;
            
            test.sprawdz_lewo_dol(x, y, z);
            int ocz = 0;
            Assert.AreEqual(ocz, test.Lewo_dol);


        }

        [TestMethod]
        public void sprawdz_lewo_dol_test_1np_1p()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 2;
            int y = 2;
            int[,] z = new int[3, 3];
            z[1, 1] = 1;
            z[0, 0] = 0;
            test.sprawdz_lewo_dol(x, y, z);
            int ocz = 2;
            Assert.AreEqual(ocz, test.Lewo_dol);


        }


        [TestMethod]
        public void sprawdz_lewo_dol_test_1p()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 2;
            int y = 2;
            int[,] z = new int[3, 3];
            z[1, 1] = 0;
            
            test.sprawdz_lewo_dol(x, y, z);
            int ocz = 1;
            Assert.AreEqual(ocz, test.Lewo_dol);


        }


        [TestMethod]
        public void sprawdz_lewo_dol_test_lk()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 2;
            int y = 0;
            int[,] z = new int[3, 3];
            
            test.sprawdz_lewo_dol(x, y, z);
            int ocz = 0;
            Assert.AreEqual(ocz, test.Lewo_dol);


        }


        [TestMethod]
        public void sprawdz_lewo_dol_test_dk()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 0;
            int y = 2;
            int[,] z = new int[3, 3];
            
            test.sprawdz_lewo_dol(x, y, z);
            int ocz = 0;
            Assert.AreEqual(ocz, test.Lewo_dol);


        }

        [TestMethod]
        public void sprawdz_prawo_gora_test_2np()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 0;
            int y = 0;
            int[,] z = new int[3, 3];
            z[1, 1] = 1;
            z[2, 2] = 1;     
            test.sprawdz_prawo_gora(x, y, z);
            int ocz = 0;
            Assert.AreEqual(ocz, test.Prawo_gora);
        }
        [TestMethod]
        public void sprawdz_prawo_gora_test_1np_s()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 0;
            int y = 0;
            int[,] z = new int[3, 3];
            z[1, 1] = 2;
            
            test.sprawdz_prawo_gora(x, y, z);
            int ocz = 0;
            Assert.AreEqual(ocz, test.Prawo_gora);
        }
        [TestMethod]
        public void sprawdz_prawo_gora_test_1np_1p()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 0;
            int y = 0;
            int[,] z = new int[3, 3];
            z[1, 1] = 1;
            z[2, 0] = 0;
            test.sprawdz_prawo_gora(x, y, z);
            int ocz = 2;
            Assert.AreEqual(ocz, test.Prawo_gora);
        }
        [TestMethod]
        public void sprawdz_prawo_gora_test_1p()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 0;
            int y = 0;
            int[,] z = new int[3, 3];
            z[1, 1] = 0;
            
            test.sprawdz_prawo_gora(x, y, z);
            int ocz = 1;
            Assert.AreEqual(ocz, test.Prawo_gora);
        }
        [TestMethod]
        public void sprawdz_prawo_gora_test_pk()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 1;
            int y = 7;
            int[,] z = new int[3, 8];
            
            test.sprawdz_prawo_gora(x, y, z);
            int ocz = 0;
            Assert.AreEqual(ocz, test.Prawo_gora);
        }
        [TestMethod]
        public void sprawdz_prawo_gora_test_gk()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 7;
            int y = 1;
            int[,] z = new int[8, 3];
            
            test.sprawdz_prawo_gora(x, y, z);
            int ocz = 0;
            Assert.AreEqual(ocz, test.Prawo_gora);
        }

        [TestMethod]
        public void sprwadz_prawo_dol_test_2np()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 2;
            int y = 0;
            int[,] z = new int[3, 3];
            z[1, 1] = 1;
            z[0, 2] = 1;
            test.sprawdz_prawo_dol(x, y, z);
            int ocz = 0;
            Assert.AreEqual(ocz, test.Prawo_dol);

        }
        [TestMethod]
        public void sprwadz_prawo_dol_test_1np_s()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 2;
            int y = 0;
            int[,] z = new int[3, 3];
            z[1, 1] = 2;
            
            test.sprawdz_prawo_dol(x, y, z);
            int ocz = 0;
            Assert.AreEqual(ocz, test.Prawo_dol);

        }

        [TestMethod]
        public void sprwadz_prawo_dol_test_1np_1p()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 2;
            int y = 0;
            int[,] z = new int[3, 3];
            z[1, 1] = 1;
            z[0, 2] = 0;
            test.sprawdz_prawo_dol(x, y, z);
            int ocz = 2;
            Assert.AreEqual(ocz, test.Prawo_dol);

        }

        [TestMethod]
        public void sprwadz_prawo_dol_test_1p()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 2;
            int y = 0;
            int[,] z = new int[3, 3];
            z[1, 1] = 0;
            
            test.sprawdz_prawo_dol(x, y, z);
            int ocz = 1;
            Assert.AreEqual(ocz, test.Prawo_dol);

        }

        [TestMethod]
        public void sprwadz_prawo_dol_test_pk()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 2;
            int y = 7;
            int[,] z = new int[3, 8];
            
            test.sprawdz_prawo_dol(x, y, z);
            int ocz = 0;
            Assert.AreEqual(ocz, test.Prawo_dol);

        }

        [TestMethod]
        public void sprwadz_prawo_dol_test_dk()
        {
            Metody test = new Metody();
            test.Obecny_gracz = 2;
            int x = 0;
            int y = 0;
            int[,] z = new int[3, 3];
            
            test.sprawdz_prawo_dol(x, y, z);
            int ocz = 0;
            Assert.AreEqual(ocz, test.Prawo_dol);

        }


        [TestMethod]
        public void zeroj_kier_test_lg()
        {
            Metody test = new Metody();
            test.Lewo_gora = 1;
            test.zeroj_kier();
            int ocz = 0;
            Assert.AreEqual(ocz, test.Lewo_gora);

        }

        [TestMethod]
        public void zeroj_kier_test_ld()
        {
            Metody test = new Metody();
            test.Lewo_dol = 1;
            test.zeroj_kier();
            int ocz = 0;
            Assert.AreEqual(ocz, test.Lewo_dol);

        }

        [TestMethod]
        public void zeroj_kier_test_pg()
        {
            Metody test = new Metody();
            test.Prawo_gora = 1;
            test.zeroj_kier();
            int ocz = 0;
            Assert.AreEqual(ocz, test.Prawo_gora);

        }

        [TestMethod]
        public void zeroj_kier_test_pd()
        {
            Metody test = new Metody();
            test.Prawo_dol = 1;
            test.zeroj_kier();
            int ocz = 0;
            Assert.AreEqual(ocz, test.Prawo_dol);

        }

    }
}
