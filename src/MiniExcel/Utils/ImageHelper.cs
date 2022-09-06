namespace MiniExcelLibs.Utils
{
    using System;
    using System.Linq;
    using System.Text;

    internal class ImageHelper
    {
        public enum ImageFormat
        {
            bmp,
            jpg,
            gif,
            tiff,
            png,
            webp,
            unknown
        }

        private static readonly ReadOnlyMemory<byte> bmp = Encoding.ASCII.GetBytes("BM");              // BMP
        private static readonly ReadOnlyMemory<byte> gif = Encoding.ASCII.GetBytes("GIF");             // GIF
        private static readonly ReadOnlyMemory<byte> png = new byte[] { 137, 80, 78, 71 };             // PNG
        private static readonly ReadOnlyMemory<byte> tiff = new byte[] { 73, 73, 42 };                 // TIFF
        private static readonly ReadOnlyMemory<byte> tiff2 = new byte[] { 77, 77, 42 };                // TIFF
        private static readonly ReadOnlyMemory<byte> jpeg = new byte[] { 255, 216, 255, 224 };         // jpeg
        private static readonly ReadOnlyMemory<byte> jpeg2 = new byte[] { 255, 216, 255, 225 };        // jpeg canon
        private static readonly ReadOnlyMemory<byte> webpOffset0 = Encoding.ASCII.GetBytes("RIFF");    // webp
        private static readonly ReadOnlyMemory<byte> webpOffset8 = Encoding.ASCII.GetBytes("WEBPVP8"); // webp

        public static ImageFormat GetImageFormat(ReadOnlySpan<byte> bytes)
        {
            if (bytes.StartsWith(bmp.Span))
                return ImageFormat.bmp;

            if (bytes.StartsWith(gif.Span))
                return ImageFormat.gif;

            if (bytes.StartsWith(png.Span))
                return ImageFormat.png;

            if (bytes.StartsWith(tiff.Span))
                return ImageFormat.tiff;

            if (bytes.StartsWith(tiff2.Span))
                return ImageFormat.tiff;

            if (bytes.StartsWith(jpeg.Span))
                return ImageFormat.jpg;

            if (bytes.StartsWith(jpeg2.Span))
                return ImageFormat.jpg;

            if (bytes.Length > 8
                && bytes.StartsWith(webpOffset0.Span)
                && bytes.Slice(8).StartsWith(webpOffset8.Span))
                return ImageFormat.webp;

            return ImageFormat.unknown;
        }
    }

}
