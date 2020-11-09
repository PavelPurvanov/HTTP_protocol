using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace exercise_7
{
    class HTTP_Request
    {
        private string htmlContent;
        private string headContent;

        public HTTP_Request(string URL, HTTP_Methods_ENUM method)
        {
            if (method == HTTP_Methods_ENUM.GET)
            {
                GetRequest(URL);
            }
            else
            {
                HeadRequest(URL);
            }
        }

        public string HTMLcontent
        {
            get { return htmlContent; }
            set { htmlContent = value; }
        }

        public string HEADcontent
        {
            get { return headContent; }
            set { headContent = value; }
        }     

        private void GetRequest(string URL) 
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();

                for (int i = 0; i < response.Headers.Count; i++)
                {
                    headContent = headContent + response.Headers.Keys[i] + ",  Value:  " + response.Headers[i] + Environment.NewLine;
                }

                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);

                htmlContent = streamReader.ReadToEnd();

                streamReader.Close();
                response.Close();
            }
            catch(WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        MessageBox.Show("HTTP Status Code: " + (int)response.StatusCode + Environment.NewLine
                        + "Status Description: " + ((HttpWebResponse)ex.Response).StatusDescription, 
                        "Exception occured !!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
             }
        }

        private void HeadRequest(string URL)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();


                for (int i = 0; i < response.Headers.Count; i++)
                {
                    headContent = headContent + response.Headers.Keys[i] + ",  Value:  " + response.Headers[i] + Environment.NewLine;
                }
                
                response.Close();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        MessageBox.Show("HTTP Status Code: " + (int)response.StatusCode + Environment.NewLine
                        + "Status Description: " + ((HttpWebResponse)ex.Response).StatusDescription,
                        "Exception occured !!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
