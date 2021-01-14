using System;

namespace UserManager 
{
    class UserManager 
    {
        private static void mainMenu() {
            Console.WriteLine("Welcome.\n\nSelect option.\n" +
                    "[1] Add Person.\n[2] List of Person.\n[3] Exit.");
        }
        private static void addPerson() {
            Console.Clear();
            
            Console.WriteLine("Add person.\n");
            Console.ReadKey(true);
            
            Console.Clear();
            mainMenu();
        }
        private static void showListOfPersons(){
            Console.Clear();

            Console.WriteLine("List of Persons.\n");
            Console.ReadKey(true);
            
            Console.Clear();
            mainMenu();
        }
        public static void executeProgram() {
            mainMenu();
            int chose = 0;
            do {
                chose = Convert.ToInt32(Console.ReadLine());
                switch (chose) {
                    case 1:
                       addPerson(); break;
                    case 2:
                        showListOfPersons(); break;
                    case 3: break;
                    default:
                         Console.Clear(); mainMenu(); Console.WriteLine("\nIncorrect check.Chceck option from menu.\n"); break; 
                }
            } while (chose != 3);
        }   
    }
}
