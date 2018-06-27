using System;
using System.Diagnostics;
using Papouch.Spinel.Spinel97;
using Papouch.Communication;
using System.Collections.Generic;

namespace Papouch.Spinel.Spinel97.Device.Quido
{
    public class Quido:Device
    {
        public byte S97_INST_QUIDO_GetInputs            = 0x31;     // Čtení stavu vstupů
        public byte S97_INST_QUIDO_SetAutoNotify        = 0x10;     // Nastavení samovolného vysílání
        public byte S97_INST_QUIDO_GetAutoNotify        = 0x11;     // Čtení nastavení samovolného vysílání
        public byte S97_INST_QUIDO_GetCounter           = 0x60;     // Čtení čítačů
        public byte S97_INST_QUIDO_SetCounterSettings   = 0x6A;     // Nastavení čítačů
        public byte S97_INST_QUIDO_GetCounterSettings   = 0x6B;     // Čtení nastavení čítačů
        public byte S97_INST_QUIDO_SetOutput            = 0x20;     // Nastavení výstupů
        public byte S97_INST_QUIDO_SetOutputTimered     = 0x23;     // Nastavení výstupů na určitou dobu
        public byte S97_INST_QUIDO_GetOutputs           = 0x30;     // Čtení výstupů
        public byte S97_INST_QUIDO_GetTemperature       = 0x51;     // Čtení teploty

        public int InputCount = -1;                                 // Počet vstupů Quida
        public int OutputCount = -1;                                // Počet výstupů Quida

        public Quido(ICommunicationInterface ci, byte spinelADR)
            : base(ci, spinelADR)
        {
            
        }

        [Obsolete("Use method \"CmdSetOutput()\"")]
        public Boolean CmdSetRele(byte rele, Boolean value, byte timer = 0)
        {
            return CmdSetOutput(rele, value, timer);
        }

        /// <summary>
        ///     Nastavení výstupu
        /// </summary>
        /// <param name="outid">výstup (indexováno od 1)</param>
        /// <param name="value">požadovaný stav</param>
        /// <param name="timer">čas po který bude výstup nastaven do požadovaného stavu, poté dojde ke změně na opačný stav. ( 1-255 * 0.5s )</param>
        /// <returns>vrací True v případě potvrzení příkazu modulem</returns>
        public Boolean CmdSetOutput(byte outid, Boolean value, byte timer = 0)
        {
            PacketSpinel97 txPacket = new PacketSpinel97();
            byte[] data;

            if (timer == 0)
            {
                txPacket.INST = S97_INST_QUIDO_SetOutput;

                data = new byte[1];
                data[0] = (byte)(((value) ? 0x80 : 0x00) | (outid & 0x7F));

            } else {

                txPacket.INST = S97_INST_QUIDO_SetOutputTimered;

                data = new byte[2];
                data[0] = timer;
                data[1] = (byte)(((value) ? 0x80 : 0x00) | (outid & 0x7F));
            }

            txPacket.ADR = this.ADR;

            txPacket.SDATA = data;

            PacketSpinel97 rxPacket;

            if (this.SendAndReceive(ref txPacket, out rxPacket) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Definuje stav jednoho výstupu. Obsahuje id výstupu (OUT1 = 1) a jeho stav (state) jako true/false.
        /// </summary>
        public struct OutputState
        {
            /// <summary>
            /// Číslo výstupu. OUT1 = 1.
            /// </summary>
            public byte id;
            /// <summary>
            /// SET = true
            /// </summary>
            public bool state;

            /// <summary>
            /// Inicializuje strukturu id výstupu a stavem.
            /// </summary>
            /// <param name="outid">Číslo výstupu. OUT1 = 1.</param>
            /// <param name="outstate">SET = true</param>
            public OutputState(byte outid, bool outstate)
            {
                id = outid;
                state = outstate;
            }
        }

        /// <summary>
        /// Nastavení více výstupů najednou. Může obsahovat nastavení jednoho nebo až všech výstupů do požadovaného stavu. Stav může být pro každý výstup jiný.
        /// </summary>
        /// <param name="outs">List struktur <see cref="OutputState"/>. (Obsahují byte číslo výstupu a bool stav výstupu.)</param>
        /// <param name="timer">čas po který bude výstup nastaven do požadovaného stavu, poté dojde ke změně na opačný stav. ( 1-255 * 0.5s )</param>
        /// <returns>vrací True v případě potvrzení příkazu modulem</returns>
        public Boolean CmdSetOutputs(List<OutputState> outs, byte timer = 0)
        {
            PacketSpinel97 txPacket = new PacketSpinel97();
            byte[] data;

            if (outs.Count == 0) return false;

            if (timer == 0)
            {
                txPacket.INST = S97_INST_QUIDO_SetOutput;

                data = new byte[outs.Count];
                for (int i = 0; i < outs.Count; i++)
                {
                    data[i] = (byte)(((outs[i].state) ? 0x80 : 0x00) | (outs[i].id & 0x7F));
                }
            }
            else
            {
                txPacket.INST = S97_INST_QUIDO_SetOutputTimered;

                data = new byte[outs.Count + 1];
                data[0] = timer;
                for (int i = 0; i < outs.Count; i++)
                {
                    data[i+1] = (byte)(((outs[i].state) ? 0x80 : 0x00) | (outs[i].id & 0x7F));
                }
            }

            txPacket.ADR = this.ADR;

            txPacket.SDATA = data;

            PacketSpinel97 rxPacket;

            if (this.SendAndReceive(ref txPacket, out rxPacket) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
            {
                return true;
            }
            return false;

        }

        /// <summary>
        ///     Čtení stavu výstupů / relé
        /// </summary>
        /// <param name="outputs"></param>
        /// <returns>vrací True pokud je přijata a zpracována korektní odpověď</returns>
        public Boolean CmdGetOutputs(out Boolean[] outputs)
        {
            outputs = null;

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_QUIDO_GetOutputs);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if (SendAndReceive(ref txPacket, out rxPacket) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
            {
                if (rxPacket.SDATA != null)
                {
                    outputs = new Boolean[(InputCount > -1) ? InputCount : rxPacket.SDATA.Length * 8];

                    byte index = 0;
                    while ((index < outputs.Length) && ((index / 8) < rxPacket.SDATA.Length))
                    {
                        outputs[index] = (((rxPacket.SDATA[rxPacket.SDATA.Length - (index / 8) - 1]) & (1 << (index % 8))) != 0);
                        index++;
                    }

                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///     Čtení stavu vstupů
        /// </summary>
        /// <param name="inputs">pole logických stavů vstupů</param>
        /// <returns>vrací True pokud je přijata a zpracována korektní odpověď</returns>
        public Boolean CmdGetInputs(out Boolean[] inputs)
        {
            inputs = null;

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_QUIDO_GetInputs);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if (SendAndReceive(ref txPacket, out rxPacket) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
            {
                if (rxPacket.SDATA != null)
                {
                    inputs = new Boolean[(InputCount > -1) ? InputCount : rxPacket.SDATA.Length * 8];

                    byte index = 0;
                    while ((index < inputs.Length) && ((index / 8) < rxPacket.SDATA.Length))
                    {
                        inputs[index] = (((rxPacket.SDATA[rxPacket.SDATA.Length - (index / 8) - 1]) & (1 << (index % 8))) != 0);
                        index++;
                    }

                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///    Čtení čítače
        /// </summary>
        /// <param name="index">pořadové číslo vstupu/čítače (indexováno od 1)</param>
        /// <param name="counter">vrací přečtenou hodnotu čítače</param>
        /// <param name="erase">je-li true, dojde při přečten k nulování tohoto čítače</param>
        /// <returns>vrací True pokud je přijata a zpracována korektní odpověď</returns>
        public Boolean CmdGetCounter(byte index, out int counter, bool erase = false)
        {
            counter = 0;
            
            byte[] data = new byte[1];
            data[0] = (byte)( ( index & 0x7F ) | ( (erase) ? 0x80 : 0x00 ) );

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_QUIDO_GetCounter,data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if (SendAndReceive(ref txPacket, out rxPacket) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
            {
                if ((rxPacket.SDATA != null) && (rxPacket.SDATA.Length > 1))
                {
                    int len = rxPacket.SDATA[0];                                    // počet bitů counteru

                    int i = 1;
                    while ( (i <= (len / 8)) && ( i < rxPacket.SDATA.Length ) )
                    {
                        counter = ( ( counter * 0x100 ) + rxPacket.SDATA[i] );
                        i++;
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///    Nastavení čítače 
        /// </summary>
        /// <param name="index">pořadové číslo vstupu/čítače (indexováno od 1)</param>
        /// <param name="rising">čítač reaguje na náběžnou hranu</param>
        /// <param name="falling">čítač reaguje na sestupnou hranu</param>
        /// <returns>vrací True pokud modul potvrdí zpracování příkazu</returns>
        public Boolean CmdSetCounterSettings(byte index, bool rising, bool falling)
        {
            byte[] data = new byte[1];
            data[0] = (byte)((index & 0x3F) | ((rising) ? 0x80 : 0x00) | ((falling) ? 0x40 : 0x00));

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_QUIDO_SetCounterSettings, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if (SendAndReceive(ref txPacket, out rxPacket) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Čtení nastavení čítače
        /// </summary>
        /// <param name="index">pořadové číslo vstupu/čítače (indexováno od 1)</param>
        /// <param name="rising">čítač reaguje na náběžnou hranu</param>
        /// <param name="falling">čítač reaguje na sestupnou hranu</param>
        /// <returns>vrací True pokud je přijata a zpracována korektní odpověď</returns>
        public Boolean CmdGetCounterSettings(byte index, out bool rising, out bool falling)
        {
            byte[] data = new byte[1];
            data[0] = (byte)(index & 0x3F);

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_QUIDO_GetCounterSettings, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if (SendAndReceive(ref txPacket, out rxPacket) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
            {
                if ( (rxPacket.SDATA != null) && (rxPacket.SDATA.Length == 1) )
                {
                    rising = ((rxPacket.SDATA[0] & 0x80) != 0x00);
                    falling = ((rxPacket.SDATA[0] & 0x40) != 0x00);
                    return true;
                }
            }
            rising = false;
            falling = false;
            return false;
        }

        /// <summary>
        /// Čtení teploty z připojeného teplotního senzoru
        /// </summary>
        /// <param name="temp">Aktuálně naměřená teplota. Pokud z nějakého důvodu není dostupná, je zde konstanta float.NaN.</param>
        /// <param name="index">Číslo teploměru, číslováno od 1. Ve standardních Quidech je zde vždy 1.</param>
        /// <returns>Teplota v aktuálně nastavené teplotní jednotce.</returns>
        public Boolean CmdGetTemperature(out float temp, byte index = 0x01)
        {
            byte[] data = { index };

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_QUIDO_GetTemperature, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if (SendAndReceive(ref txPacket, out rxPacket) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
            {
                if ((rxPacket.SDATA != null) && (rxPacket.SDATA.Length == 3))
                {
                    temp = (float)(rxPacket.SDATA[1] * 256 + rxPacket.SDATA[2]) / 10;
                    return true;
                }
            }
            temp = float.NaN;
            return false;
        }

        /// <summary>
        ///     Nastavení samovolného vysílání
        /// </summary>
        /// <param name="enabled">je-li True, pak je samovolné vysílání aktivní</param>
        /// <returns>vrací True pokud je přijata a zpracována korektní odpověď</returns>
        public Boolean CmdGetAutoNotify(out byte format, out bool[] mask)
        {
            format = 0;
            mask = null;

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_QUIDO_GetAutoNotify);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if (SendAndReceive(ref txPacket, out rxPacket) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
            {
                if ( (rxPacket.SDATA != null) && (rxPacket.SDATA.Length > 1) )
                {
                   format = (rxPacket.SDATA[0]);

                   mask = new bool[8 * (rxPacket.SDATA.Length -1)];
 
                   for (int i=0; i<mask.Length; i++)
                   {
                       mask[i] = ((rxPacket.SDATA[(i / 8)+1] & (1 << (i % 8)))!=0);
                   }
                   return true;
                }
            }
            return false;
        }

        /// <summary>
        ///     Čtení nastavení samovolného vysílání
        /// </summary>
        /// <param name="enabled">je li True, pak je samovolné vysílání zapnuto</param>
        /// <returns>vrací True pokud je přijata a zpracována korektní odpověď</returns>
        public Boolean CmdSetAutoNotify(bool enabled)
        {
            byte[] data = new byte[1];
            data[0] = (byte)( (enabled) ? 0x01 : 0x00 );

            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_QUIDO_SetAutoNotify, data);
            txPacket.ADR = this.ADR;
            PacketSpinel97 rxPacket;

            if (SendAndReceive(ref txPacket, out rxPacket) && (rxPacket.INST == (byte)ResponseACK.AllIsOk))
            {
                return true;
            }
            return false;
        }

        public Boolean[] last_input_status = null;

        public override void PacketReceive(ref PacketSpinel97 packet)
        {
            base.PacketReceive(ref packet);

            if (packet.INST == 0x0D)
            {
                Debug.Print("Quido Autonotify Message");

                if ((OnInputsChange != null) || (OnInputChange != null))
                {
                    Boolean[] inputs = null;

                    if (packet.SDATA != null)
                    {
                        inputs = new Boolean[(InputCount > -1) ? InputCount : packet.SDATA.Length * 8];

                        byte index = 0;
                        while ((index < inputs.Length) && ((index / 8) < packet.SDATA.Length))
                        {
                            inputs[index] = (((packet.SDATA[packet.SDATA.Length - (index / 8) - 1]) & (1 << (index % 8))) != 0);
                            index++;
                        }
                        if (OnInputsChange != null)
                        {
                            OnInputsChange(this, inputs);
                        }
                        if (OnInputChange != null)
                        {
                            if (last_input_status == null)
                            {
                                last_input_status = new Boolean[inputs.Length];
                                for (int i = 0; (i < last_input_status.Length); i++)
                                {
                                    OnInputChange(this, i, inputs[i], inputs[i]);
                                    last_input_status[i] = inputs[i];
                                }
                            }
                            else
                            {
                                for (int i = 0; (i < last_input_status.Length); i++)
                                {
                                    if (last_input_status[i] != inputs[i])
                                    {
                                        OnInputChange(this, i, last_input_status[i], inputs[i]);
                                        last_input_status[i] = inputs[i];
                                    }
                                }
                            }
                        }
                    }


                }



            }
        }

        public delegate void EventQuidoInputChange(Quido quido, int io_index, bool io_old_stat, bool io_new_stat);
        public delegate void EventQuidoInputsChange(Quido quido, Boolean[] inputs);

        public event EventQuidoInputChange OnInputChange = null ;
        public event EventQuidoInputsChange OnInputsChange = null;

    }
}
