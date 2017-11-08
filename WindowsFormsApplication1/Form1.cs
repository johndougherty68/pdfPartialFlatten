using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pdfFlattener;
using System.IO;
using iTextSharp.text.pdf;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pdfFlattener.LicensingPDFCreator.Create(63);
            //pdfFlattener.pdfFlattener.Add("TopmostSubform[0].Page1[0].NameList2[0]", "23232323");
            //pdfFlattener.pdfFlattener.Add("TopmostSubform[0].Page1[0].BT[0]", "dsdssdsd");
            //pdfFlattener.pdfFlattener.Add("TopmostSubform[0].Page1[0].BT[1]", "6666666655445");
            //pdfFlattener.pdfFlattener.Add("TopmostSubform[0].Page1[0].BT[2]", "8675309");

            
            //pdfFlattener.pdfFlattener.PDFTemplateLocation = System.Configuration.ConfigurationManager.AppSettings["templatePDFPath"];
            //MemoryStream output = pdfFlattener.pdfFlattener.CreatePDF();

            //string outputPath = System.Configuration.ConfigurationManager.AppSettings["savePDFPath"] + @"\333_eee.pdf";

            //FileStream fs = File.Create(outputPath);
            //fs.Write(output.ToArray(), 0, (int)output.Length);
            //fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PdfReader pdfReader = new PdfReader(@"\\ificnwksrv2\UW_DBase\PDF\TEMPLATE_IFIC-ACC_e-POA.pdf");
            MemoryStream pdfStream = new MemoryStream();
            PdfStamper pdfStamper = new PdfStamper(pdfReader, pdfStream, '\0', true);

            int i = 1;
            foreach (var f in pdfStamper.AcroFields.Fields)
            {
                Console.WriteLine(f.Key);
                //pdfStamper.AcroFields.SetField(f.Key, string.Format("{0} : {1}", i, f.Key));
                //i++;
                //DoTrace("Field = [{0}] | Value = [{1}]", f.Key, f.Value.ToString());
            }
            //pdfStamper.FormFlattening = false;
            //pdfStamper.Writer.CloseStream = false;
            //pdfStamper.Close();

            //FileStream fs = File.OpenWrite(string.Format(@"{0}/{1}-TracePdfFields_{2}.pdf",
            //    ConfigManager.GetInstance().LogConfig.Dir,
            //    new FileInfo(pdfFilePath).Name,
            //    DateTime.Now.Ticks));

            //fs.Write(pdfStream.ToArray(), 0, (int)pdfStream.Length);
            //fs.Flush();
            //fs.Close();
        }
    }
}
