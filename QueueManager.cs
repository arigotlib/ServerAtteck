using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebSocketSharp.Server;
using System.Threading;
using ServerAtteck;
using System.Collections.Generic;
namespace  ServerAtteck

{
    public class QueueManager
    {
        private readonly WebSocketServer _wss;
        private readonly ConcurrentQueue<Missile> _missileQueue;
        private readonly SemaphoreSlim _ironDomeSemaphore;

        static int ironDomAmount = 4;

        public QueueManager(Queue<Missile> missileQueue, WebSocketServer wss)
        {
            this._missileQueue.TryDequeue(out Missile missileToIntercept);
            
            this._wss = wss;
            this._ironDomeSemaphore = new SemaphoreSlim(ironDomAmount);
        }


        public void Start()
        {

            int ironDomeAmount = 4;
            for (int i = 0; i < ironDomeAmount; i++) {
                var interceptorThread = new Thread(()=>Interceptor(i.ToString()));
                interceptorThread.Start();
            }

        }

        public async void Interceptor(string name)
        {
            IronDome ironDome = new IronDome();
            while (true)
            {
                if (this._missileQueue.TryDequeue(out Missile missileToIntercept)) { 
                    bool result = await ironDome.handleMissile(missileToIntercept);
                    var message = new { intercepted = result, missileName = missileToIntercept.Name };
                    var json = JsonSerializer.Serialize(message);
                    this._wss.WebSocketServices["/MissileHanlder"].Sessions.Broadcast(json);
                }
                this._ironDomeSemaphore.Release();
            }
        }
    }
}