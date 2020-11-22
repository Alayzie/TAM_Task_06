using System;

namespace TAM_Task_06

{

    class Program

    {

        static void Addfile(ref string[] N, ref string[] P)//Добавление досье

        {
            
            string[] boof;

            string s;

            int count;

        reN:

            Console.Write("Отмена: -\nВведите соответствующее ФИО: ");

            s = Console.ReadLine();

            count = N.Length;
            boof = new string[count];

            if ((s != "") && (s != "- ")) // Ввод имени

            {

                count++;

                boof = N;

                N = new string[count];

                for (int i = 0; i < count - 1; i++)

                    N[i] = boof[i];

                N[count - 1] = s;

            }

            else if (s == "") // проверка на пустоту

            {

                Console.WriteLine("Ошибка!!! Строка пуста! Для отмены введите -");

                goto reN;

            }

            else if (s == "-") return; // отмена операции

            reP:

            Console.Write("Введите Должность сотрудника: ");

            s = Console.ReadLine();

            if (s != "") // Ввод должности

            {

                boof = P;

                P = new string[count];

                for (int i = 0; i < count - 1; i++)

                    P[i] = boof[i];
                P[count - 1] = s;

            }

            else if (s == "")

            {

                Console.WriteLine("Ошибка!!! Строка пуста!");

                goto reP;

            }

        }

        static void Find(string[] N, string[] P)// Поиск по имени

        {

            string F;

            bool Fin;

            Masout(N, P);

            Console.Write("Введите ФИО для поиска: ");

            F = Console.ReadLine();

            Console.Clear();

            for (int i = 0; i < N.Length; i++)

            {

                Fin = N[i].Contains(F, StringComparison.CurrentCultureIgnoreCase); // Поиск совпадений

                if (Fin == true)

                {

                    Console.WriteLine($"{i + 1}.\t{N[i]} - {P[i]}");

                }

            }

            Console.ReadKey();

        }

        static void Masout(string[] N, string[] P) // Вывод массивов
        {

            for (int i = 0; i < N.Length; i++)

            {

                Console.WriteLine($"{i + 1}.\t{N[i]} - {P[i]}");

            }

            Console.ReadKey();

        }

        static void Del(ref string[] N, ref string[] P) // Удаление данных

        {

            int DelNum;

            string[] DelBoofN, DelBoofP;

        del:

            Console.WriteLine("Введите номер досье для удаления.");

            Console.WriteLine("Если вы не знаете номер досье: введите 0 и в меню выбирете поиск");

            Console.Write(">");

            DelNum = Convert.ToInt32(Console.ReadLine());

            if (DelNum <= 0)

            {

                return;

            }
            else if (DelNum > N.Length)

            {

                Console.WriteLine("Досье с таким номером не существует!");

                Console.ReadKey();

                Console.Clear();

                goto del;

            }

            DelNum--;

            DelBoofN = N;
            DelBoofP = P;

            if (DelNum != N.Length)
            {

                for (int i = DelNum--; i < N.Length - 1; i++)

                {

                    DelBoofN[i] = DelBoofN[i + 1];

                    DelBoofP[i] = DelBoofP[i + 1];

                }

                N = new string[DelBoofN.Length - 1];

                P = new string[DelBoofP.Length - 1];

                for (int i = 0; i < N.Length; i++)

                {

                    N[i] = DelBoofN[i];

                    P[i] = DelBoofP[i];

                }

            }

            else

            {

                N = new string[DelBoofN.Length - 1];

                P = new string[DelBoofP.Length - 1];

                for (int i = 0; i < N.Length; i++)

                {

                    N[i] = DelBoofN[i];

                    P[i] = DelBoofP[i];

                }

            }

            Console.WriteLine("Удаление успешно завершенно!");

            Console.ReadKey();

        }

        static void Menu(ref string[] N, ref string[] P) // Интерфейс

        {
            string passWord;

            do

            {

                Console.Clear();

                Console.WriteLine("=================================================================================");
                Console.WriteLine(@"
                     _____                _           
                    |  __ \              (_)          
                    | |  | | ___  ___ ___ _  ___ _ __ 
                    | |  | |/ _ \/ __/ __| |/ _ \ '__|
                    | |__| | (_) \__ \__ \ |  __/ |   
                    |_____/ \___/|___/___/_|\___|_|                                                                        

                            ");
                Console.WriteLine("=================================================================================");

                Console.WriteLine('\n');

                Console.WriteLine("Управление:");

                Console.WriteLine("Add dossier - Добавить досье.");

                Console.WriteLine("Find name of dossier - Поиск досье по ФИО.");

                Console.WriteLine("Show dossier - Вывести все досье.\n");

                Console.WriteLine("Delete dossier - Удаление досье.\n");

                Console.WriteLine("Escape - Выход.");                                 

                Console.WriteLine("===============================================================================================================================");
                Console.WriteLine("Выберите нужную команду.");
                Console.WriteLine("===============================================================================================================================");

                    passWord = Console.ReadLine();

                    switch (passWord)
                    {

                        case "Add dossier":

                        Console.Clear();

                        Addfile(ref N, ref P);

                            break;

                        case "Find name of dossier":

                            Console.Clear();

                            Find(N, P);

                            break;

                        case "Show dossier":

                            Console.Clear();

                            Masout(N, P);

                            break;

                        case "Delete dossier":

                            Console.Clear();

                            Del(ref N, ref P);

                            break;                     

                    }

            } while (passWord != "Escape"); 

            Console.Clear();
            Console.WriteLine("======================================================================");
            Console.WriteLine(@"

               _____ _                    _ 
              / ____| |                  | |
             | |    | | ___  ___  ___  __| |
             | |    | |/ _ \/ __|/ _ \/ _` |
             | |____| | (_) \__ \  __/ (_| |
              \_____|_|\___/|___/\___|\__,_|
                                

                ");
            Console.WriteLine("======================================================================");
        }

        static void Main(string[] args)

        {

            string[] Name = new string[0];

            string[] Position = new string[0]; // Объявление массивов

            int origWidth, origHeight;

            origWidth = Console.WindowWidth;

            origHeight = Console.WindowHeight; // Изменяем командную строку

            Console.SetWindowSize(origWidth / 2, origHeight);

            Menu(ref Name, ref Position);

        }

    }

}