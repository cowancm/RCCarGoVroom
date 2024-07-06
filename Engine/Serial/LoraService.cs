using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Vroom.Engine.Events;

namespace Vroom.Engine.Serial
{
    public class LoraService

    {
        public string NetworkID { get; set; }
        public string OtherNetworkID { get; set; }

        public bool isRepeater;
        public COM_TX_RX_Serializer Serializer { get; set; }

        public LoraService(string networkID, string OtherNetworkID, ref COM_TX_RX_Serializer serializer) 
        {
            NetworkID = networkID;
            Serializer = serializer;
        }

        public void RequestGPSFromOtherLORA()
        {
            SendToLORA("G");
        }

        public void RequestSpeedFromOtherLORA()
        {
            SendToLORA("S");
        }

        public void SendMovementDataToGoVroom(MovementEvent e)
        {
            string mainDirection;

            if (e.IsFoward)
                mainDirection = "F";
            else
                mainDirection = "B";

            SendToLORA($"{mainDirection},{e.Angle}");
        }

        private void SendToLORA(string msg) 
        {
            var numBytes = msg.Length;
            Serializer.WriteToPort($"AT+={OtherNetworkID},{numBytes},{msg}");
        }

    }
}
