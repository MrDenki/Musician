using controller;
using System;
using System.Collections.Generic;

namespace musician
{
    class Program
    {
        public static void MainInfo()
        {
            Console.Clear();
            Console.WriteLine("1 - Добавить артиста");
            Console.WriteLine("2 - Добавить альбом");
            Console.WriteLine("3 - Добавить сборник");
            Console.WriteLine("4 - Вывести список артистов");
            Console.WriteLine("5 - Вывести список альбомов");
            Console.WriteLine("6 - Вывести список сборников");

            Console.WriteLine("7 - Поиск Артиста по имени");
            Console.WriteLine("8 - Поиск альбома по названию");
            Console.WriteLine("9 - Поиск песни по жанру");

            Console.WriteLine("10 - Выйти из программы");
            Console.Write("Выберите опцию:\t");
        }

        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            catalog.AddGenre("Рок-Ролл");
            catalog.AddGenre("Поп-поп");
            catalog.AddGenre("Реп-реп");
            catalog.AddGenre("Классика");
            catalog.AddGenre("Джаз");

            catalog.AddArtist("mrdenkiii", catalog.GetGenre(1));
            catalog.AddArtist("LinkinPark", catalog.GetGenre(4));
            catalog.AddArtist("Scorpions", catalog.GetGenre(2));

            string[] list = new string[3];
            list[0] = "ff";
            list[1] = "ss";
            list[2] = "tt";

            catalog.AddAlbum("First", catalog.GetArtist(1), catalog.GetListSong(list));

            string[] second_list = new string[4];
            second_list[0] = "bb";
            second_list[1] = "gg";
            second_list[2] = "dd";
            second_list[3] = "ee";
            catalog.AddAlbum("Mexico", catalog.GetArtist(2), catalog.GetListSong(second_list));

            int exit = 1;

            while (exit != 0)
            {
                MainInfo();
                int value = Convert.ToInt32(Console.ReadLine());

                switch (value)
                {
                    case 1: // Добавить артиста
                        Console.Clear();

                        Console.Write("Введите имя артиста:\t");
                        string name = Console.ReadLine();

                        catalog.PrintGenre();

                        Console.Write("Выберите жанр артиста:\t");
                        int number_of_genre = Convert.ToInt32(Console.ReadLine());
                        catalog.AddArtist(name, catalog.GetGenre(number_of_genre));
                        break;
                    case 2: // Добавить альбом
                        Console.Clear();

                        Console.Write("Введите наименование альбома:\t");
                        string title = Console.ReadLine();

                        Console.WriteLine("Выберите артиста:\t");
                        catalog.PrintArtists();
                        Console.WriteLine("Выберите артиста:\t");
                        int number_of_artist = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Сколько треков вы хотите добавить?\t");
                        int count_of_traks = Convert.ToInt32(Console.ReadLine());

                        string[] new_traks = new string[count_of_traks];
                        for (int i = 0; i < count_of_traks; i++)
                        {
                            Console.WriteLine("Введите наименование трека:\t");
                            new_traks[i] = Console.ReadLine();
                        }

                        catalog.AddAlbum(title, catalog.GetArtist(number_of_artist), catalog.GetListSong(new_traks));
                        break;

                    case 3: // Добавить сборник
                        Console.Write("Введите название сборнка:\t");
                        string title_of_compilation = Console.ReadLine();

                        catalog.PrintAllSongs();
                        Console.Write("Какие треки вы хотите добавить (введите наименования через пробел)?\t");
                        string[] exisits_traks = Console.ReadLine().Split(' ');
                        catalog.AddCompilation(title_of_compilation, exisits_traks);
                        break;

                    case 4: // Вывести список артистов
                        catalog.PrintArtists();
                        break;

                    case 5: // Вывести список альбомов
                        catalog.PrintAlbums();
                        break;

                    case 6: // Вывести список сборников
                        catalog.PrintCompilation();
                        break;

                    case 7: // Поиск Артиста по имени
                        Console.Write("Введите имя артиста:\t");
                        string find_artist = Console.ReadLine();
                        catalog.PrintArtist(catalog.FindArtist(find_artist));
                        break;

                    case 8: // Поиск альбома по названию
                        Console.Write("Введите наименовние альбома:\t");
                        string find_album= Console.ReadLine();
                        catalog.PrintAlbum(catalog.FindAlbum(find_album));
                        break;

                    case 9: // Поиск песен по жанру
                        catalog.PrintGenre();
                        Console.Write("Введите жанр:\t");
                        int genre_song = Convert.ToInt32(Console.ReadLine());
                        catalog.PrintSongsByAlbum(catalog.FindSongByGenre(catalog.GetGenre(genre_song).Name));
                        break;

                    case 10: // Выйти из программы
                        exit = 0;
                        break;
                }
            }

            
        }
    }
}
