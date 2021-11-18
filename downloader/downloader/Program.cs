using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace downloader
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //

            var x = new indirici();
            x.IndirmedeDegisiklikoldugunda += X_IndirmedeDegisiklikoldugunda;
            x.IndirmeBittiginde += X_IndirmeBittiginde;

            x.indir("http://cdn.smg.com.tr/x00078c09-37a1-4ab1-bd37-c0ce48a0dc76.mp3","deneme.mp3");

            Console.ReadLine();
        }

        private static void X_IndirmeBittiginde(bool iptalEdildiMi, string durum)
        {
            Console.WriteLine($"bitis bilgisi geldi, iptal mi:{iptalEdildiMi}, durum:{durum}");
        }

        private static void X_IndirmedeDegisiklikoldugunda(int yuzde,long indirilen, long total)
        {
            Console.WriteLine($"{yuzde} degisiklik oldu , {indirilen} / {total}");
        }
    }
}
