using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.AccessControl;

namespace Connections
{
    internal class Program
    {
        private static Network network;
        
        public static void Main(string[] args)
        {
            var option = "0";

            Console.WriteLine("Hello, welcome to the connections project!\n" +
                              "In this project we give you a network with a number of elements of your choice, make " +
                              "connections between them and let you check the existence (or not) of connections.\n" +
                              "\n");
            while (parseInt(option) != 4)
            {
                Console.WriteLine("Please choose one of the following options:\n" +
                                  "1 - Create a new network;\n" +
                                  "2 - Make a new connection;\n" +
                                  "3 - Check for the existence of a connection;\n" +
                                  "4 - Exit.");

                option = Console.ReadLine();

                try
                {
                    var elem = 0;
                    switch (parseInt(option))
                    {
                        case 1:
                            Console.WriteLine("Inform the number of desired elements for the network: ");
                            network = new Network(parseInt(Console.ReadLine()));
                            break;
                        case 2:
                            Console.WriteLine("Inform the first element of the connection: ");
                            elem = parseInt(Console.ReadLine());
                            Console.WriteLine("Inform the second element of the connection: ");
                            network.Connect(elem, parseInt(Console.ReadLine()));
                            Console.WriteLine("The connection was successfully created!");
                            break;
                        case 3:
                            Console.WriteLine("Inform the first element of the connection: ");
                            elem = parseInt(Console.ReadLine());
                            Console.WriteLine("Inform the second element of the connection: ");
                            if (network.Query(elem, parseInt(Console.ReadLine())))
                            {
                                Console.WriteLine("The connection exists!");
                            }
                            else
                            {
                                Console.WriteLine("The connection doesn't exist!");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Goodbye");
                            break;
                        default:
                            Console.WriteLine("Your choice of operation is not in the list");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    option = "0";
                }
            }
        }
        
        private static int parseInt(string value)
        {
            var valueInt = 0;
            
            if (!int.TryParse(value, out valueInt)) throw new Exception("The informed value is not a number.");
            
            return valueInt;
        }
    }
}