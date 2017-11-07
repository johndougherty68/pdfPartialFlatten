using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfFlattener
{
    /// <summary>
    /// Extension class for epoa_Requests
    /// </summary>
    public partial class epoa_Requests
    {
        /// <summary>
        /// Returns a string with the AgentCode_1 and AgentName fields
        /// </summary>
        /// <returns>The AgentCode_1 and AgentName of the record</returns>
        public string GetAgentString()
        {
            string res = "";
            try
            {
                res += this.AgentCode_1 + " ";
                res += this.AgentName + " ";
                return res;
            }
            catch (Exception ex)
            {
                //if there's an error, return what we have
                return res;
            }
        }

        /// <summary>
        /// Returns a string with the POA_Names, if provided in the record. Otherwise, returns "(no names provided)"
        /// </summary>
        /// <returns>The POANames if available (see above)</returns>
        public string GetAgentPOANames()
        {
            string res = "(no names provided)";
            try
            {
                if (this.POA_Names != null && this.POA_Names != "") res = this.POA_Names;
                return res;
            }
            catch (Exception ex)
            {
                //if there's an error, return what we have
                return res;
            }
        }

        /// <summary>
        /// Returns a string with the POA_CityState, if provided by the record. Otherwise, returns "(no city info provided)"
        /// </summary>
        /// <returns>The POA_CityState if available (see above)</returns>
        public string GetAgentPOACityState()
        {
            string res = "(no city info provided)";
            try
            {
                if (this.POA_CityState != null && this.POA_CityState!= "") res = this.POA_CityState;
                return res;
            }
            catch (Exception ex)
            {
                //if there's an error, return what we have
                return res;
            }
        }

    }
}
