using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Remoting_Wizard
{
    public static class Image
    {
        private static ConcurrentDictionary<string, BitmapSource> _Cache = new ConcurrentDictionary<string, BitmapSource>();


        public static BitmapSource LoadBitmapSource(string uri)
        {
            if (_Cache.TryGetValue(uri, out BitmapSource bitmapSource))
            {
                return bitmapSource;
            }

            var loadedBMP = new BitmapImage(new Uri(uri));
            _Cache.TryAdd(uri, loadedBMP);
            return loadedBMP;
        }
    }
}
