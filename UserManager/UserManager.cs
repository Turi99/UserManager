using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            string addPersonOption = "Check option.\n[1] Write data of person.\n[2] Back.\n";
            int addPersonChose = 0;

            do {
                Console.WriteLine(addPersonOption);
                addPersonChose = Convert.ToInt32(Console.ReadLine());

                switch (addPersonChose) {
                    case 1:
                        addDataPerson(); break;
                    case 2:
                        Console.Clear(); break;
                }
            } while (addPersonChose != 2);

            mainMenu();
        }

        private static void addDataPerson() {
            Console.Clear();
            string name, surname;
            int age;
            Console.Write("Write name: ");
            name = Console.ReadLine();
            Console.Write("Write surname: ");
            surname = Console.ReadLine();
            Console.Write("Write name: ");
            age = Convert.ToInt32(Console.ReadLine());

            string line = name + '\t' + surname + '\t' + age;
            const string fileName = "Users.txt";

            if (!File.Exists(fileName)) {
                using (StreamWriter outputFile = File.CreateText(fileName)) {
                    outputFile.Write(line);
                }
            }
            else {
                File.AppendAllText(fileName, '\n' + line);
            }

            Console.Clear();
        }
        
        private static void showListOfPersons(){
            Console.Clear();
            string addPersonOption = "Check option.\n[1] Show list of Persons.\n[2] Back.\n";
            int showPersonChose = 0;

            do {
                Console.WriteLine(addPersonOption);
                showPersonChose = Convert.ToInt32(Console.ReadLine());

                switch (showPersonChose) {
                    case 1:
                        showDataFromFile(); break;
                    case 2:
                        Console.Clear(); break;
                }
            } while (showPersonChose != 2);

            mainMenu();
        }

        private static void showDataFromFile() {
            Console.Clear();
            const string fileName = "Users.txt";

            if (!File.Exists(fileName)) {
                Console.WriteLine("File not Exists!");
            }
            else {
                if(new FileInfo(fileName).Length == 0) {
                    Console.WriteLine("File is Empty!");
                }
                else {
                    List<Person> persons = new List<Person>();
                    string inputFile = File.ReadAllText(fileName);
                    string[] lines = File.ReadAllLines(fileName);
                    string name="", surname="";
                    string age = "";

                    foreach(string line in lines) {
                        name = ""; surname = ""; age = "";
                        int index1=line.IndexOf('\t');
                        int index2 = 0;
                        for(int i = index1; i < line.Length; ++i) {
                            if(line[i] == '\t') {
                                index2 = i;
                            }
                        }

                        for(int i = 0; i < index1; ++i) {
                            name += line[i];
                        }
                        for(int i=index1+1;i<index2;++i) {
                            surname += line[i];
                        }
                        for(int i = index2 + 1; i < line.Length; ++i) {
                            age += line[i];
                        }

                        persons.Add(new Person(name, surname, Int32.Parse(age)));
                    }

                    foreach(Person p in persons) {
                        Console.WriteLine(Person.writePerson(p));
                    }
                }
            }

            Console.ReadKey(true);
            Console.Clear();
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
