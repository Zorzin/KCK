using System;
using System.Collections.Generic;

namespace KCKTest.Views.layouts
{
    internal static class Menu
    {
        private static int bottomOffset;
        private static int topOffset = 1;
        public static int Selected { get; set; }

        /**
         * Wyświetlanie menu z obnizona pozycja o @position +1 
         * Potrzebne do wyświetlania menu przy wyświetlaniu info o aktywnosci itp.
         **/
        public static void ShowMenu(List<string> menuList, int position)
        {
            topOffset = position + 1;
            ShowMenu(menuList);
            topOffset = 1;
        }
        /**
         * Wyświetlanie menu
         * @manuList lista stringow do wyswietlenia
         * wybrana pozycja zapisuje sie w @Selected
         **/
        public static void ShowMenu(List<string> menuList)
        {
            Console.SetCursorPosition(0, topOffset);
            Console.CursorVisible = false;
            var selected = 0;
            var enter = false;
            while (!enter)
            {
                for (var i = 0; i < menuList.Count; i++)
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("-" + menuList[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("-" + menuList[i]);
                    }
                bottomOffset = Console.CursorTop;
                var kb = Console.ReadKey(true);
                switch (kb.Key)
                {
                    //react to input
                    case ConsoleKey.UpArrow:
                        if (selected > 0)
                            selected--;
                        else
                            selected = menuList.Count - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        if (selected < menuList.Count - 1)
                            selected++;
                        else
                            selected = 0;
                        break;

                    case ConsoleKey.Enter:
                        enter = true;
                        Selected = selected;
                        break;
                }
                Console.SetCursorPosition(0, topOffset);
            }
            Console.SetCursorPosition(0, bottomOffset);
        }
    }
}