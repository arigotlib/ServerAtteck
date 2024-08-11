using ServerAtteck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerAtteck
{
    internal class IronDome
    {
        public async Task<bool> handleMissile(Missile missile)
        {
            string time = missile.Time.ToString();
            await Task.Delay(int.Parse(time) * 1000);

            Random random = new Random();
            bool intercepted = random.Next(0, 2) == 1;
            return intercepted;

        }
    }
}