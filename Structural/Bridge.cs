using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDesignPatterns.Structural
{
    internal class Bridge
    {
    }

    internal interface IRemoteControl
    {
        void TurnOn();
        void TurnOff();
    }

    internal class BasicRemoteControl : IRemoteControl
    {
        protected readonly  IDevice _device;

        public BasicRemoteControl(IDevice device)
        {
            _device = device;
        }

        public void TurnOn()
        {
            _device.PowerOn();
        }

        public void TurnOff()
        {
            _device.PowerOff();
        }
    }

    internal class AdvancedRemoteControl : BasicRemoteControl
    {
        public AdvancedRemoteControl(IDevice device) : base(device) { }
        
        public void ChangeStation(double station)
        {
            if (_device is IRadio radio)
            {
                radio.ChangeStation(station);
            }
        }

        public void SetVolume(int level)
        {
            if (_device is ITv tv)
            {
                tv.SetVolume(level);
            }
        }

        public void ChangeChannel(int channel)
        {
            if (_device is ITv tv)
            {
                tv.ChangeChannel(channel);
            }
        }
    }

    internal interface IDevice
    {
        void PowerOn();
        void PowerOff();
    }

    internal interface IRadio : IDevice
    {
        void ChangeStation(double station);
    }

    internal interface ITv : IDevice
    {
        void SetVolume(int level);
        void ChangeChannel(int channel);
    }


    internal class TvDevice : ITv
    {
        public void PowerOn()
        {
            Console.WriteLine("TV On");
        }

        public void PowerOff()
        {
            Console.WriteLine("TV Off");
        }

        public void SetVolume(int level)
        {
            Console.WriteLine($"TV Volume: {level}");
        }

        public void ChangeChannel(int channel)
        {
            Console.WriteLine($"TV Channel changed to {channel}");
        }
    }

    internal class RadioDevice : IRadio
    {
        public void PowerOn()
        {
            Console.WriteLine("Radio On");
        }
        public void PowerOff()
        {
            Console.WriteLine("Radio Off");
        }
        public void ChangeStation(double station)
        {
            Console.WriteLine($"Radio Station changed to {station}");
        }
    }
}
