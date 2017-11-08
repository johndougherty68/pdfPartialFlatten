using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace pdfFlattener
{
    public static class LicensingPDFCreator
    {
        /// <summary>
        /// Creates the PDF from the template
        /// </summary>
        /// <param name="ID">The id field of the epoa_Requests table</param>
        public static void Create(int ID)
        {
            try
            {
                Licensing_appEntities db = new Licensing_appEntities();
                var epoas = from p in db.epoa_Requests where p.id == ID select p;
                if (epoas.Count() < 1) throw new Exception("No EPOA Request found with ID of " + ID.ToString());

                epoa_Requests epoa = epoas.First();

                pdfFlattener.Add("TopmostSubform[0].Page1[0].txtOpen[0]", epoa.GetAgentString());               //Agent name at bottom left
                pdfFlattener.Add("TopmostSubform[0].Page1[0].NameList1[0]", epoa.GetAgentPOANames());           //POANames
                pdfFlattener.Add("TopmostSubform[0].Page1[0].NameList2[0]", epoa.GetAgentPOACityState());       //POACityState


                pdfFlattener.PDFTemplateLocation = ConfigurationManager.AppSettings["templatePDFPath"];
                MemoryStream output = pdfFlattener.CreatePDF();

                //file naming convention: epoa_[agent code]_[ID passed to me].pdf

                string outputFileTemplate = ConfigurationManager.AppSettings["saveFileNameTemplate"];

                string outputFileName = outputFileTemplate.Replace("[AgentCode]", epoa.AgentCode).Replace("[id]", epoa.id.ToString());
                string outputPath = ConfigurationManager.AppSettings["savePDFPath"] + @"\" + outputFileName;

                FileStream fs = File.Create(outputPath);
                fs.Write(output.ToArray(), 0, (int)output.Length);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
