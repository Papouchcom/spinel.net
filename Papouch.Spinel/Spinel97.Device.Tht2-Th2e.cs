using System;
using Papouch.Communication;

namespace Papouch.Spinel.Spinel97.Device.Tht2Th2e
{
    public class Tht2Th2e : Device
    {
        public const byte S97_INST_Tht2Th2e_GetMeasure = 0x51;          // Měření
        public const byte S97_INST_Tht2Th2e_GetSensorType = 0xB1;       // Zjistění typu senzoru (zjišťuje se při zapnutí/resetu)

        public Tht2Th2e(ICommunicationInterface ci, byte spinelADR) : base(ci, spinelADR)
        {

        }

        /// <summary>
        /// Popisuje status naměřeného údaje. Určuje zda je platný, v mezích, apod.
        /// </summary>
        [Flags]
        public enum FlagsStatus : byte
        {
            None = 0,
            UnderLimit = 1 << 0,   // 1
            OverLimit  = 1 << 1,   // 2
            UnderFlow  = 1 << 2,   // 4
            OverFlow   = 1 << 3,   // 8
            Valid      = 1 << 7    // 128
        }

        /// <summary>
        /// Naměřené hodnoty ze senzoru. Obsahuje jak samotné hodnoty, tak i <see cref="FlagsStatus"/> popisující status veličiny (zda je platná, mimo limit, apod.)
        /// </summary>
        public class MeasuredValues
        {
            public FlagsStatus TemperatureStatus;
            public float Temperature;
            public FlagsStatus HumidityStatus;
            public float Humidity;
            public FlagsStatus DewPointStatus;
            public float DewPoint;

            public MeasuredValues()
            {
                TemperatureStatus = FlagsStatus.None;
                Temperature = float.NaN;
                HumidityStatus = FlagsStatus.None;
                Humidity = float.NaN;
                DewPointStatus = FlagsStatus.None;
                DewPoint = float.NaN;
            }
        }

        /// <summary>
        /// Výčet typů měřených veličin
        /// </summary>
        private enum QuantityType : byte
        {
            Temperature = 0x01,
            Humidity = 0x02,
            DewPoint = 0x03
        }

        /// <summary>
        /// Najde v odpověďi sekci odpovídající hledané veličině. (Veličiny mají svoje id a nejsou dané pořadím.)
        /// </summary>
        /// <param name="type">Typ hledané veličiny.</param>
        /// <param name="sdata">Pole přijatých sdat.</param>
        /// <returns></returns>
        private int FindSectionById(QuantityType type, ref byte[] sdata)
        {
            for (int i = 0; i < sdata.Length; i=i+4)
            {
                if (sdata[i] == (byte)type) return i;
            }
            return -1;
        }

        /// <summary>
        /// Měření aktuálních hodnot
        /// </summary>
        /// <param name="values">Třída se statusy a hodnotami jednotlivých veličin.</param>
        /// <returns>Výčet <see cref="ResponseACK"/>.</returns>
        public ResponseACK CmdGetMeasure(out MeasuredValues values)
        {
            values = new MeasuredValues();
            byte[] data = { 0x00 };

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_Tht2Th2e_GetMeasure, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if (SendAndReceive(ref txPacket, out rxPacket))
            {
                if (rxPacket.INST == (byte)ResponseACK.AllIsOk)
                {
                    if ((rxPacket.SDATA != null) && (rxPacket.SDATA.Length > 0) && (rxPacket.SDATA.Length % 4 == 0))
                    {
                        int SectionIndex = FindSectionById(QuantityType.Temperature, ref rxPacket.SDATA);
                        if (SectionIndex > -1)
                        {
                            values.TemperatureStatus = (FlagsStatus)rxPacket.SDATA[SectionIndex + 1];
                            values.Temperature = (float)(rxPacket.SDATA[SectionIndex + 2] * 256 + rxPacket.SDATA[SectionIndex + 3]) / 10;
                        }

                        SectionIndex = FindSectionById(QuantityType.DewPoint, ref rxPacket.SDATA);
                        if (SectionIndex > -1)
                        {
                            values.DewPointStatus = (FlagsStatus)rxPacket.SDATA[SectionIndex + 1];
                            values.DewPoint = (float)(rxPacket.SDATA[SectionIndex + 2] * 256 + rxPacket.SDATA[SectionIndex + 3]) / 10;
                        }

                        SectionIndex = FindSectionById(QuantityType.Humidity, ref rxPacket.SDATA);
                        if (SectionIndex > -1)
                        {
                            values.HumidityStatus = (FlagsStatus)rxPacket.SDATA[SectionIndex + 1];
                            values.Humidity = (float)(rxPacket.SDATA[SectionIndex + 2] * 256 + rxPacket.SDATA[SectionIndex + 3]) / 10;
                        }

                        if ((int)values.TemperatureStatus + (int)values.TemperatureStatus + (int)values.DewPointStatus > 0)
                            return ResponseACK.AllIsOk;
                    }
                }
                else
                {
                    return (ResponseACK)rxPacket.INST;
                }
            }
            return ResponseACK.OtherCommError;
        }

        /// <summary>
        /// Výčet typů senzorů.
        /// </summary>
        public enum SensorType : byte
        {
            None = 0,
            TH15 = 0x01,
            DS = 0x02,
            TH3X = 0x03,
            TMP = 0x04,
            Other = 0xFF
        }

        /// <summary>
        /// Vrací typ aktuálně nastaveného senzoru. (Nejedná se o autodetekci typu aktuálně připojeného senzoru. Typ senzoru se detekuje jen při zapnutí.)
        /// </summary>
        /// <param name="sensor">Typ senzoru detekovaného při zapnutí.</param>
        /// <returns>Výčet <see cref="ResponseACK"/>.</returns>
        public ResponseACK CmdGetSensorType(out SensorType sensor)
        {
            byte[] data = { };
            sensor = SensorType.Other;

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_Tht2Th2e_GetSensorType, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if (SendAndReceive(ref txPacket, out rxPacket))
            {
                if (rxPacket.INST == (byte)ResponseACK.AllIsOk)
                {
                    if ((rxPacket.SDATA != null) && (rxPacket.SDATA.Length == 1))
                    {
                        if (rxPacket.SDATA[0] <= 4)
                            sensor = (SensorType)(rxPacket.SDATA[0]);
                        return ResponseACK.AllIsOk;
                    }
                }
                else
                {
                    return (ResponseACK)rxPacket.INST;
                }
            }
            return ResponseACK.OtherCommError;
        }


    }
}
