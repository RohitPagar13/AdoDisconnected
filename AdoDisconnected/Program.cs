﻿namespace AdoDisconnected
{
    internal class Program
    {
        public static void GotoContact()
        {
            ContactLayer cl = new ContactLayer();
            while (true)
            {
                Console.WriteLine("\n\nWhat you want to do? \n1: Want to Add contact to the AdressBook \n2: Want to Update contact to the AdressBook \n3: Want to Search person by their First Name \n4: Want to Delete contact to the AdressBook \n5: Display all persons\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 0)
                {
                    Console.WriteLine("\nExiting from System");
                    break;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Contact Details");
                        Console.Write("Enter First Name: ");
                        string firstName = Console.ReadLine();


                        Console.Write("Enter Last Name: ");
                        string lastName = Console.ReadLine();

                        Console.Write("Enter Address: ");
                        string address = Console.ReadLine();

                        Console.Write("Enter City: ");
                        string city = Console.ReadLine();

                        Console.Write("Enter State: ");
                        string state = Console.ReadLine(); ;

                        Console.Write("Enter Zip: ");
                        string zip = Console.ReadLine();

                        Console.Write("Enter PhoneNumber: ");
                        string phone = Console.ReadLine();

                        Console.Write("Enter email: ");
                        string email = Console.ReadLine();

                        Console.Write("Enter Book Name: ");
                        string bookName = Console.ReadLine();

                        Contact c = new Contact(firstName, lastName, address, city, state, zip, phone, email, bookName);
                        cl.Insert(c);
                        break;

                    case 2:
                        Console.WriteLine("Enter FirstName to Update");
                        string FName= Console.ReadLine();

                        Console.WriteLine("Enter Contact Details for Updating");
                        Console.Write("Enter First Name: ");
                        string firstName2 = Console.ReadLine();

                        Console.Write("Enter Last Name: ");
                        string lastName2 = Console.ReadLine();

                        Console.Write("Enter Address: ");
                        string address2 = Console.ReadLine();

                        Console.Write("Enter City: ");
                        string city2 = Console.ReadLine();

                        Console.Write("Enter State: ");
                        string state2 = Console.ReadLine(); ;

                        Console.Write("Enter Zip: ");
                        string zip2 = Console.ReadLine();

                        Console.Write("Enter PhoneNumber: ");
                        string phone2 = Console.ReadLine();

                        Console.Write("Enter email: ");
                        string email2 = Console.ReadLine();

                        Console.Write("Enter Book Name: ");
                        string bookName2 = Console.ReadLine();

                        Contact c2 = new Contact(firstName2, lastName2, address2, city2, state2, zip2, phone2, email2, bookName2);
                        cl.Update(FName, c2);
                        break;

                    case 3:
                        Console.WriteLine("Enter name to search");
                        cl.DisplayByName(Console.ReadLine());
                        break;

                    case 4:
                        Console.WriteLine("Enter First Name to delete the data");
                        cl.delete(Console.ReadLine());
                        break;

                    case 5:
                        cl.DisplayAll();
                        break;

                    default:
                        Console.WriteLine("Enter Valid Choice");
                        break;

                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Address Book");
            GotoContact();
        }
    }
}