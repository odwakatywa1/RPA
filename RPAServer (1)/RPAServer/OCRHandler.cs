using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronOcr;
using Tesseract;
using IronOcr.Languages;

namespace CoreServer
{
    class OCRHandler
    {
        public string getTextFromImage(string path)
        {
            AutoOcr Ocr = new AutoOcr();
            OcrResult Result = Ocr.Read(path);
            //Console.WriteLine(Result.Text);
            return Result.Text;
        }

        public string readGermanText(string path)
        {
            AdvancedOcr ocr = new AdvancedOcr()
            {
                Language = IronOcr.Languages.German.OcrLanguagePack,
                ColorSpace = AdvancedOcr.OcrColorSpace.GrayScale,
                EnhanceResolution = true,
                EnhanceContrast = true,
                CleanBackgroundNoise = true,
                ColorDepth = 4,
                RotateAndStraighten = false,
                DetectWhiteTextOnDarkBackgrounds = false,
                ReadBarCodes = false,
                Strategy = AdvancedOcr.OcrStrategy.Fast,
                InputImageType = AdvancedOcr.InputTypes.Document
            };

            OcrResult results = ocr.Read(@path);
            Console.WriteLine(results.Text);

            return results.Text;
        }
        

    }
}
