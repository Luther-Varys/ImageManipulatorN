using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulatorNLib
{
    public class ImageManipolator
    {


        public bool IsValidImage(string imgFilePath)
        {
            try
            {
                Image newImage = Image.FromFile(imgFilePath);
            }
            catch (OutOfMemoryException ex)
            {
                // Image.FromFile will throw this if file is invalid. 
                // Don't ask me why. return false;
                return false;
            }

            return true;
        }

        public bool IsValidImage(Stream imgStream)
        {
            try
            {
                Image newImage = Image.FromStream(imgStream);
            }
            catch (OutOfMemoryException ex)
            {
                // Image.FromFile will throw this if file is invalid. 
                // Don't ask me why. return false;
                return false;
            }

            return true;
        }

        public bool IsValidImage(byte[] imgBytes)
        {
            try
            {
                using (var ms = new MemoryStream(imgBytes))
                {
                    Image newImage = Image.FromStream(ms);
                }
            }
            catch (OutOfMemoryException ex)
            {
                // Image.FromFile will throw this if file is invalid. 
                // Don't ask me why. return false;
                return false;
            }

            return true;
        }



        public Image GetImage(string imgFilePath)
        {
            if (this.IsValidImage(imgFilePath) == false)
                throw new NotValidImageException("ZR: The 'file' is not a valid image at path " + imgFilePath);

            Image newImage = Image.FromFile(imgFilePath);

            return newImage;
        }

        public Image GetImage(Stream imgStream)
        {
            if (this.IsValidImage(imgStream) == false)
                throw new NotValidImageException("ZR: The 'stream' does not contain a valid image");

            Image newImage = Image.FromStream(imgStream);

            return newImage;
        }

        public Image GetImage(byte[] imgBytes)
        {
            if (this.IsValidImage(imgBytes) == false)
                throw new NotValidImageException("ZR: The 'bytes' do not contain a valid image");

            Image newImage;
            using (var ms = new MemoryStream(imgBytes))
            {
                newImage = Image.FromStream(ms);
            }

            return newImage;
        }



        public byte[] GetImageBytes(string imgFilePath)
        {
            if (this.IsValidImage(imgFilePath) == false)
                throw new NotValidImageException("ZR: The 'file' is not a valid image at path " + imgFilePath);

            Image newImage = Image.FromFile(imgFilePath);

            byte[] imgBytes;
            using (FileStream stream = File.OpenRead(imgFilePath))
            {
                imgBytes = new byte[stream.Length];
                stream.Read(imgBytes, 0, imgBytes.Length);
            }

            return imgBytes;

        }

        public byte[] GetImageBytes(Stream imgStream)
        {
            if (this.IsValidImage(imgStream) == false)
                throw new NotValidImageException("ZR: The 'stream' does not contain a valid image");



            byte[] imgBytes = new byte[imgStream.Length];
            imgStream.Read(imgBytes, 0, imgBytes.Length);

            return imgBytes;

        }

    }

}
