using ServerAtteck;
using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Threading;
using WebSocketSharp.Server;
namespace ServerAtteck
{


   
    class Program    
    {
        static void Main(string[] args)
        {
            ConcurrentQueue<Missile> missileQueue = new ConcurrentQueue<Missile>();




            WebSocketServer wss = new WebSocketServer("ws://localhost:3108");
            wss.AddWebSocketService<MissileHandler>("/MissileHandler", () => new MissileHandler(wss , missileQueue));
            wss.Start();
            Console.WriteLine("Backend server is running. Press Enter to exit...");
            Console.ReadLine();
            wss.Stop();
           
        }
    }


}

