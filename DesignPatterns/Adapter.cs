using System.Collections;

namespace DesignPatterns
{
    internal class Adapter
    {
        // purpose : allows objects with incompatible interfaces to collaborate.
        // e.g. XML to JSON adapter
        // e.g. VGA graphics card stream to DVI monitor adapter

        public void Demo()
        {
            VgaGraphicsCard vgaGraphicsCard = new VgaGraphicsCard();
            DviMonitor dviMonitor = new DviMonitor();
            VgaCardToDviMonitorAdapter vgaCardToDviMonitorAdapter = new VgaCardToDviMonitorAdapter(vgaGraphicsCard);
            dviMonitor.SetInputDviStream(vgaCardToDviMonitorAdapter.GetDviStream());

            // print out the result of the adaptation
            foreach (byte b in dviMonitor.GetDviStream())
            {
                Console.Write(b + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public class VgaGraphicsCard
    {
        private byte[] _vgaStream = { 1, 2, 3 };

        public byte[] GetVgaStream()
        {
            return _vgaStream;
        }
    }

    public class DviMonitor
    {
        private byte[] _dviStream = { };

        public byte[] GetDviStream()
        {
            return _dviStream;
        }

        public void SetInputDviStream(byte[] inputDviStream)
        {
            _dviStream = inputDviStream;
            Console.WriteLine("Set the input Dvi stream.");
        }
    }

    public class VgaCardToDviMonitorAdapter
    {
        private VgaGraphicsCard _vgaGraphicsCard;

        public VgaCardToDviMonitorAdapter(VgaGraphicsCard vgaGraphicsCard)
        {
            _vgaGraphicsCard = vgaGraphicsCard;
        }

        private byte[] _ConvertVgaGraphicsCardStreamToDviMonitorStream()
        {
            byte[] vgaStream = _vgaGraphicsCard.GetVgaStream();
            byte[] dviStream = { 0, 0, 0 };
            for (int i = 0; i < vgaStream.Length; i++)
            {
                // pretend this logic converts from VGA to DVI
                dviStream[dviStream.Length - 1 - i] = vgaStream[i];
            }
            Console.WriteLine("Converted VGA graphics card stream to DVI monitor stream.");
            return dviStream;
        }

        public byte[] GetDviStream()
        {
            return _ConvertVgaGraphicsCardStreamToDviMonitorStream();
        }
    }
}
