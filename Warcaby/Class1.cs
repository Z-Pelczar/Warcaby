using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Warcaby
{
    /// <summary>
    /// Klasa <c>Metody</c> zawiera wartości oraz metody reprezentujące zmiany zachodzące w rogrywce.
    /// </summary>
    public class Metody
    {
        private int obecny_gracz;
        private int wartosc_x;
        private int wartosc_y;
        private int lewo_gora;
        private int lewo_dol;
        private int prawo_gora;
        private int prawo_dol;
        private int liczba_b_pionkow;
        private int liczba_cz_pionkow;
        private int liczba_b_dam;
        private int liczba_cz_dam;
        private int dawne_pionki;
        
        private int stan_tury;
        private int remis;
        private int pat;

        /// <value>
        /// Wartość <c>Pat</c> reprezentuje ilość możliwych ruchów do wykonania (używana jest do sprawdzenia czy zachodzi pat).
        /// </svalue>
        public int Pat
        {
            get
            {
                return pat;
            }
            set
            {
                pat = value;
            }
        }

        /// <value>
        /// Wartość <c>Remis</c> reprezentuje ilość ruchów bez zbicia żadnego pionka (używna jest do sprawdzenia czy zachodzi pat).
        /// </value>
        public int Remis
        {
            get
            {
                return remis;
            }
            set
            {
                remis = value;
            }
        }
        /// <value>
        /// Wartość <c>Obecny_gracz</c> wskazuje który gracz wykonuje swoją turę. Przyjmuje wartości: 1-gracz Biały, 2-gracz Czerwony.
        /// </value>
        public int Obecny_gracz
        {
            get
            {
                return obecny_gracz;
            }
            set
            {
                obecny_gracz = value;
            }
        }

        /// <value>
        /// Wartość <c>Wartosc_x</c> reprezuntuje współrzędną x. Przyjmuje wartości 0-7.
        /// </value>
        public int Wartosc_x
        {
            get
            {
                return wartosc_x;
            }
            set
            {
                wartosc_x = value;
            }
        }

        /// <value>
        /// Wartość <c>Wartosc_y</c> reprezentuje współrzędną y. Przyjmue wartości 0-7.
        /// </value>
        public int Wartosc_y
        {
            get
            {
                return wartosc_y;
            }
            set
            {
                wartosc_y = value;
            }
        }

        /// <value>
        /// Wartość <c>Lewo_gora</c> reprezentuje polę znajdujące się na górzę, po lewej od obecnego. Przyjmuje wartości: 0-pole jest niedostępne, 1-pole jest puste, 2-na polu znajduje się pionek przeciwnika możliwy do zbicia.
        /// </value>
        public int Lewo_gora
        {
            get
            {
                return lewo_gora;
            }
            set
            {
                lewo_gora = value;
            }
        }
        /// <value>
        /// Wartość <c>Lewo_dol</c> reprezentuje polę znajdujące się na dole, po lewej od obecnego. Przyjmuje wartości: 0-pole jest niedostępne, 1-pole jest puste, 2-na polu znajduje się pionek przeciwnika możliwy do zbicia.
        /// </value>
        public int Lewo_dol
        {
            get
            {
                return lewo_dol;
            }
            set
            {
                lewo_dol = value;
            }
        }
        /// <value>
        /// Wartość <c>Prawo_gora</c> reprezentuje polę znajdujące się na górzę, po prawej od obecnego. Przyjmuje wartości: 0-pole jest niedostępne, 1-pole jest puste, 2-na polu znajduje się pionek przeciwnika możliwy do zbicia.
        /// </value>
        public int Prawo_gora
        {
            get
            {
                return prawo_gora;
            }
            set
            {
                prawo_gora = value;
            }
        }
        /// <value>
        /// Wartość <c>Prawo_dol</c> reprezentuje polę znajdujące się na dole, po prawej od obecnego. Przyjmuje wartości: 0-pole jest niedostępne, 1-pole jest puste, 2-na polu znajduje się pionek przeciwnika możliwy do zbicia.
        /// </value>
        public int Prawo_dol
        {
            get
            {
                return prawo_dol;
            }
            set
            {
                prawo_dol = value;
            }
        }
        /// <value>
        /// Wartość <c>Liczba_b_pion</c> reprezentuje liczbę białych pionków.
        /// </value>
        public int Liczba_b_pion
        {
            get
            {
                return liczba_b_pionkow;
            }
            set
            {
                liczba_b_pionkow = value;
            }
        }
        /// <value>
        /// Wartość <c>Liczba_cz_pion</c> reprezentuje liczbę czerwonych pionków.
        /// </value>
        public int Liczba_cz_pion
        {
            get
            {
                return liczba_cz_pionkow;
            }
            set
            {
                liczba_cz_pionkow = value;
            }
        }
        /// <value>
        /// Wartość <c>Liczba_b_dam</c> reprezentuje liczbę białych damek. 
        /// </value>
        public int Liczba_b_dam
        {
            get
            {
                return liczba_b_dam;
            }
            set
            {
                liczba_b_dam = value;
            }
        }

        /// <value>
        /// Wartość <c>Liczba_cz_dam</c> reprezentuje liczbę czerwonych damek. 
        /// </value>
        public int Liczba_cz_dam
        {
            get
            {
                return liczba_cz_dam;
            }
            set
            {
                liczba_cz_dam = value;
            }
        }

        /// <value>
        /// Wartość <c>Dawne_pionki</c> reprezentuje liczbę wszystkich pionków (łącznie z damkami) w poprzedniej turze.
        /// </value>
        public int Dawne_pionki
        {
            get
            {
                return dawne_pionki;
            }
            set
            {
                dawne_pionki = value;
            }
        }


        /// <value>
        /// Wartość <c>Stan_tury</c> reprezentuje obecny stan tury. Przyjmuje wartości: 0-tura się rozpoczyna, 1-gracz wybrał pionek, 2-gracz zbił pionek przeciwnika i może zbić kolejny, 3-gracz poruszył się damką i może wykonać nią kolejny ruch, 4-gracz wykonał wszystkie możliwe ruchy, 5-gra zostaje zakończona. 
        /// </value>
        public int Stan_tury
        {
            get
            {
                return stan_tury;
            }
            set
            {
                stan_tury = value;
            }
        }
        /// <summary>
        /// Metoda <c>wyswietl_pion</c> wyświetla w polu tekstowym obecnie wybrany pionek/damkę.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Wartość elementu o współrzędnych (x,y)</param>
        /// <param name="b">Obecny gracz</param>
        /// <param name="a">Pole tekstowe w którym ma się wyświetlić wiadomość</param>
        public void wyswietl_pion(int x, int y, int z,int b, System.Windows.Controls.TextBox a)
        {
            if (z == b)
            {
                a.Text = "Wybrano pionek na polu: " + x + "," + y + ".";
            }
            else
            {
                a.Text = "Wybrano damkę na polu: " + x + "," + y + ".";
            }
        }













        /// <summary>
        /// Metoda<c>zwroc_wartosc</c> zwraca wartosc elementu macierzy.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <returns>Wartość elementu (x,y) w macierzy z</returns>
        public int zwroc_wartosc(int x, int y, int[,] z)
            {
            return z[x, y];
            }
        /// <summary>
        /// Metoda <c>zmien_wartosc</c> zmienia wartość elementu (x,y) w macierzy z.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Wartość która ma zostać przyjęta</param>
        public void zmien_wartosc(int x, int y, int[,] z,int a)
        {
            z[x, y] = a;
        }

        /// <summary>
        /// Metoda <c>zmien_obraz</c> zmienia wyswietlany obraz w zależności od wartości.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="a">Warotść w zależności od której zmienia się obraz (wartość elementu (x,y) w macierzy.</param>
        /// <param name="z">Macierz obrazów reprezentująca graficzne przedstawienie pola i pionków</param>
        public void zmien_obraz(int x, int y,int a, System.Windows.Controls.Image[,] z)
        {
            if(a==0)
            {
                z[x, y].Source = new BitmapImage(new Uri("images/czarne_pole.png", UriKind.RelativeOrAbsolute));
            }
            else if(a==1)
            {
                z[x, y].Source = new BitmapImage(new Uri("images/biały_pionek.png", UriKind.RelativeOrAbsolute));
            }
            else if(a==2)
            {
                z[x, y].Source = new BitmapImage(new Uri("images/czerwony_pionek.png", UriKind.RelativeOrAbsolute));
            }
            else if(a==3)
            {
                z[x,y].Source = new BitmapImage(new Uri("images/biała_damka.png", UriKind.RelativeOrAbsolute));
            }
            else if(a==4)
            {
                z[x,y].Source = new BitmapImage(new Uri("images/czerwona_damka.png", UriKind.RelativeOrAbsolute));
            }

        }
        /// <summary>
        /// Metoda <c>sprawdz_lewo_gora</c> sprawdza pole znajdujęce się na górze, po lewej od wybrangeo pola oraz zmienia wartość <c>lewo_gora</c>.
        /// </summary>
        /// <param name="x">Współrzędna x wybranego pola</param>
        /// <param name="y">Współrzędna y wybranego pola</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        public void sprawdz_lewo_gora(int x, int y, int[,] z)
        {
            if (x == 7)
            {
                lewo_gora = 0;
            }
            else if (y == 0)
            {
                lewo_gora = 0;
            }
            else
            {
                if (zwroc_wartosc(x + 1, y - 1, z) == 0)
                {
                     lewo_gora = 1;
                }
                else if ((zwroc_wartosc(x + 1, y - 1, z) == obecny_gracz) || (zwroc_wartosc(x + 1, y - 1, z) == obecny_gracz + 2))
                {
                    lewo_gora = 0;
                }
                else
                {
                    if (x == 6)
                    {
                        lewo_gora = 0;
                    }
                    else if(y == 1)
                    {
                        lewo_gora = 0;
                    }
                    else if(zwroc_wartosc(x + 2, y - 2, z) == 0)
                    {
                        lewo_gora = 2;
                    }
                    else
                    {
                        lewo_gora = 0;
                    }
                }
            }
        }
        /// <summary>
        ///  Metoda <c>sprawdz_lewo_dol</c> sprawdza pole znajdujęce się na dole, po lewej od wybrangeo pola oraz zmienia wartość <c>lewo_dol</c>.
        /// </summary>
        /// <param name="x">Współrzędna x wybranego pola</param>
        /// <param name="y">Współrzędna y wybranego pola</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        public void sprawdz_lewo_dol(int x, int y, int[,] z)
        {
            if (x == 0)
            {
                lewo_dol = 0; 
            }
            else if (y == 0)
            {
                lewo_dol = 0;
            }
            else
            {
                if (zwroc_wartosc(x - 1, y - 1, z) == 0)
                {
                    lewo_dol = 1;
                }
                else if ((zwroc_wartosc(x - 1, y - 1, z) == obecny_gracz) || (zwroc_wartosc(x - 1, y - 1, z) == obecny_gracz + 2))
                {
                    lewo_dol = 0;
                }
                else
                {
                    if (x == 1)
                    {
                        lewo_dol = 0;
                    }
                    else if (y == 1)
                    {
                        lewo_dol = 0;
                    }
                    else if (zwroc_wartosc(x - 2, y - 2, z) == 0)
                    {
                        lewo_dol = 2;
                    }
                    else
                    {
                        lewo_dol = 0;
                    }
                }
            }
        }
        /// <summary>
        ///  Metoda <c>sprawdz_prawo_gora</c> sprawdza pole znajdujęce się na górze, po prawej od wybrangeo pola oraz zmienia wartość <c>prawo_gora</c>.
        /// </summary>
        /// <param name="x">Współrzędna x wybranego pola</param>
        /// <param name="y">Współrzędna y wybranego pola</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        public void sprawdz_prawo_gora(int x, int y, int[,] z)
        {
            if (x == 7)
            {
                prawo_gora = 0;
            }
            else if (y == 7)
            {
                prawo_gora = 0;
            }
            else
            {
                if (zwroc_wartosc(x + 1, y + 1, z) == 0)
                {
                    prawo_gora = 1;
                }
                else if ((zwroc_wartosc(x + 1, y + 1, z) == obecny_gracz) || (zwroc_wartosc(x + 1, y + 1, z) == obecny_gracz + 2))
                {
                    prawo_gora = 0;
                }
                else
                {
                    if (x == 6)
                    {
                        prawo_gora = 0;
                    }
                    else if (y == 6)
                    {
                        prawo_gora = 0;
                    }
                    else if (zwroc_wartosc(x + 2, y + 2, z) == 0)
                    {
                        prawo_gora = 2;
                    }
                    else
                    {
                        prawo_gora = 0;
                    }
                }
            }
        }
        /// <summary>
        ///  Metoda <c>sprawdz_prawo_dol</c> sprawdza pole znajdujęce się na dole, po prawej od wybrangeo pola oraz zmienia wartość <c>prawo_dol</c>.
        /// </summary>
        /// <param name="x">Współrzędna x wybranego pola</param>
        /// <param name="y">Współrzędna y wybranego pola</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        public void sprawdz_prawo_dol(int x, int y, int[,] z)
        {
            if (x == 0)
            {
                prawo_dol = 0;
            }
            else if (y == 7)
            {
                prawo_dol = 0;
            }
            else
            {
                if (zwroc_wartosc(x - 1, y + 1, z) == 0)
                {
                    prawo_dol = 1;
                }
                else if ((zwroc_wartosc(x - 1, y + 1, z) == obecny_gracz) || (zwroc_wartosc(x - 1, y + 1, z) == obecny_gracz + 2))
                {
                    prawo_dol = 0;
                }
                else
                {
                    if (x == 1)
                    {
                        prawo_dol = 0;
                    }
                    else if (y == 6)
                    {
                        prawo_dol = 0;
                    }
                    else if (zwroc_wartosc(x - 2, y + 2, z) == 0)
                    {
                        prawo_dol = 2;
                    }
                    else
                    {
                        prawo_dol = 0;
                    }
                }
            }
        }
        /// <summary>
        /// Metoda <c>zeroj_kier</c> zmienia wartości <c>prawo_dol</c>, <c>prawo_gora</c>, <c>lewo_dol</c>, <c>lewo_gora</c> na 0.
        /// </summary>
        public void zeroj_kier()
        {
            prawo_dol = 0;
            prawo_gora = 0;
            lewo_dol = 0;
            lewo_gora = 0;
        }

        /// <summary>
        /// Metoda <c>idz_lewo_gora_pion_pusty</c> odpowiada za przesunięcie pionka na górne pole, po lewej.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Macierz obrazów reprezentująca graficznie pole i pionki</param>
        public void idz_lewo_gora_pion_pusty(int x, int y, int[,] z, System.Windows.Controls.Image[,] a)
        {
            z[x + 1, y - 1] = zwroc_wartosc(x, y, z);
            z[x, y] = 0;
            zmien_obraz(x, y,zwroc_wartosc(x,y,z), a);
            zmien_obraz(x + 1, y - 1, zwroc_wartosc(x + 1, y - 1, z), a);

            
        }
        /// <summary>
        /// Metoda <c>bij_lewo_gora_pion</c> odpowiada za zbicie pionka (damki) znajdującego się na górnym polu, po lewej, za pomocą pionka.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Macierz obrazów reprezentująca graficznie pole i pionki</param>
        public void bij_lewo_gora_pion(int x, int y, int[,] z, System.Windows.Controls.Image[,] a)
        {
            z[x + 2, y - 2] = zwroc_wartosc(x, y, z);
            z[x, y] = 0;
            
            if(obecny_gracz==1)
            {
                if (zwroc_wartosc(x + 1, y - 1, z) == 2)
                {
                    liczba_cz_pionkow = liczba_cz_pionkow - 1;
                }
                else
                {
                    liczba_cz_dam = liczba_cz_dam - 1;
                }
            }
            else
            {
                if (zwroc_wartosc(x + 1, y - 1, z) == 1)
                {
                    liczba_b_pionkow = liczba_b_pionkow - 1;
                }
                else
                {
                    liczba_b_dam = liczba_b_dam - 1;
                }
            }
            z[x + 1, y - 1] = 0;
            zmien_obraz(x, y, zwroc_wartosc(x, y, z), a);
            zmien_obraz(x+1, y-1, zwroc_wartosc(x+1, y-1, z), a);
            zmien_obraz(x+2, y-2, zwroc_wartosc(x+2, y-2, z), a);
            zeroj_kier();
            wartosc_x = x + 2;
            wartosc_y = y - 2;
            sprawdz_lewo_dol(wartosc_x, wartosc_y, z);
            sprawdz_lewo_gora(wartosc_x, wartosc_y, z);
            sprawdz_prawo_dol(wartosc_x, wartosc_y, z);
            sprawdz_prawo_gora(wartosc_x, wartosc_y, z);
            if(lewo_dol==2 | lewo_gora==2 | prawo_gora==2 | prawo_dol==2)
            {
                stan_tury = 2;
            }
            else
            {
                stan_tury = 4;
                zeroj_kier();
            }

        }
        /// <summary>
        /// Metoda <c>idz_prawo_gora_pion_pusty</c> odpowiada za przesunięcie pionka na górne pole, po prawej.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Macierz obrazów reprezentująca graficznie pole i pionki</param>
        public void idz_prawo_gora_pion_pusty(int x, int y, int[,] z, System.Windows.Controls.Image[,] a)
        {
            z[x + 1, y + 1] = zwroc_wartosc(x, y, z);
            z[x, y] = 0;
            zmien_obraz(x, y, zwroc_wartosc(x, y, z), a);
            zmien_obraz(x + 1, y + 1, zwroc_wartosc(x + 1, y + 1, z), a);


        }
        /// <summary>
        /// Metoda <c>bij_prawo_gora_pion</c> odpowiada za zbicie pionka (damki) znajdującego się na górnym polu, po prawej, za pomocą pionka.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Macierz obrazów reprezentująca graficznie pole i pionki</param>
        public void bij_prawo_gora_pion(int x, int y, int[,] z, System.Windows.Controls.Image[,] a)
        {
            z[x + 2, y + 2] = zwroc_wartosc(x, y, z);
            z[x, y] = 0;

            if (obecny_gracz == 1)
            {
                if (zwroc_wartosc(x + 1, y + 1, z) == 2)
                {
                    liczba_cz_pionkow = liczba_cz_pionkow - 1;
                }
                else
                {
                    liczba_cz_dam = liczba_cz_dam - 1;
                }
            }
            else
            {
                if (zwroc_wartosc(x + 1, y + 1, z) == 1)
                {
                    liczba_b_pionkow = liczba_b_pionkow - 1;
                }
                else
                {
                    liczba_b_dam = liczba_b_dam - 1;
                }
            }
            z[x + 1, y + 1] = 0;
            zmien_obraz(x, y, zwroc_wartosc(x, y, z), a);
            zmien_obraz(x + 1, y + 1, zwroc_wartosc(x + 1, y + 1, z), a);
            zmien_obraz(x + 2, y + 2, zwroc_wartosc(x + 2, y + 2, z), a);
            zeroj_kier();
            wartosc_x = x + 2;
            wartosc_y = y + 2;
            sprawdz_lewo_dol(wartosc_x, wartosc_y, z);
            sprawdz_lewo_gora(wartosc_x, wartosc_y, z);
            sprawdz_prawo_dol(wartosc_x, wartosc_y, z);
            sprawdz_prawo_gora(wartosc_x, wartosc_y, z);
            if (lewo_dol == 2 | lewo_gora == 2 | prawo_gora == 2 | prawo_dol == 2)
            {
                stan_tury = 2;
            }
            else
            {
                stan_tury = 4;
                zeroj_kier();
            }

        }
        /// <summary>
        /// Metoda <c>idz_lewo_dol_pion_pusty</c> odpowiada za przesunięcie pionka na dolne pole, po lewej.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Macierz obrazów reprezentująca graficznie pole i pionki</param>
        public void idz_lewo_dol_pion_pusty(int x, int y, int[,] z, System.Windows.Controls.Image[,] a)
        {
            z[x - 1, y - 1] = zwroc_wartosc(x, y, z);
            z[x, y] = 0;
            zmien_obraz(x, y, zwroc_wartosc(x, y, z), a);
            zmien_obraz(x - 1, y - 1, zwroc_wartosc(x - 1, y - 1, z), a);


        }
        /// <summary>
        /// Metoda <c>bij_lewo_dol_pion</c> odpowiada za zbicie pionka (damki) znajdującego się na dolnym polu, po lewej, za pomocą pionka.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Macierz obrazów reprezentująca graficznie pole i pionki</param>
        public void bij_lewo_dol_pion(int x, int y, int[,] z, System.Windows.Controls.Image[,] a)
        {
            z[x - 2, y - 2] = zwroc_wartosc(x, y, z);
            z[x, y] = 0;

            if (obecny_gracz == 1)
            {
                if (zwroc_wartosc(x - 1, y - 1, z) == 2)
                {
                    liczba_cz_pionkow = liczba_cz_pionkow - 1;
                }
                else
                {
                    liczba_cz_dam = liczba_cz_dam - 1;
                }
            }
            else
            {
                if (zwroc_wartosc(x - 1, y - 1, z) == 1)
                {
                    liczba_b_pionkow = liczba_b_pionkow - 1;
                }
                else
                {
                    liczba_b_dam = liczba_b_dam - 1;
                }
            }
            z[x - 1, y - 1] = 0;
            zmien_obraz(x, y, zwroc_wartosc(x, y, z), a);
            zmien_obraz(x - 1, y - 1, zwroc_wartosc(x - 1, y - 1, z), a);
            zmien_obraz(x - 2, y - 2, zwroc_wartosc(x - 2, y - 2, z), a);
            zeroj_kier();
            wartosc_x = x - 2;
            wartosc_y = y - 2;
            sprawdz_lewo_dol(wartosc_x, wartosc_y, z);
            sprawdz_lewo_gora(wartosc_x, wartosc_y, z);
            sprawdz_prawo_dol(wartosc_x, wartosc_y, z);
            sprawdz_prawo_gora(wartosc_x, wartosc_y, z);
            if (lewo_dol == 2 | lewo_gora == 2 | prawo_gora == 2 | prawo_dol == 2)
            {
                stan_tury = 2;
            }
            else
            {
                stan_tury = 4;
                zeroj_kier();
            }

        }
        /// <summary>
        /// Metoda <c>idz_prawo_dol_pion_pusty</c> odpowiada za przesunięcie pionka na dolne pole, po prawej.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Macierz obrazów reprezentująca graficznie pole i pionki</param>
        public void idz_prawo_dol_pion_pusty(int x, int y, int[,] z, System.Windows.Controls.Image[,] a)
        {
            z[x - 1, y + 1] = zwroc_wartosc(x, y, z);
            z[x, y] = 0;
            zmien_obraz(x, y, zwroc_wartosc(x, y, z), a);
            zmien_obraz(x - 1, y + 1, zwroc_wartosc(x - 1, y + 1, z), a);


        }
        /// <summary>
        /// Metoda <c>bij_prawo_dol_pion</c> odpowiada za zbicie pionka (damki) znajdującego się na dolnym polu, po prawej, za pomocą pionka.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Macierz obrazów reprezentująca graficznie pole i pionki</param>
        public void bij_prawo_dol_pion(int x, int y, int[,] z, System.Windows.Controls.Image[,] a)
        {
            z[x - 2, y + 2] = zwroc_wartosc(x, y, z);
            z[x, y] = 0;

            if (obecny_gracz == 1)
            {
                if (zwroc_wartosc(x - 1, y + 1, z) == 2)
                {
                    liczba_cz_pionkow = liczba_cz_pionkow - 1;
                }
                else
                {
                    liczba_cz_dam = liczba_cz_dam - 1;
                }
            }
            else
            {
                if (zwroc_wartosc(x - 1, y + 1, z) == 1)
                {
                    liczba_b_pionkow = liczba_b_pionkow - 1;
                }
                else
                {
                    liczba_b_dam = liczba_b_dam - 1;
                }
            }
            z[x - 1, y + 1] = 0;
            zmien_obraz(x, y, zwroc_wartosc(x, y, z), a);
            zmien_obraz(x - 1, y + 1, zwroc_wartosc(x - 1, y + 1, z), a);
            zmien_obraz(x - 2, y + 2, zwroc_wartosc(x - 2, y + 2, z), a);
            zeroj_kier();
            wartosc_x = x - 2;
            wartosc_y = y + 2;
            sprawdz_lewo_dol(wartosc_x, wartosc_y, z);
            sprawdz_lewo_gora(wartosc_x, wartosc_y, z);
            sprawdz_prawo_dol(wartosc_x, wartosc_y, z);
            sprawdz_prawo_gora(wartosc_x, wartosc_y, z);
            if (lewo_dol == 2 | lewo_gora == 2 | prawo_gora == 2 | prawo_dol == 2)
            {
                stan_tury = 2;
            }
            else
            {
                stan_tury = 4;
                zeroj_kier();
            }

        }
        /// <summary>
        /// Metoda <c>idz_lewo_gora_dama_puste</c> odpowiada za przemieszczenie damki na górne pole, po lewej.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Macierz obrazów reprezentująca graficznie pole i pionki</param>
        public void idz_lewo_gora_dama_puste(int x, int y, int[,] z, System.Windows.Controls.Image[,] a)
        {
            z[x + 1, y - 1] = zwroc_wartosc(x, y, z);
            z[x, y] = 0;
            zmien_obraz(x, y, zwroc_wartosc(x, y, z), a);
            zmien_obraz(x + 1, y - 1, zwroc_wartosc(x + 1, y - 1, z), a);
            zeroj_kier();
            wartosc_x = x + 1;
            wartosc_y = y - 1;

            sprawdz_lewo_gora(Wartosc_x, wartosc_y, z);
            if (lewo_gora == 0)
            {
                stan_tury = 4;
                zeroj_kier();
            }
            else if (lewo_gora==1)
            {
                stan_tury = 3;
            }
            else if (lewo_gora==2)
            {
                stan_tury = 2;
            }

        }
        /// <summary>
        /// Metoda<c>bij_lewo_gora_dama</c> odpowiada za zbicie pionka (damki) znajdującego sie na górnym polu, po lewej, za pomocą damki.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Macierz obrazów reprezentująca graficznie pole i pionki</param>
        public void bij_lewo_gora_dama(int x, int y, int[,] z, System.Windows.Controls.Image[,] a)
        {
            z[x + 2, y - 2] = zwroc_wartosc(x, y, z);
            z[x, y] = 0;
            z[x + 1, y - 1] = 0;
            if (obecny_gracz == 1)
            {
                if (zwroc_wartosc(x + 1, y - 1, z) == 2)
                {
                    liczba_cz_pionkow = liczba_cz_pionkow - 1;
                }
                else
                {
                    liczba_cz_dam = liczba_cz_dam - 1;
                }
            }
            else
            {
                if (zwroc_wartosc(x + 1, y - 1, z) == 1)
                {
                    liczba_b_pionkow = liczba_b_pionkow - 1;
                }
                else
                {
                    liczba_b_dam = liczba_b_dam - 1;
                }
            }
            zmien_obraz(x, y, zwroc_wartosc(x, y, z), a);
            zmien_obraz(x + 1, y - 1, zwroc_wartosc(x + 1, y - 1, z), a);
            zmien_obraz(x + 2, y - 2, zwroc_wartosc(x + 2, y - 2, z), a);
            zeroj_kier();
            wartosc_x = x + 2;
            wartosc_y = y - 2;
            sprawdz_lewo_dol(wartosc_x, wartosc_y, z);
            sprawdz_lewo_gora(wartosc_x, wartosc_y, z);
            sprawdz_prawo_gora(wartosc_x, wartosc_y, z);
            sprawdz_prawo_dol(wartosc_x, wartosc_y, z);
            if (lewo_dol == 2 | lewo_gora == 2 | prawo_gora == 2 | prawo_dol == 2)
            {
                stan_tury = 2;
            }
            else if(lewo_gora==1)
            {
                stan_tury = 3;
                zeroj_kier();
                sprawdz_lewo_gora(wartosc_x, wartosc_y, z);
            }
            else if (lewo_gora == 0)
            {
                zeroj_kier();
                stan_tury = 4;
                
            }


        }
        /// <summary>
        /// Metoda <c>idz_lewo_dol_dama_puste</c> odpowiada za przemieszczenie damki na dolne pole, po lewej.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Macierz obrazów reprezentująca graficznie pole i pionki</param>
        public void idz_lewo_dol_dama_puste(int x, int y, int[,] z, System.Windows.Controls.Image[,] a)
        {
            z[x - 1, y - 1] = zwroc_wartosc(x, y, z);
            z[x, y] = 0;
            zmien_obraz(x, y, zwroc_wartosc(x, y, z), a);
            zmien_obraz(x - 1, y - 1, zwroc_wartosc(x - 1, y - 1, z), a);
            zeroj_kier();
            wartosc_x = x - 1;
            wartosc_y = y - 1;

            sprawdz_lewo_dol(Wartosc_x, wartosc_y, z);
            if (lewo_dol == 0)
            {
                stan_tury = 4;
                zeroj_kier();
            }
            else if (lewo_dol == 1)
            {
                stan_tury = 3;
            }
            else if (lewo_dol == 2)
            {
                stan_tury = 2;
            }

        }
        /// <summary>
        /// Metoda<c>bij_lewo_dol_dama</c> odpowiada za zbicie pionka (damki) znajdującego sie na dolnym polu, po lewej, za pomocą damki.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Macierz obrazów reprezentująca graficznie pole i pionki</param>
        public void bij_lewo_dol_dama(int x, int y, int[,] z, System.Windows.Controls.Image[,] a)
        {
            z[x - 2, y - 2] = zwroc_wartosc(x, y, z);
            z[x, y] = 0;
            z[x - 1, y - 1] = 0;
            if (obecny_gracz == 1)
            {
                if (zwroc_wartosc(x - 1, y - 1, z) == 2)
                {
                    liczba_cz_pionkow = liczba_cz_pionkow - 1;
                }
                else
                {
                    liczba_cz_dam = liczba_cz_dam - 1;
                }
            }
            else
            {
                if (zwroc_wartosc(x - 1, y - 1, z) == 1)
                {
                    liczba_b_pionkow = liczba_b_pionkow - 1;
                }
                else
                {
                    liczba_b_dam = liczba_b_dam - 1;
                }
            }
            zmien_obraz(x, y, zwroc_wartosc(x, y, z), a);
            zmien_obraz(x - 1, y - 1, zwroc_wartosc(x - 1, y - 1, z), a);
            zmien_obraz(x - 2, y - 2, zwroc_wartosc(x - 2, y - 2, z), a);
            zeroj_kier();
            wartosc_x = x - 2;
            wartosc_y = y - 2;
            sprawdz_lewo_dol(wartosc_x, wartosc_y, z);
            sprawdz_lewo_gora(wartosc_x, wartosc_y, z);
            sprawdz_prawo_gora(wartosc_x, wartosc_y, z);
            sprawdz_prawo_dol(wartosc_x, wartosc_y, z);
            if (lewo_dol == 2 | lewo_gora == 2 | prawo_gora == 2 | prawo_dol == 2)
            {
                stan_tury = 2;
            }
            else if (lewo_dol == 1)
            {
                stan_tury = 3;
                zeroj_kier();
                sprawdz_lewo_dol(wartosc_x, wartosc_y, z);
            }
            else if (lewo_dol == 0)
            {
                zeroj_kier();
                stan_tury = 4;

            }


        }
        /// <summary>
        /// Metoda <c>idz_prawo_gora_dama_puste</c> odpowiada za przemieszczenie damki na górne pole, po prawej.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Macierz obrazów reprezentująca graficznie pole i pionki</param>
        public void idz_prawo_gora_dama_puste(int x, int y, int[,] z, System.Windows.Controls.Image[,] a)
        {
            z[x + 1, y + 1] = zwroc_wartosc(x, y, z);
            z[x, y] = 0;
            zmien_obraz(x, y, zwroc_wartosc(x, y, z), a);
            zmien_obraz(x + 1, y + 1, zwroc_wartosc(x + 1, y + 1, z), a);
            zeroj_kier();
            wartosc_x = x + 1;
            wartosc_y = y + 1;

            sprawdz_prawo_gora(Wartosc_x, wartosc_y, z);
            if (prawo_gora == 0)
            {
                stan_tury = 4;
                zeroj_kier();
            }
            else if (prawo_gora == 1)
            {
                stan_tury = 3;
            }
            else if (prawo_gora == 2)
            {
                stan_tury = 2;
            }

        }
        /// <summary>
        /// Metoda<c>bij_prawo_gora_dama</c> odpowiada za zbicie pionka (damki) znajdującego sie na górnym polu, po prawej, za pomocą damki.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Macierz obrazów reprezentująca graficznie pole i pionki</param>
        public void bij_prawo_gora_dama(int x, int y, int[,] z, System.Windows.Controls.Image[,] a)
        {
            z[x + 2, y + 2] = zwroc_wartosc(x, y, z);
            z[x, y] = 0;
            z[x + 1, y + 1] = 0;
            if (obecny_gracz == 1)
            {
                if (zwroc_wartosc(x + 1, y + 1, z) == 2)
                {
                    liczba_cz_pionkow = liczba_cz_pionkow - 1;
                }
                else
                {
                    liczba_cz_dam = liczba_cz_dam - 1;
                }
            }
            else
            {
                if (zwroc_wartosc(x + 1, y + 1, z) == 1)
                {
                    liczba_b_pionkow = liczba_b_pionkow - 1;
                }
                else
                {
                    liczba_b_dam = liczba_b_dam - 1;
                }
            }
            zmien_obraz(x, y, zwroc_wartosc(x, y, z), a);
            zmien_obraz(x + 1, y + 1, zwroc_wartosc(x + 1, y + 1, z), a);
            zmien_obraz(x + 2, y + 2, zwroc_wartosc(x + 2, y + 2, z), a);
            zeroj_kier();
            wartosc_x = x + 2;
            wartosc_y = y + 2;
            sprawdz_lewo_dol(wartosc_x, wartosc_y, z);
            sprawdz_lewo_gora(wartosc_x, wartosc_y, z);
            sprawdz_prawo_gora(wartosc_x, wartosc_y, z);
            sprawdz_prawo_dol(wartosc_x, wartosc_y, z);
            if (lewo_dol == 2 | lewo_gora == 2 | prawo_gora == 2 | prawo_dol == 2)
            {
                stan_tury = 2;
            }
            else if (prawo_gora == 1)
            {
                stan_tury = 3;
                zeroj_kier();
                sprawdz_prawo_gora(wartosc_x, wartosc_y, z);
            }
            else if (prawo_gora == 0)
            {
                zeroj_kier();
                stan_tury = 4;

            }


        }
        /// <summary>
        /// Metoda <c>idz_prawo_dol_dama_puste</c> odpowiada za przemieszczenie damki na dolne pole, po prawej.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Macierz obrazów reprezentująca graficznie pole i pionki</param>
        public void idz_prawo_dol_dama_puste(int x, int y, int[,] z, System.Windows.Controls.Image[,] a)
        {
            z[x - 1, y + 1] = zwroc_wartosc(x, y, z);
            z[x, y] = 0;
            zmien_obraz(x, y, zwroc_wartosc(x, y, z), a);
            zmien_obraz(x - 1, y + 1, zwroc_wartosc(x - 1, y + 1, z), a);
            zeroj_kier();
            wartosc_x = x - 1;
            wartosc_y = y + 1;

            sprawdz_prawo_dol(Wartosc_x, wartosc_y, z);
            if (prawo_dol == 0)
            {
                stan_tury = 4;
                zeroj_kier();
            }
            else if (prawo_dol == 1)
            {
                stan_tury = 3;
            }
            else if (prawo_dol == 2)
            {
                stan_tury = 2;
            }

        }
        /// <summary>
        /// Metoda<c>bij_prawo_dol_dama</c> odpowiada za zbicie pionka (damki) znajdującego sie na dolnym polu, po prawej, za pomocą damki.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Macierz obrazów reprezentująca graficznie pole i pionki</param>
        public void bij_prawo_dol_dama(int x, int y, int[,] z, System.Windows.Controls.Image[,] a)
        {
            z[x - 2, y + 2] = zwroc_wartosc(x, y, z);
            z[x, y] = 0;
            z[x - 1, y + 1] = 0;
            if (obecny_gracz == 1)
            {
                if (zwroc_wartosc(x - 1, y + 1, z) == 2)
                {
                    liczba_cz_pionkow = liczba_cz_pionkow - 1;
                }
                else
                {
                    liczba_cz_dam = liczba_cz_dam - 1;
                }
            }
            else
            {
                if (zwroc_wartosc(x - 1, y + 1, z) == 1)
                {
                    liczba_b_pionkow = liczba_b_pionkow - 1;
                }
                else
                {
                    liczba_b_dam = liczba_b_dam - 1;
                }
            }
            zmien_obraz(x, y, zwroc_wartosc(x, y, z), a);
            zmien_obraz(x - 1, y + 1, zwroc_wartosc(x - 1, y + 1, z), a);
            zmien_obraz(x - 2, y + 2, zwroc_wartosc(x - 2, y + 2, z), a);
            zeroj_kier();
            wartosc_x = x - 2;
            wartosc_y = y + 2;
            sprawdz_lewo_dol(wartosc_x, wartosc_y, z);
            sprawdz_lewo_gora(wartosc_x, wartosc_y, z);
            sprawdz_prawo_gora(wartosc_x, wartosc_y, z);
            sprawdz_prawo_dol(wartosc_x, wartosc_y, z);
            if (lewo_dol == 2 | lewo_gora == 2 | prawo_gora == 2 | prawo_dol == 2)
            {
                stan_tury = 2;
            }
            else if (prawo_dol == 1)
            {
                stan_tury = 3;
                zeroj_kier();
                sprawdz_prawo_dol(wartosc_x, wartosc_y, z);
            }
            else if (prawo_dol == 0)
            {
                zeroj_kier();
                stan_tury = 4;

            }
        }
        /// <summary>
        /// Metoda <c>zmiana_damka</c> odpowiada za zmianę pionka na damkę.
        /// </summary>
        /// <param name="x">Współrzędna x</param>
        /// <param name="y">Współrzędna y</param>
        /// <param name="z">Macierz reprezentująca matematycznie pole i pionki</param>
        /// <param name="a">Macierz obrazów reprezentująca graficznie pole i pionki</param>
        public void zmiana_damka(int x, int y, int[,] z, System.Windows.Controls.Image[,] a)
        {
            if (z[x, y] == 1)
            {
                z[x, y] = 3;
            }
            else if (z[x, y] == 2)
            {
                z[x, y] = 4;
            }
            zmien_obraz(x, y, z[x, y], a);
        }

        
    }   
}
