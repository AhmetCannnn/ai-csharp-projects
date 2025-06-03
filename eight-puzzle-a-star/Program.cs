using System;
using System.Collections.Generic;
using System.Linq;

namespace _8_tas_bulmacasi
{

    // her adımı tutmak için node'ları kullandım
    public class Node
    {
        public int[] State { get; set; } // bulmaca tahtasının durumu
        public int G { get; set; } // ilerleme adım sayısı
        public int H { get; set; } // heuristic (tahmin) değeri , hedefe kaç adım kaldığının sezgisel değeri
        public int F { get; set; } // toplam değer F = G + H
        public Node Parent { get; set; } // node'lar arası bağlantıyı sağlamak ve çözüm yolunu takip edebilmek için

        // node nesnesini oluşturan metod
        public Node(int[] state, int g, int h, Node parent)
        {
            State = state;
            G = g;
            H = h;
            F = G + H;
            Parent = parent;
        }
    }

    internal class Program
    {
        // en kısa yol için sıralama yapmamız gerekeceğinden dolayı sorted list kullandım
        static SortedList<int, List<Node>> openList = new SortedList<int, List<Node>>();

        // sıralamaya gerek olmadığından sadece kullanılan yollar tutulacağından dolayı hız acısından hashset kullandım
        static HashSet<string> closedList = new HashSet<string>();


        // kullanıcıdan tahtayı oluşturan değerli aldığım fonskiyon
        public static int[] GetStartStateFromUser()
        {
            int[] startState = new int[9];
            Console.WriteLine("Başlangıç durumunu giriniz (0-8 arasında rakamlar):");

            for (int i = 0; i < 9; i++)
            {
                while (true)
                {
                    Console.Write($"Giriş {i + 1}: ");
                    int input = Convert.ToInt32(Console.ReadLine());
                    if (input >= 0 && input <= 8 && !startState.Contains(input) || input == 0)
                    {
                        startState[i] = input;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz giriş! 0-8 arasında rakam girin ve tekrar olmasın.");
                    }
                }
            }

            Console.WriteLine("\nGiriş değerleriniz şu şekilde:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(startState[i * 3 + j] + " ");
                }
                Console.WriteLine();
            }

            return startState;
        }

        // boşluğun (sıfırın) konumunu belirleyen metod
        public static int FindZeroIndex(int[] state)
        {
            for (int i = 0; i < state.Length; i++)
            {
                if (state[i] == 0)
                    return i;
            }
            return -1;
        }

        // boşluğun (sıfırın) gidebileceği yerleri belirleyen metod
        static List<int> GetPossibleMoves(int emptyIndex)
        {
            List<int> moves = new List<int>();

            if (emptyIndex - 3 >= 0) moves.Add(emptyIndex - 3);
            if (emptyIndex + 3 < 9) moves.Add(emptyIndex + 3);
            if (emptyIndex % 3 != 0) moves.Add(emptyIndex - 1);
            if (emptyIndex % 3 != 2) moves.Add(emptyIndex + 1);

            return moves;
        }

        // heuristic degeri hesaplayan metod
        public static int CalculateHeuristic(int[] state)
        {

            int[] goalState = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 }; // hedef durum
            int heuristic = 0;

            // her bi indeksteki degerin heuristic degerini hesaplamamızı saglayan dongu
            for (int i = 0; i < state.Length; i++)
            {
                if (state[i] != 0)
                {
                    int currentRow = i / 3;
                    int currentCol = i % 3;
                    int goalRow = Array.IndexOf(goalState, state[i]) / 3;
                    int goalCol = Array.IndexOf(goalState, state[i]) % 3;

                    heuristic += Math.Abs(currentRow - goalRow) + Math.Abs(currentCol - goalCol);
                }
            }

            return heuristic;
        }

        public static int CalculateF(int g, int h)
        {
            return g + h;
        }

        static void AStarSearch(int[] startState)
        {
            // baslangic node'unu olusturuyoruz cunku baslangıctan hedefe olan uzaklıgımızı belirlememiz gerekiyor
            Node startNode = new Node(startState, 0, CalculateHeuristic(startState), null); 

            if (!openList.ContainsKey(startNode.F))
            {
                openList[startNode.F] = new List<Node>();
            }
            openList[startNode.F].Add(startNode);

            while (openList.Count > 0)
            {
                var currentNodeList = openList.Values.First(); // F değerine göre sıralı
                var currentNode = currentNodeList.First(); // ilk node'u al çünkü f degeri en dusuk olan node 

                currentNodeList.RemoveAt(0);
                if (currentNodeList.Count == 0)
                {
                    openList.RemoveAt(0); // kullandığımız node'u çıkarıyoruz cunku o f degeri islendi ve tekrar denenmeycek
                }

                // eger tum indeksler istedigimiz sekildeyse cozume ulasmıs oluruz
                if (currentNode.State.SequenceEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 }))
                {
                    Console.WriteLine();
                    Console.WriteLine($"Çözüm bulundu! Adım sayısı (G değeri): {currentNode.G}");
                    PrintSolution(currentNode);
                    return;
                }

                foreach (var move in GetPossibleMoves(FindZeroIndex(currentNode.State)))
                {
                    // degisikleri yapmak icin yeni bi durum tanımlıyoruz
                    int[] newState = new int[9];
                    Array.Copy(currentNode.State, newState, 9);

                    newState[FindZeroIndex(newState)] = newState[move];
                    newState[move] = 0; // 0'ı yeni yerine alıyoruz

                    // ve yeni olusan node (1 adım ilerlediğimiz iicn de G'yi 1 artırıyoruz)
                    Node newNode = new Node(newState, currentNode.G + 1, CalculateHeuristic(newState), currentNode);

                    // yeni dugum closedlistte var mı yok mu (yani daha once kullanıldı mı)
                    if (!closedList.Contains(string.Join(",", newNode.State))) 
                    {
                        // Burada openList kontrolü eklenmeli
                        if (!openList.Any(kvp => kvp.Value.Any(n => n.State.SequenceEqual(newNode.State))))
                        {
                            // dugumun daha onceen openlıste eklenip eklenmedigi kontrol ediliyor ve eklenmediyse ekleniyor
                            if (!openList.ContainsKey(newNode.F)) 
                            {
                                openList[newNode.F] = new List<Node>();
                            }
                            openList[newNode.F].Add(newNode);
                        }
                    }
                }

                closedList.Add(string.Join(",", currentNode.State)); // işlenen dugumu kapalı listeye ekler
            }
        }
        // cozum yolunu yazdırmaya yarar
        static void PrintSolution(Node node)
        {
            if (node == null) return;
            PrintSolution(node.Parent);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(node.State[i * 3 + j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            int[] startState = GetStartStateFromUser();
            AStarSearch(startState);
            
        }
    }
}
