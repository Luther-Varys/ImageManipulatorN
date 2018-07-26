using System;
using System.Drawing;
using System.IO;
using ImageManipulatorNLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageManipulatorN.Test
{
    [TestClass]
    public class UnitTest1
    {



        [TestMethod]
        public void TestValidimageFromFile()
        {
            //ARRANGE
            //How to geet application path of the exe file (it will reference the bin driectory)
            //https://stackoverflow.com/questions/14549766/how-to-get-my-project-path
            string rootFolderPath_01 = System.AppDomain.CurrentDomain.BaseDirectory;

            System.Diagnostics.Debug.WriteLine(rootFolderPath_01);

            string filename_image = @"image_01.png";
            string filename_text = @"text_01.txt";
            string fullPath_image = System.IO.Path.Combine(rootFolderPath_01, @"..\..\ImageTest\", filename_image);
            string fullPath_text = System.IO.Path.Combine(rootFolderPath_01, @"..\..\ImageTest\", filename_text);


            //ACT
            ImageManipolator imageManipolator = new ImageManipolator();
            bool isValid_pathImage = imageManipolator.IsValidImage(fullPath_image);
            bool isValid_pathText = imageManipolator.IsValidImage(fullPath_text);



            //ASSERT
            Assert.IsTrue(isValid_pathImage);
            Assert.IsFalse(isValid_pathText);

        }


        [TestMethod]
        public void TestValidimageFromBytes()
        {
            //ARRANGE
            //How to geet application path of the exe file (it will reference the bin driectory)
            //https://stackoverflow.com/questions/14549766/how-to-get-my-project-path
            string rootFolderPath_01 = System.AppDomain.CurrentDomain.BaseDirectory;

            System.Diagnostics.Debug.WriteLine(rootFolderPath_01);

            string filename_image = @"image_01.png";
            string fullPath_image = System.IO.Path.Combine(rootFolderPath_01, @"..\..\ImageTest\", filename_image);

            ImageManipolator imageManipolator = new ImageManipolator();


            //ACT
            System.Drawing.Image img = System.Drawing.Image.FromFile(fullPath_image);
            bool isValid_byteImage;
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] arr;
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
                isValid_byteImage = imageManipolator.IsValidImage(arr);
            }




            //ASSERT
            Assert.IsTrue(isValid_byteImage);


        }



        [TestMethod]
        public void TestGetImageFromFilePath()
        {
            //ARRANGE
            //How to geet application path of the exe file (it will reference the bin driectory)
            //https://stackoverflow.com/questions/14549766/how-to-get-my-project-path
            string rootFolderPath_01 = System.AppDomain.CurrentDomain.BaseDirectory;

            System.Diagnostics.Debug.WriteLine(rootFolderPath_01);

            string filename_image = @"image_01.png";
            //string filename_image = @"text_01.txt";
            string fullPath_image = System.IO.Path.Combine(rootFolderPath_01, @"..\..\ImageTest\", filename_image);


            //ACT
            try
            {
                ImageManipolator imageManipolator = new ImageManipolator();
                Image img = imageManipolator.GetImage(fullPath_image);

            }
            catch (Exception ex)
            {

                //ASSERT
                Assert.Fail(ex.Message);
            }


        }





        [TestMethod]
        public void TestGetImageFromStream()
        {
            //ARRANGE
            //How to geet application path of the exe file (it will reference the bin driectory)
            //https://stackoverflow.com/questions/14549766/how-to-get-my-project-path
            string rootFolderPath_01 = System.AppDomain.CurrentDomain.BaseDirectory;

            System.Diagnostics.Debug.WriteLine(rootFolderPath_01);

            string filename_image = @"image_01.png";
            //string filename_image = @"text_01.txt";
            string fullPath_image = System.IO.Path.Combine(rootFolderPath_01, @"..\..\ImageTest\", filename_image);


            //ACT
            try
            {



                ImageManipolator imageManipolator = new ImageManipolator();

                using (FileStream stream = File.OpenRead(fullPath_image))
                {
                    Image img = imageManipolator.GetImage(stream);
                }


            }
            catch (Exception ex)
            {

                //ASSERT
                Assert.Fail(ex.Message);
            }


        }


        [TestMethod]
        public void TestGetImageFromBytes()
        {
            //ARRANGE
            //How to geet application path of the exe file (it will reference the bin driectory)
            //https://stackoverflow.com/questions/14549766/how-to-get-my-project-path
            string rootFolderPath_01 = System.AppDomain.CurrentDomain.BaseDirectory;

            System.Diagnostics.Debug.WriteLine(rootFolderPath_01);

            string filename_image = @"image_01.png";
            //string filename_image = @"text_01.txt";
            string fullPath_image = System.IO.Path.Combine(rootFolderPath_01, @"..\..\ImageTest\", filename_image);


            //ACT
            try
            {

                byte[] imgBytes;
                using (FileStream stream = File.OpenRead(fullPath_image))
                {
                    imgBytes = new byte[stream.Length];
                    stream.Read(imgBytes, 0, imgBytes.Length);
                }

                ImageManipolator imageManipolator = new ImageManipolator();

                Image img = imageManipolator.GetImage(imgBytes);
  


            }
            catch (Exception ex)
            {

                //ASSERT
                Assert.Fail(ex.Message);
            }


        }




    }
}
