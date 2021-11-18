using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace downloader
{
    public class indirici
    {

        public delegate void IndirmeDurumuEventi(int yuzde, long indirilen, long total);
        public event IndirmeDurumuEventi IndirmedeDegisiklikoldugunda;

        public delegate void indirmeBittiEventi(bool iptalEdildiMi, string durum);
        public event indirmeBittiEventi IndirmeBittiginde;

        public void indir(string url, string hedefKonum)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
                webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;

                webClient.DownloadFileAsync(new Uri(url), hedefKonum);

                 
            }
        }



        public void WebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null && !e.Cancelled)
            {
                Console.WriteLine("Download completed!");
            }
            IndirmeBittiginde(e.Cancelled, "basari ile bitti");
        }

        public void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("Downloaded:" + e.ProgressPercentage.ToString());
            IndirmedeDegisiklikoldugunda(e.ProgressPercentage,e.BytesReceived,e.TotalBytesToReceive );
        }


    }
}
