using System;
using System.Text;
using Papouch.Communication;

namespace Papouch.Spinel.Spinel97.Device.Tds
{
    public class Tds : Device
    {
        public byte S97_INST_TDS_GetTemperature = 0x51;         // Čtení teploty
        public byte S97_INST_TDS_SetDateTime = 0x70;            // Nastavení data a času
        public byte S97_INST_TDS_GetDateTime = 0x71;            // Čtení data a času
        public byte S97_INST_TDS_SetBrightnessManual = 0x93;    // Nastavení jasu manuálně
        public byte S97_INST_TDS_SetBrightnessAuto = 0x95;      // Nastavení jasu automaticky
        public byte S97_INST_TDS_SetDataValidity = 0x94;        // Nastavení délky zobrazení
        public byte S97_INST_TDS_SetDataAscii = 0x90;           // Zápis znaků na displej
        public byte S97_INST_TDS_SetDataBin = 0x91;             // Zápis binárních dat na displej
        public byte S97_INST_TDS_SetFlags = 0x76;               // Nastavení parametrů času a zobrazení
        public byte S97_INST_TDS_SetAutoInfo = 0x78;            // Vynutit zobrazení automatických informací
        public byte S97_INST_TDS_GetInputs = 0x31;              // Vynutit zobrazení automatických informací

        public Tds(ICommunicationInterface ci, byte spinelADR) : base(ci, spinelADR)
        {

        }

        /// <summary>
        /// Zjistí počet segmentovek, vstupů a teplotních senzorů.
        /// </summary>
        /// <param name="SegCount">Počet znakovek.</param>
        /// <param name="InCount">Počet vstupů.</param>
        /// <param name="SnsCount">Počet teplotních senzorů.</param>
        /// <returns></returns>
        public bool CmdGetHwInfo(out int SegCount, out int InCount, out int SnsCount)
        {
            SegCount = -1;
            InCount = -1;
            SnsCount = -1;

            byte[] data = { 0x01 };

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_ReadInfo, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if ((SendAndReceive(ref txPacket, out rxPacket)) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
            {
                if ((rxPacket.SDATA != null) && (rxPacket.SDATA.Length == 5))
                {
                    SegCount = rxPacket.SDATA[0];
                    InCount = rxPacket.SDATA[2];
                    SnsCount = rxPacket.SDATA[4];
                    return true;
                }
            }
            return false;

        }

        /// <summary>
        /// Čtení teploty z teplotního senzoru
        /// </summary>
        /// <param name="temp">Aktuálně naměřená teplota. Pokud z nějakého důvodu není dostupná, je zde konstanta float.NaN.</param>
        /// <returns>Výčet <see cref="ResponseACK"/>.</returns>
        public ResponseACK CmdGetTemperature(out float temp)
        {
            byte[] data = { 0x01 };

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_TDS_GetTemperature, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if (SendAndReceive(ref txPacket, out rxPacket))
            {
                if (rxPacket.INST == (byte)ResponseACK.AllIsOk)
                {
                    if ((rxPacket.SDATA != null) && (rxPacket.SDATA.Length == 3))
                    {
                        temp = (float)(rxPacket.SDATA[1] * 256 + rxPacket.SDATA[2]) / 10;
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

        /// <summary>
        /// Nastavit datum a čas na aktuální čas ve Windows.
        /// </summary>
        /// <returns></returns>
        public bool CmdSetDateTime()
        {
            return CmdSetDateTime(DateTime.Now);
        }

        /// <summary>
        /// Nastavit datum a čas na zadaný čas.
        /// </summary>
        /// <param name="date">Datum a čas, které se má nastavit do displeje.</param>
        /// <returns></returns>
        public bool CmdSetDateTime(DateTime date)
        {
            byte yy = (byte)(date.Year % 100);
            byte[] data = { (byte)date.Hour, (byte)date.Minute, (byte)date.Second, (byte)date.Day, (byte)date.Month, yy };

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_TDS_SetDateTime, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if ((SendAndReceive(ref txPacket, out rxPacket)) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
                return true;
            else
                return false;

        }

        /// <summary>
        /// Přečte datum a čas z displeje.
        /// </summary>
        /// <param name="date">Datum a čas ze zařízení.</param>
        /// <returns></returns>
        public bool CmdGetDateTime(out DateTime date)
        {
            byte[] data = {  };

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_TDS_GetDateTime, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if ((SendAndReceive(ref txPacket, out rxPacket)) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
            {
                if ((rxPacket.SDATA != null) && (rxPacket.SDATA.Length == 7))
                {
                    date = new DateTime();
                    date = date.AddHours(rxPacket.SDATA[0]);
                    date = date.AddMinutes(rxPacket.SDATA[1]);
                    date = date.AddSeconds(rxPacket.SDATA[2]);
                    date = date.AddDays(rxPacket.SDATA[4] - 1);
                    date = date.AddMonths(rxPacket.SDATA[5] - 1);

                    int yy = DateTime.Now.Year - (DateTime.Now.Year % 100) + (rxPacket.SDATA[6] - 1);
                    date = date.AddYears(yy);

                    return true;
                }
            }

            date = DateTime.MinValue;
            return false;

        }


        /// <summary>
        /// Manuální nastavení jasu displeje.
        /// </summary>
        /// <param name="brightness">Rozsah 0 až 36.</param>
        /// <returns></returns>
        public bool CmdSetBrightnessManual(byte brightness)
        {
            if ((brightness > 36) || (brightness < 0)) return false;

            byte[] data = { brightness };

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_TDS_SetBrightnessManual, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if ((SendAndReceive(ref txPacket, out rxPacket)) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
                return true;
            else
                return false;

        }

        /// <summary>
        /// Ovládání automatického nastavování jasu displeje.
        /// </summary>
        /// <param name="enable">Automtika zapnuta = true.</param>
        /// <param name="min">Minimální jas na který může automatika jít (rozsah 6-36).</param>
        /// <param name="max">Maximální jas na který může automatika jít (rozsah 6-36).</param>
        /// <returns></returns>
        public bool CmdSetBrightnessAuto(bool enable, byte min, byte max)
        {
            if ((min > 36) || (min < 6)) return false;
            if ((max > 36) || (max < 6)) return false;

            byte[] data = { Convert.ToByte(enable), min, max, 0 };

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_TDS_SetBrightnessAuto, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if ((SendAndReceive(ref txPacket, out rxPacket)) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
                return true;
            else
                return false;

        }

        /// <summary>
        /// Nastaví platnost dat na displeji.
        /// </summary>
        /// <param name="sec">Doba platnosti ve vteřinách (max. 65535).</param>
        /// <returns></returns>
        public bool CmdSetDataValidity(UInt16 sec)
        {
            byte[] data = { (byte)(sec >> 8), (byte)sec };

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_TDS_SetDataValidity, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if ((SendAndReceive(ref txPacket, out rxPacket)) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
                return true;
            else
                return false;

        }

        /// <summary>
        /// Zobrazení dat na displeji - vstupem je string.
        /// </summary>
        /// <param name="ascii"></param>
        /// <returns></returns>
        public bool CmdSetDataAscii(string ascii)
        {

            byte[] data = Encoding.UTF8.GetBytes(ascii);

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_TDS_SetDataAscii, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if ((SendAndReceive(ref txPacket, out rxPacket)) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
                return true;
            else
                return false;

        }

        /// <summary>
        /// Představuje jednotlivé segmenty znakovky.
        /// </summary>
        [Flags]
        public enum SevenSeg : byte
        {
            a = 1,
            b = 2,
            c = 4,
            d = 8,
            e = 16,
            f = 32,
            g = 64,
            dp = 128
        }

        /// <summary>
        /// Zobrazení dat na displeji - vstupem je pole bytů. První byte jsou kontrolky.
        /// </summary>
        /// <param name="data">Binární data k zobrazení. První byte jsou kontrolky. Délka musí být počet segmentovek + 1.</param>
        /// <returns></returns>
        public bool CmdSetDataBin(byte[] data)
        {

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_TDS_SetDataBin, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if ((SendAndReceive(ref txPacket, out rxPacket)) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
                return true;
            else
                return false;

        }


        /// <summary>
        /// Parametry instrukce Nastavení parametrů času a zobrazení.
        /// </summary>
        [Flags]
        public enum SetFlags : UInt16
        {
            AutoSummerTime = 1,
            ShowAutoOnPowerUp = 4,
            ShowAutoAfterTimeout = 8,
            HoursMode12 = 16,
            ShowMonthFirst = 32,
            ShowTimeInAutoItems = 256,
            ShowDateInAutoItems = 512,
            ShowTemperatureInAutoItems = 1024
        }

        /// <summary>
        /// Nastavení parametrů času a zobrazení.
        /// </summary>
        /// <param name="flags">Parametry složené ze <see cref="SetFlags"/>.</param>
        /// <param name="offset">Posun oproti UTC v minutách (jen pro TDS ETH).</param>
        /// <param name="zone">Identifikátor časové zóny (jen pro TDS ETH).</param>
        /// <returns></returns>
        public bool CmdSetFlags(UInt16 flags, UInt16 offset, UInt16 zone = 0)
        {

            byte[] data = { (byte)(flags >> 8), (byte)flags, (byte)(offset >> 8), (byte)offset, (byte)(zone >> 8), (byte)zone };

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_TDS_SetFlags, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if ((SendAndReceive(ref txPacket, out rxPacket)) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
                return true;
            else
                return false;

        }

        /// <summary>
        /// Vynutit zobrazení automatických informací pokud není nastavena platnost dat.
        /// </summary>
        /// <returns></returns>
        public bool CmdSetAutoInfo()
        {

            byte[] data = {  };

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_TDS_SetAutoInfo, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if ((SendAndReceive(ref txPacket, out rxPacket)) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
                return true;
            else
                return false;

        }

        /// <summary>
        /// Přečte stavy binárních vstupů.
        /// </summary>
        /// <param name="inputs">Pole 4 bytů se stavem vstupů. MSB je IN1. V každém bajtu je LSb (bit 0) aktuální stav vstupu. Bit 1 je v jedničce pokud byl od posledního čtení zaznamenána na vstupu úroveň 1 (stisk tlačítka).</param>
        /// <returns></returns>
        public bool CmdGetInputs(out byte[] inputs)
        {
            
            inputs = new byte[4];
            byte[] data = { };

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_TDS_GetInputs, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if ((SendAndReceive(ref txPacket, out rxPacket)) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
            {
                if ((rxPacket.SDATA != null) && (rxPacket.SDATA.Length == 4))
                {
                    inputs = rxPacket.SDATA;
                    return true;
                }
            }
            return false;

        }


    }
}
