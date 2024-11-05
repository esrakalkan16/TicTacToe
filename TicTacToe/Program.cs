using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 3x3'lük gridimizi tanımlıyoruz
            string[] grid = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            bool player1Turn = true; // Oyuncu 1'in sırasının başlangıçta olduğunu gösterir
            int numTurns = 0; // Toplam yapılan hamle sayısı

            // Oyun devam ederken, bir oyuncu kazanana veya toplam 9 hamle yapılana kadar döngü sürer
            while (!CheckVictory() && numTurns < 9)
            {
                PrintGrid(); // Grid'i ekrana yazdırır

                // Kimin oynayacağını ekrana yazar
                if (player1Turn)
                    Console.WriteLine("Player 1 Turn!");
                else
                    Console.WriteLine("Player 2 Turn!");

                string choice = Console.ReadLine(); // Kullanıcıdan hamlesini alır

                // Kullanıcının girdiği değerin geçerli bir hareket olup olmadığını kontrol eder
                if (int.TryParse(choice, out int gridIndex) && gridIndex >= 1 && gridIndex <= 9 && grid[gridIndex - 1] != "X" && grid[gridIndex - 1] != "O")
                {
                    gridIndex--; // Kullanıcının girdisini dizinin indeksine dönüştürmek için 1 azaltıyoruz
                    grid[gridIndex] = player1Turn ? "X" : "O"; // Oyuncuya göre X veya O ekleriz
                    numTurns++; // Hamle sayısını bir artırır
                }
                else
                {
                    Console.WriteLine("Invalid move! Try again."); // Geçersiz hamlede kullanıcıyı uyarır
                    continue; // Döngüyü tekrar çalıştırır
                }

                // Oyuncu sırasını değiştirir
                player1Turn = !player1Turn;
            }

            PrintGrid(); // Son durumu ekrana yazdırır

            if (CheckVictory())
            {
                // Kazanan oyuncuyu belirlemek için player1Turn'ü ters çeviririz
                string winner = !player1Turn ? "Player 1" : "Player 2";
                Console.WriteLine($"{winner} wins!"); // Kazananı ekrana yazar
            }
            else
            {
                Console.WriteLine("Tie!"); // Oyun berabere biterse
            }

            // Grid'i ekrana yazdıran metod
            void PrintGrid()
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(grid[i * 3 + j]);
                        if (j < 2) Console.Write("|"); // Grid'deki satırları düzgün ayırmak için
                    }
                    Console.WriteLine();
                    if (i < 2) Console.WriteLine("------"); // Grid'in alt kısmına çizgi çeker
                }
            }

            // Oyunun kazanılıp kazanılmadığını kontrol eden metod
            bool CheckVictory()
            {
                // Kazanma durumlarını kontrol eder
                bool row1 = grid[0] == grid[1] && grid[1] == grid[2];
                bool row2 = grid[3] == grid[4] && grid[4] == grid[5];
                bool row3 = grid[6] == grid[7] && grid[7] == grid[8];
                bool col1 = grid[0] == grid[3] && grid[3] == grid[6];
                bool col2 = grid[1] == grid[4] && grid[4] == grid[7];
                bool col3 = grid[2] == grid[5] && grid[5] == grid[8];
                bool diagDown = grid[0] == grid[4] && grid[4] == grid[8];
                bool diagUp = grid[6] == grid[4] && grid[4] == grid[2];

                // Eğer herhangi bir kazanma durumu varsa, true döner
                return row1 || row2 || row3 || col1 || col2 || col3 || diagDown || diagUp;
            }
        }
    }
}
