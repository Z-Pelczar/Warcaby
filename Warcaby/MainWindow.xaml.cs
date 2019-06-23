using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Warcaby
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();






        }
        Metody Rozgrywka = new Metody();
        
        /// <value>
        ///  <c>macierz</c> odpowiada za matematyczne przedstawienie pola i pionków. 0-oznacz puste pole, 1-biały pionek, 2-czerwony pionek, 3-białą damkę, 4-czerwoną damkę.
        /// </value>
        int[,] macierz = new int[8, 8]
        {
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
        };
        /// <value>
        ///  <c>macierz_obraz</c> jest macierzą obrazów, reprezentującą graficznie pole i pionki/damki.
        /// </value>
        System.Windows.Controls.Image[,] macierz_obraz = new System.Windows.Controls.Image[8, 8];

        
        /// <summary>
        /// Przycisk <c>Button</c> po wciśnięciu uzupełnia macierz obrazów, po czym ustala odpowiednie wartości umożliwiając rozpoczęcie nowej rozgrywki.
        /// </summary>
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            macierz_obraz[0, 0] = obrazek00;
            macierz_obraz[0, 2] = obrazek02;
            macierz_obraz[0, 4] = obrazek04;
            macierz_obraz[0, 6] = obrazek06;
            macierz_obraz[1, 1] = obrazek11;
            macierz_obraz[1, 3] = obrazek13;
            macierz_obraz[1, 5] = obrazek15;
            macierz_obraz[1, 7] = obrazek17;
            macierz_obraz[2, 0] = obrazek20;
            macierz_obraz[2, 2] = obrazek22;
            macierz_obraz[2, 4] = obrazek24;
            macierz_obraz[2, 6] = obrazek26;
            macierz_obraz[3, 1] = obrazek31;
            macierz_obraz[3, 3] = obrazek33;
            macierz_obraz[3, 5] = obrazek35;
            macierz_obraz[3, 7] = obrazek37;
            macierz_obraz[4, 0] = obrazek40;
            macierz_obraz[4, 2] = obrazek42;
            macierz_obraz[4, 4] = obrazek44;
            macierz_obraz[4, 6] = obrazek46;
            macierz_obraz[5, 1] = obrazek51;
            macierz_obraz[5, 3] = obrazek53;
            macierz_obraz[5, 5] = obrazek55;
            macierz_obraz[5, 7] = obrazek57;
            macierz_obraz[6, 0] = obrazek60;
            macierz_obraz[6, 2] = obrazek62;
            macierz_obraz[6, 4] = obrazek64;
            macierz_obraz[6, 6] = obrazek66;
            macierz_obraz[7, 1] = obrazek71;
            macierz_obraz[7, 3] = obrazek73;
            macierz_obraz[7, 5] = obrazek75;
            macierz_obraz[7, 7] = obrazek77;

            for(int i = 0;i<8;i++)
            {
                if(i%2==0)
                {
                    for(int j=0;j<8;j=j+2)
                    {
                        if(i<3)
                        {
                            Rozgrywka.zmien_wartosc(i, j, macierz, 1); 
                        }
                        else if(i>4)
                        {
                            Rozgrywka.zmien_wartosc(i, j, macierz, 2);
                        }
                        else
                        {
                            Rozgrywka.zmien_wartosc(i, j, macierz, 0);
                        }
                    }
                }
                else
                {
                    for (int j = 1; j < 8; j = j+2)
                    {
                        if (i < 3)
                        {
                            Rozgrywka.zmien_wartosc(i, j, macierz, 1);
                        }
                        else if (i > 4)
                        {
                            Rozgrywka.zmien_wartosc(i, j, macierz, 2);
                        }
                        else
                        {
                            Rozgrywka.zmien_wartosc(i, j, macierz, 0);
                        }
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < 8; j = j + 2)
                    {
                        int pozycja = Rozgrywka.zwroc_wartosc(i, j, macierz);
                        Rozgrywka.zmien_obraz(i, j, pozycja, macierz_obraz);
                    }
                }
                else
                {
                    for (int j = 1; j < 8; j = j + 2)
                    {
                        int pozycja = Rozgrywka.zwroc_wartosc(i, j, macierz);
                        Rozgrywka.zmien_obraz(i, j, pozycja, macierz_obraz);
                    }
                }
            }
            Rozgrywka.Dawne_pionki = 0;
            Rozgrywka.Remis = 0;
            Rozgrywka.Liczba_b_dam = 0;
            Rozgrywka.Liczba_cz_dam = 0;
            Rozgrywka.Liczba_b_pion = 12;
            Rozgrywka.Liczba_cz_pion = 12;
            Rozgrywka.Lewo_dol = 0;
            Rozgrywka.Lewo_gora = 0;
            Rozgrywka.Prawo_dol = 0;
            Rozgrywka.Prawo_gora = 0;
            Rozgrywka.Obecny_gracz = 1;
            Rozgrywka.Stan_tury = 0;
            teksty.Text = "Tura gracza Białego.";
        }
        /// <summary>
        /// Przycisk <c>przycisk00</c> reprezentuje pole 0;0. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        
        private void przycisk00_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 0;
                Rozgrywka.Wartosc_y = 0;
                if((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz+2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);

                    

                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk02</c> reprezentuje pole 0;2. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>

        private void przycisk02_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 0;
                Rozgrywka.Wartosc_y = 2;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);

                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk04</c> reprezentuje pole 0;4. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk04_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 0;
                Rozgrywka.Wartosc_y = 4;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    if (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz)
                        Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk06</c> reprezentuje pole 0;6. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk06_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 0;
                Rozgrywka.Wartosc_y = 6;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }

            }
        }
        /// <summary>
        /// Przycisk <c>przycisk11</c> reprezentuje pole 1;1. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk11_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 1;
                Rozgrywka.Wartosc_y = 1;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk13</c> reprezentuje pole 1;3. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk13_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 1;
                Rozgrywka.Wartosc_y = 3;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk15</c> reprezentuje pole 1;5. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk15_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 1;
                Rozgrywka.Wartosc_y = 5;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk17</c> reprezentuje pole 1;7. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk17_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 1;
                Rozgrywka.Wartosc_y = 7;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {                    
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);                    
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk20</c> reprezentuje pole 2;0. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk20_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 2;
                Rozgrywka.Wartosc_y = 0;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk22</c> reprezentuje pole 2;2. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk22_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 2;
                Rozgrywka.Wartosc_y = 2;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk24</c> reprezentuje pole 2;4. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk24_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 2;
                Rozgrywka.Wartosc_y = 4;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk26</c> reprezentuje pole 2;6. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk26_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 2;
                Rozgrywka.Wartosc_y = 6;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk31</c> reprezentuje pole 3;1. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk31_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 3;
                Rozgrywka.Wartosc_y = 1;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk33</c> reprezentuje pole 3;3. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk33_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 3;
                Rozgrywka.Wartosc_y = 3;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk35</c> reprezentuje pole 3;5. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk35_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 3;
                Rozgrywka.Wartosc_y = 5;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk37</c> reprezentuje pole 3;7. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk37_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 3;
                Rozgrywka.Wartosc_y = 7;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    
                    
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk40</c> reprezentuje pole 4;0. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk40_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 4;
                Rozgrywka.Wartosc_y = 0;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);


                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk42</c> reprezentuje pole 4;2. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk42_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 4;
                Rozgrywka.Wartosc_y = 2;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk44</c> reprezentuje pole 4;4. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk44_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 4;
                Rozgrywka.Wartosc_y = 4;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk46</c> reprezentuje pole 4;6. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk46_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 4;
                Rozgrywka.Wartosc_y = 6;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk51</c> reprezentuje pole 5;1. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk51_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 5;
                Rozgrywka.Wartosc_y = 1;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk53</c> reprezentuje pole 5;3. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk53_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 5;
                Rozgrywka.Wartosc_y = 3;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk55</c> reprezentuje pole 5;5. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk55_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 5;
                Rozgrywka.Wartosc_y = 5;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk57</c> reprezentuje pole 5;7. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk57_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 5;
                Rozgrywka.Wartosc_y = 7;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk60</c> reprezentuje pole 6;0. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk60_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 6;
                Rozgrywka.Wartosc_y = 0;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);

                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk62</c> reprezentuje pole 6;2. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk62_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 6;
                Rozgrywka.Wartosc_y = 2;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk64</c> reprezentuje pole 6;4. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk64_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 6;
                Rozgrywka.Wartosc_y = 4;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk66</c> reprezentuje pole 6;6. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przyciks66_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 6;
                Rozgrywka.Wartosc_y = 6;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    Rozgrywka.sprawdz_prawo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_gora(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk71</c> reprezentuje pole 7;1. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk71_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 7;
                Rozgrywka.Wartosc_y = 1;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                   
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk73</c> reprezentuje pole 7;3. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk73_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 7;
                Rozgrywka.Wartosc_y = 3;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                  
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk75</c> reprezentuje pole 7;5. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przyciks75_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 7;
                Rozgrywka.Wartosc_y = 5;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                    
                    Rozgrywka.sprawdz_prawo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }
        /// <summary>
        /// Przycisk <c>przycisk77</c> reprezentuje pole 7;7. Po wciśnięciu zmienia <c>wartosc_x</c> i <c>wartosc_y</c> by reprezentowały pionek na tym pole, oraz sprawdza pola sąsiednie by ustalić czy możliwe jest wykoanie ruchu.
        /// </summary>
        private void przycisk77_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 0)
            {
                Rozgrywka.Wartosc_x = 7;
                Rozgrywka.Wartosc_y = 7;
                if ((Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz) || (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2))
                {
                   
                    
                    
                    Rozgrywka.sprawdz_lewo_dol(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz);
                    Rozgrywka.Stan_tury = 1;
                    Rozgrywka.wyswietl_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz), Rozgrywka.Obecny_gracz, teksty);
                }
            }
        }

        /// <summary>
        /// Przycisk <c>Koniec_tury</c> po wciśnięciu kończy turę obecnego gracza, zmienia pionka w damkę (jeśli zajdzie taka potrzeba), sprawdza czy ma zakończyć rozgrywkę w wyniku stracenia wszystkich pionków i damek przez jednego z graczy, minięciu 15 ruchów bez zbicia żadnego pionka/damki lub braku możliwości ruchu przez jednego z graczy.
        /// </summary>
        

        private void Koniec_tury_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 4 || Rozgrywka.Stan_tury == 3)
            {
                if (Rozgrywka.Obecny_gracz == 1)
                {
                    Rozgrywka.Obecny_gracz = 2;
                    
                    teksty.Text = "Tura gracza Czerwonego.";
                }
                else
                {
                    Rozgrywka.Obecny_gracz = 1;
                    
                    teksty.Text = "Tura gracza Białego.";
                }

                Rozgrywka.Stan_tury = 0;
                Rozgrywka.zeroj_kier();
                for(int i = 0; i < 8; i = i + 2)
                {
                    if(macierz[0,i]==2)
                    {
                        Rozgrywka.zmiana_damka(0, i, macierz, macierz_obraz);
                        Rozgrywka.Liczba_cz_pion = Rozgrywka.Liczba_cz_pion - 1;
                        Rozgrywka.Liczba_cz_dam = Rozgrywka.Liczba_cz_dam + 1;
                    }
                }
                for(int i =1; i<8; i = i + 2)
                {
                    if (macierz[7,i]==1)
                    {
                        Rozgrywka.zmiana_damka(7, i, macierz, macierz_obraz);
                        Rozgrywka.Liczba_b_pion = Rozgrywka.Liczba_b_pion - 1;
                        Rozgrywka.Liczba_b_dam = Rozgrywka.Liczba_b_dam + 1;
                    }
                }

                if (Rozgrywka.Liczba_b_dam + Rozgrywka.Liczba_b_pion == 0)
                {
                    teksty.Text = "Wygrywa gracz Czerwony";
                    Rozgrywka.Stan_tury = 5;
                }
                else if (Rozgrywka.Liczba_cz_dam + Rozgrywka.Liczba_cz_pion == 0)
                {
                    teksty.Text = "Wygrywa gracz Biały";
                    Rozgrywka.Stan_tury = 5;
                }
                else if (Rozgrywka.Liczba_cz_dam!=0 | Rozgrywka.Liczba_b_dam != 0)
                {
                    if(Rozgrywka.Dawne_pionki==Rozgrywka.Liczba_b_dam+Rozgrywka.Liczba_b_pion+Rozgrywka.Liczba_cz_dam+Rozgrywka.Liczba_cz_pion)
                    {
                        Rozgrywka.Remis = Rozgrywka.Remis + 1;
                    }
                    else
                    {
                        Rozgrywka.Remis = 0;
                    }
                    
                }

                if (Rozgrywka.Remis == 15)
                {
                    Rozgrywka.Stan_tury = 5;
                    teksty.Text = "Gra kończy się remisem.";
                }

                Rozgrywka.Dawne_pionki = Rozgrywka.Liczba_b_dam + Rozgrywka.Liczba_b_pion + Rozgrywka.Liczba_cz_dam + Rozgrywka.Liczba_cz_pion;
                Rozgrywka.Pat = 0;
                if (Rozgrywka.Stan_tury !=5)
                {
                    for(int i =0;i<8;i++)
                    {
                        for(int j=0;j<8;j++)
                        {
                            if(macierz[i,j]==Rozgrywka.Obecny_gracz || macierz[i,j]==Rozgrywka.Obecny_gracz+2 )
                            {
                                Rozgrywka.sprawdz_lewo_dol(i,j,macierz);
                                Rozgrywka.sprawdz_lewo_gora(i, j, macierz);
                                Rozgrywka.sprawdz_prawo_dol(i, j, macierz);
                                Rozgrywka.sprawdz_prawo_gora(i, j, macierz);
                                if (Rozgrywka.Lewo_dol != 0 || Rozgrywka.Lewo_gora != 0 || Rozgrywka.Prawo_dol!=0 || Rozgrywka.Prawo_gora!=0)
                                {
                                    Rozgrywka.Pat = Rozgrywka.Pat + 1;
                                }
                                Rozgrywka.zeroj_kier();
                                
                            }
                        }
                    }
                    if (Rozgrywka.Pat == 0)
                    {
                        Rozgrywka.Stan_tury = 5;
                        teksty.Text = "Gra kończy się remisem. ";
                    }
                }

            }
        }

        /// <summary>
        /// Przycisk <c>Anuluj_wybor</c> po wciśnięciu anuluje wybór pionka.
        /// </summary>
       
        private void Anuluj_wybor_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 1)
            {
                Rozgrywka.Stan_tury = 0;
                Rozgrywka.zeroj_kier();
                if (Rozgrywka.Obecny_gracz == 1)
                {
                    teksty.Text = "Tura gracza Białego.";
                }
                else
                {
                    teksty.Text = "Tura gracza Czerwonego.";
                }


            }
        }
        /// <summary>
        /// Przyciks <c>gora_lewo</c> po wciśnięciu w zależności od potrzeby powoduje ruch lub bicie pionka znajdującego się na górnym, lewym polu.
        /// </summary>
        
        private void gora_lewo_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 1)
            {
                if (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz)
                    
                {
                    if (Rozgrywka.Obecny_gracz == 1)
                    {
                        if (Rozgrywka.Lewo_gora == 1)
                        {
                            Rozgrywka.idz_lewo_gora_pion_pusty(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                            Rozgrywka.zeroj_kier();
                            Rozgrywka.Stan_tury = 4;
                        }
                        else if (Rozgrywka.Lewo_gora == 2)
                        {
                            Rozgrywka.bij_lewo_gora_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);

                        }
                    }                                      
                }
                else if (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2)
                {
                    if (Rozgrywka.Lewo_gora == 1)
                    {
                        Rozgrywka.idz_lewo_gora_dama_puste(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                    }
                    else if (Rozgrywka.Lewo_gora == 2)
                    {
                        Rozgrywka.bij_lewo_gora_dama(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                    }
                }
            }
            else if (Rozgrywka.Stan_tury == 2)
            {
                if (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz)
                {
                    if (Rozgrywka.Lewo_gora == 2)
                    {
                        Rozgrywka.bij_lewo_gora_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                    }
                }
                else if (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2)
                {
                    if (Rozgrywka.Lewo_gora == 2)
                    {
                        Rozgrywka.bij_lewo_gora_dama(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                    }
                }
            }
            else if (Rozgrywka.Stan_tury == 3)
            {
                if (Rozgrywka.Lewo_gora == 1)
                {
                    Rozgrywka.idz_lewo_dol_dama_puste(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                }
            }
            
        }
        /// <summary>
        /// Przyciks <c>gora_prawo</c> po wciśnięciu w zależności od potrzeby powoduje ruch lub bicie pionka znajdującego się na górnym, prawym polu.
        /// </summary>
        private void gora_prawo_Click(object sender, RoutedEventArgs e)
        {

            if (Rozgrywka.Stan_tury == 1)
            {
                if (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz)
                    
                {

                    if (Rozgrywka.Obecny_gracz == 1)
                    {
                        if (Rozgrywka.Prawo_gora == 1)
                        {
                            Rozgrywka.idz_prawo_gora_pion_pusty(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                            Rozgrywka.zeroj_kier();
                            Rozgrywka.Stan_tury = 4;
                        }
                        else if (Rozgrywka.Prawo_gora == 2)
                        {
                            Rozgrywka.bij_prawo_gora_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);

                        }
                    }
                }
                else if (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz+2)
                {
                    if (Rozgrywka.Prawo_gora == 1)
                    {
                        Rozgrywka.idz_prawo_gora_dama_puste(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                    }
                    else if (Rozgrywka.Prawo_gora == 2)
                    {
                        Rozgrywka.bij_prawo_gora_dama(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                    }
                }
            }
            else if (Rozgrywka.Stan_tury == 2)
            {
                if (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz)
                {
                    if (Rozgrywka.Prawo_gora == 2)
                    {
                        Rozgrywka.bij_prawo_gora_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                    }
                }
                else if (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2)
                {
                    if (Rozgrywka.Prawo_gora == 2)
                    {
                        Rozgrywka.bij_prawo_gora_dama(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                    }
                }
            } 
            else if (Rozgrywka.Stan_tury == 3)
            {
                if (Rozgrywka.Prawo_gora == 1)
                {
                    Rozgrywka.idz_prawo_gora_dama_puste(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                }
            }
            
        }
        /// <summary>
        /// Przyciks <c>dol_lewo</c> po wciśnięciu w zależności od potrzeby powoduje ruch lub bicie pionka znajdującego się na dolnym, lewym polu.
        /// </summary>
        private void dol_lewo_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 1)
            {
                if (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz)

                {
                    if (Rozgrywka.Obecny_gracz == 2)
                    {
                        if (Rozgrywka.Lewo_dol == 1)
                        {
                            Rozgrywka.idz_lewo_dol_pion_pusty(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                            Rozgrywka.zeroj_kier();
                            Rozgrywka.Stan_tury = 4;
                        }
                        else if (Rozgrywka.Lewo_dol == 2)
                        {
                            Rozgrywka.bij_lewo_dol_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);

                        }
                    }
                }
                else if (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2)
                {
                    if (Rozgrywka.Lewo_dol == 1)
                    {
                        Rozgrywka.idz_lewo_dol_dama_puste(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                    }
                    else if (Rozgrywka.Lewo_dol == 2)
                    {
                        Rozgrywka.bij_lewo_dol_dama(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                    }
                }
            }
            else if (Rozgrywka.Stan_tury == 2)
            {
                if (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz)
                {
                    if (Rozgrywka.Lewo_dol == 2)
                    {
                        Rozgrywka.bij_lewo_dol_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                    }
                }
                else if (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2)
                {

                    if (Rozgrywka.Lewo_dol == 2)
                    {
                        Rozgrywka.bij_lewo_dol_dama(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                    }

                }
            }
            else if (Rozgrywka.Stan_tury == 3)
            {
                if (Rozgrywka.Lewo_dol == 1)
                {
                    Rozgrywka.idz_lewo_dol_dama_puste(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                }
            }

            
        }
        /// <summary>
        /// Przyciks <c>dol_prawo</c> po wciśnięciu w zależności od potrzeby powoduje ruch lub bicie pionka znajdującego się na dolnym, prawym polu.
        /// </summary>
        private void dol_prawo_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywka.Stan_tury == 1)
            {
                if (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz)

                {
                    if (Rozgrywka.Obecny_gracz == 2)
                    {
                        if (Rozgrywka.Prawo_dol == 1)
                        {
                            Rozgrywka.idz_prawo_dol_pion_pusty(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                            Rozgrywka.zeroj_kier();
                            Rozgrywka.Stan_tury = 4;
                        }
                        else if (Rozgrywka.Prawo_dol == 2)
                        {
                            Rozgrywka.bij_prawo_dol_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);

                        }
                    }
                }
                else if (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2)
                {
                    if (Rozgrywka.Prawo_dol == 1)
                    {
                        Rozgrywka.idz_prawo_dol_dama_puste(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                    }
                    else if (Rozgrywka.Prawo_dol == 2)
                    {
                        Rozgrywka.bij_prawo_dol_dama(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                    }
                }
            }
            else if (Rozgrywka.Stan_tury == 2)
            {
                if (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz)
                {
                    if (Rozgrywka.Prawo_dol == 2)
                    {
                        Rozgrywka.bij_prawo_dol_pion(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                    }
                }
                else if (Rozgrywka.zwroc_wartosc(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz) == Rozgrywka.Obecny_gracz + 2)
                {

                    if (Rozgrywka.Prawo_dol == 2)
                    {
                        Rozgrywka.bij_prawo_dol_dama(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                    }

                }
            }
            else if (Rozgrywka.Stan_tury == 3)
            {
                if (Rozgrywka.Prawo_dol == 1)
                {
                    Rozgrywka.idz_prawo_dol_dama_puste(Rozgrywka.Wartosc_x, Rozgrywka.Wartosc_y, macierz, macierz_obraz);
                }
            }
            
        }
    }
}
