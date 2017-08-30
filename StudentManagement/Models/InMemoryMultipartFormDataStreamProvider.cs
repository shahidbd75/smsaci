using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace StudentManagement.Models
{
    public class InMemoryMultipartFormDataStreamProvider : MultipartStreamProvider
    {
        private NameValueCollection _formData = new NameValueCollection();
        private List<HttpContent> _fileContents = new List<HttpContent>();
        private Collection<bool> _isFormData = new Collection<bool>();

        /// <summary>  
        /// Gets a <see cref="NameValueCollection"/> of form data passed as part of the multipart form data.  
        /// </summary>  
        public NameValueCollection FormData
        {
            get { return _formData; }
        }

        /// <summary>  
        /// Gets list of <see cref="HttpContent"/>s which contain uploaded files as in-memory representation.  
        /// </summary>  
        public List<HttpContent> Files
        {
            get { return _fileContents; }
        }

        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {           
            ContentDispositionHeaderValue contentDisposition = headers.ContentDisposition;
            if (contentDisposition != null)
            {   
                _isFormData.Add(String.IsNullOrEmpty(contentDisposition.FileName));

                return new MemoryStream();
            }
            throw new InvalidOperationException(string.Format("Did not find required '{0}' header field in MIME multipart body part..", "Content-Disposition"));
        }

        /// <summary>  
        /// Read the non-file contents as form data.  
        /// </summary>  
        /// <returns></returns>  
        public override async Task ExecutePostProcessingAsync()
        {
            for (int index = 0; index < Contents.Count; index++)
            {
                if (_isFormData[index])
                {
                    HttpContent formContent = Contents[index]; 
                    ContentDispositionHeaderValue contentDisposition = formContent.Headers.ContentDisposition;
                    string formFieldName = UnquoteToken(contentDisposition.Name) ?? String.Empty;

                    string formFieldValue = await formContent.ReadAsStringAsync();
                    FormData.Add(formFieldName, formFieldValue);
                }
                else
                {
                    _fileContents.Add(Contents[index]);
                }
            }
        }

        /// <summary>  
        /// Remove bounding quotes on a token if present  
        /// </summary>  
        /// <param name="token">Token to unquote.</param>  
        /// <returns>Unquoted token.</returns>  
        private static string UnquoteToken(string token)
        {
            if (String.IsNullOrWhiteSpace(token))
            {
                return token;
            }

            if (token.StartsWith("\"", StringComparison.Ordinal) && token.EndsWith("\"", StringComparison.Ordinal) && token.Length > 1)
            {
                return token.Substring(1, token.Length - 2);
            }

            return token;
        }
    }
}