using System;
using Papouch.Communication;

namespace Papouch.Spinel.Spinel97.Device.Tqs
{
    public class Tqs : Device
    {
        public byte S97_INST_TQS_GetTemperature = 0x51;     // Čtení teploty

        public Tqs(ICommunicationInterface ci, byte spinelADR) : base(ci, spinelADR)
        {

        }

        /// <summary>
        /// Čtení teploty z teplotního senzoru
        /// </summary>
        /// <param name="temp">Aktuálně naměřená teplota. Pokud z nějakého důvodu není dostupná, je zde konstanta float.NaN.</param>
        /// <returns>Výčet <see cref="ResponseACK"/>.</returns>
        public ResponseACK CmdGetTemperature(out float temp)
        {
            byte[] data = {};

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_TQS_GetTemperature, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if (SendAndReceive(ref txPacket, out rxPacket))
            {
                if (rxPacket.INST == (byte)ResponseACK.AllIsOk)
                {
                    if ((rxPacket.SDATA != null) && (rxPacket.SDATA.Length == 2))
                    {
                        temp = (float)(rxPacket.SDATA[0] * 256 + rxPacket.SDATA[1]) / 32;
                        return ResponseACK.AllIsOk;
                    }
                }
                else
                {
                    temp = float.NaN;
                    return (ResponseACK)rxPacket.INST;
                }
            }
            temp = float.NaN;
            return ResponseACK.OtherCommError;
        }

    }
}
