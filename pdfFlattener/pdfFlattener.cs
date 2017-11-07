using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text.pdf;

namespace pdfFlattener
{
    /// <summary>
    /// This class creates the flattened PDF. NOTE: As currently designed, this class should not need to be called directly.
    /// </summary>
    public static class pdfFlattener
    {
        public static string PDFTemplateLocation;

        public static void Add(string itemName, string itemValue)
        {
            if (itemValue == null) itemValue = string.Empty;
            pdfDocValues.Add(itemName, itemValue);
        }

        public static MemoryStream CreatePDF()
        {
            MemoryStream output = new MemoryStream();
            try
            {
                PdfReader reader = new PdfReader(PDFTemplateLocation);

                PdfStamper stamper = new PdfStamper(reader, output, '\0', true);
                stamper.FormFlattening = false;

                foreach (KeyValuePair<string, string> kvp in pdfDocValues.GetValues())
                {
                    try
                    {
                        stamper.AcroFields.SetField(kvp.Key, kvp.Value);
                        stamper.AcroFields.SetFieldProperty(kvp.Key, "setfflags", PdfFormField.FF_READ_ONLY, null);
                        stamper.PartialFormFlattening(kvp.Key);
                    }
                    catch (Exception)
                    {
                    }
                }
                stamper.Writer.CloseStream = false;
                stamper.Close();
                reader.Close();
                return output;
            }
            catch (Exception ex)
            {
                output.Dispose();
                throw ex;
            }
        }
    }
}
