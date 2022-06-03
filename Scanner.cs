using System;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        private static string IP = "";
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("    Port Scanner Created by Mujtaba  ");
            Console.WriteLine("Please Choose Your Scan Type Fast Or Deep");

            Console.WriteLine("=================================================");

            Console.WriteLine("Press 1  For Fast Scan");
            Console.WriteLine("Press 2  For Deep Scan ");
            int chose = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (chose)
            {
                case 1:
                    {
                        UserInput();
                        FastScan();
                    }
                    break;
                case 2:
                    {
                        UserInput();
                        DeepScan();
                    }
                    break;

                default:
                    Console.WriteLine("Invalid Choose");
                    break;
            }

           
            Console.ReadKey();
        }
        private static void UserInput()   // This Function to set the IP you want scannig
        {
            Console.WriteLine("IP Address:", Console.ForegroundColor = ConsoleColor.Cyan);
            IP = Console.ReadLine();
        }

        private static void FastScan()   // Fast scanning User Input
        {
            Console.Clear();
            using (TcpClient Scan = new TcpClient())
            {

                foreach (int s in Ports)
                {
                    try
                    {
                        Scan.Connect(IP, s);
                        Thread.Sleep(100);
                        Console.WriteLine($"[{s}] | OPEN", Console.ForegroundColor = ConsoleColor.Green);
                    }
                    catch
                    {
                        Thread.Sleep(100);
                        Console.WriteLine($"[{s}] | CLOSED", Console.ForegroundColor = ConsoleColor.Red);
                    }
                }
            }

        }
        private static void DeepScan()  // Deep scanning for scan all ports of Host
        {
            Console.Clear();
            using (TcpClient Scan = new TcpClient())
            {

                foreach (int s in Port())
                {
                    try
                    {
                        Scan.Connect(IP, s);
                        Thread.Sleep(100);
                        Console.WriteLine($"[{s}] | OPEN", Console.ForegroundColor = ConsoleColor.Green);
                    }
                    catch
                    {
                        Thread.Sleep(100);
                        Console.WriteLine($"[{s}] | CLOSED", Console.ForegroundColor = ConsoleColor.Red);
                    }
                }
            }

        }

        private static int[] Ports = new int[]  // this property to apply Fast scan function 
        {
            8080,
            445,
            51372,
            53,
            23,
            31146,
             135,
            4145,
            5272
        };
        private static int[] Port()     // this Function to apply Deep scan function
        {
            var Ports = new int[65535];

            for (int i = 0; i < Ports.Length; i++)
            {
                Ports[i] = Ports[i] + i;
            }

            return Ports;
        }


    }
}