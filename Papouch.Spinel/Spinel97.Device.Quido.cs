using System;
using System.Text;
using System.Diagnostics;

using Papouch.Spinel.Spinel97;
using Papouch.Communication;


namespace Papouch.Spinel.Spinel97.Device.Quido
{
    public class Quido:Device
    {
        public byte S97_ACK_OK = 0x00;

        public byte S97_INST_QUIDO_GetInputs            = 0x31;     // Čtení stavu vstupů
        public byte S97_INST_QUIDO_SetAutoNotify        = 0x10;     // Nastavení samovolného vysílání
        public byte S97_INST_QUIDO_GetAutoNotify        = 0x11;     // Čtení nastavení samovolného vysílání
        public byte S97_INST_QUIDO_GetCounter           = 0x60;     // Čtení čítačů
        public byte S97_INST_QUIDO_SetCounterSettings   = 0x6A;     // Nastavení čítačů
        public byte S97_INST_QUIDO_GetCounterSettings   = 0x6B;     // Čtení nastavení čítačů
        public byte S97_INST_QUIDO_SetOutput            = 0x20;     // Nastavení výstupů
        public byte S97_INST_QUIDO_GetOutputs           = 0x30;     // Čtení výstupů

        public int InputCount = -1;                                 // Počet vstupů Quida
        public int OutputCount = -1;                                // Počet výstupů Quida

        public Quido(ICommunicationInterface ci, byte spinelADR)
            : base(ci, spinelADR)
        {
            
        }
        
        /// <summary>
        ///     Nastavení výstupu
        /// </summary>
        /// <param name="rele">výstup (indexováno od 1)</param>
        /// <param name="value">požadovaný stav</param>
        /// <returns>vrací True v případě potvrzení příkazu modulem</returns>
        public Boolean CmdSetRele(byte rele, Boolean value)                      
        {
            PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_QUIDO_SetOutput);
            txPacket.ADR = this.ADR;

            byte[] data = new byte[1];
            data[0] = (byte)( ((value) ? 0x80 : 0x00) | ( rele & 0x7F) );     

            txPacket.SDATA = data;

            PacketSpinel97 rxPacket;

            if (this.SendAndReceive(ref txPacket, out rxPacket) && (rxPacket.INST == S97_ACK_OK))
            {
                return true;
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

            if (SendAndReceive(ref txPacket, out rxPacket) && (rxPacket.INST == S97_ACK_OK))
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

            if (SendAndReceive(ref txPacket, out rxPacket) && (rxPacket.INST == S97_ACK_OK))
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

            if (SendAndReceive(ref txPacket, out rxPacket) & (rxPacket.INST == S97_ACK_OK))
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

            if (SendAndReceive(ref txPacket, out rxPacket) && (rxPacket.INST == S97_ACK_OK))
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

            if (SendAndReceive(ref txPacket, out rxPacket) && (rxPacket.INST == S97_ACK_OK))
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

            if (SendAndReceive(ref txPacket, out rxPacket) && (rxPacket.INST == S97_ACK_OK))
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
