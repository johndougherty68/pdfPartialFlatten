using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;

namespace pdfPartialFlatten
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();

            PdfReader reader = new PdfReader(@"D:\temp\IFIC-ACC_EPOA.pdf");
            values.Add(new KeyValuePair<string, string>("TopmostSubform[0].Page1[0].NameList2[0]", "abcdefg"));
            values.Add(new KeyValuePair<string, string>("TopmostSubform[0].Page1[0].BT[0]", "hijklmnop"));
            values.Add(new KeyValuePair<string, string>("TopmostSubform[0].Page1[0].BT[1]", "qrstuv"));
            values.Add(new KeyValuePair<string, string>("TopmostSubform[0].Page1[0].BT[2]", "wxyz"));

            //AcroFields af = reader.AcroFields;

            using (MemoryStream output = new MemoryStream())
            {
                PdfStamper stamper = new PdfStamper(reader, output,'\0',true);
                stamper.FormFlattening = false;

                foreach (KeyValuePair<string, string> kvp in values)
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
                FileStream fs = File.Create(@"d:\temp\foo.pdf");
                fs.Write(output.ToArray(), 0, (int)output.Length);
                fs.Close();
            }
            Application.Exit();
        }
    }
}
