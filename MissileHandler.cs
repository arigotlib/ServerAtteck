using ServerAtteck;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
namespace ServerAtteck
{
    internal class MissileHandler : WebSocketBehavior
    {
        private readonly WebSocketServer _wss;
        private readonly ConcurrentQueue<Missile> _missileQueue;
        public MissileHandler(WebSocketServer wss, ConcurrentQueue<Missile> missileQueue)
        {
            this._wss = wss;
            this._missileQueue = missileQueue;
        }
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine(e.Data);
            Missile missile = JsonSerializer.Deserialize<Missile>(e.Data);
            this._missileQueue.Enqueue(missile);
        }
        public void BroadcastStatus(string message)
        {
            this._wss.WebSocketServices["MissileHandler"].Sessions.Broadcast(message);
        }
    }
}
