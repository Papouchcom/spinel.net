using System;

using Papouch;
using Papouch.Spinel;
using Papouch.Communication;

namespace Papouch.Spinel.Spinel97
{
    
    public class PacketSpinel97
    {
        public byte PRE;
        public byte FRM;
        public UInt16 LEN;
        public byte ADR;
        public byte SIG;
        public byte INST;
        public byte[] SDATA;
        public byte SUM;
        public byte CR;

        private void RecountLEN()
        {
            LEN = 5;
            
            if (SDATA != null)
            {
                LEN += (UInt16)SDATA.Length;
            }
        }

        private void RecountSUM()
        {
            int crc = PRE + FRM + (LEN / 0x100) + (LEN % 0x100) + ADR + SIG + INST;
            if (SDATA != null)
            {
                foreach (byte b in SDATA)
                {
                    crc += b;
                }
            }
            SUM = (byte)(0xFF - (crc % 0x100));
        }

        private void Initialize(bool full_clear)
        {
            PRE = 0x2A;     // "*"
            FRM = 0x61;     // "a" (dec:97)
            CR  = 0x0D;

            if (full_clear)
            {
                ADR = 0xFE;     // univerzální adresa (broadcast)
                SIG = 0x00;
                INST = 0xF3;    // INFO 
                SDATA = null;
            }
        }

        public PacketSpinel97()
        {
            Initialize(true);
            RecountLEN();
            RecountSUM();
        }

        public PacketSpinel97(byte INST)
        {
            Initialize(true);
            this.INST = INST;
            RecountLEN();
            RecountSUM();
        }

        public PacketSpinel97(byte INST, byte[] SDATA)
        {
            Initialize(true);
            this.INST = INST;
            this.SDATA = SDATA;
            RecountLEN();
            RecountSUM();
        }

        public PacketSpinel97(byte INST, byte SIG)
        {
            Initialize(true);
            this.INST = INST;
            this.SIG = SIG;
            RecountLEN();
            RecountSUM();
        }

        public PacketSpinel97(byte INST, byte SIG, byte[] SDATA)
        {
            Initialize(true);
            this.INST = INST;
            this.SIG = SIG;
            this.SDATA = SDATA;
            RecountLEN();
            RecountSUM();
        }

        public byte[] GetBin()
        {
            RecountLEN();
            RecountSUM();
            
            byte[] result = new byte[LEN + 4];
            result[0] = PRE;
            result[1] = FRM;
            result[2] = (byte)(LEN / 0x100);
            result[3] = (byte)(LEN % 0x100);
            result[4] = ADR;
            result[5] = SIG;
            result[6] = INST;

            if (SDATA != null)
            {
                Array.Copy(SDATA, 0, result, 7, SDATA.Length);
            }

            result[result.Length - 2] = SUM;
            result[result.Length - 1] = CR;
            return result;
        }
    }
/*
        public static byte CalculateCRCFromPacket(byte[] buffer, int packetPos, int packetLen)
        {
            if (packetLen < 2) throw new Exception("Packet length is less than is requested");
            byte suma = 0xFF;
            for (int I = packetPos; I < (packetPos + packetLen - 2); I++)
                suma -= buffer[I];
            return suma;
        }
    */





}