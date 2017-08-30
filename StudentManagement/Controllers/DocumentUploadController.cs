using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

namespace StudentManagement.Controllers
{
    public class DocumentUploadController : ApiController
    {
        [HttpPost]
        [Route("api/upload/fileupload")]
        public async Task<HttpResponseMessage> MediaUpload()
        {
            // Check if the request contains multipart/form-data.  
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(new InMemoryMultipartFormDataStreamProvider());

            NameValueCollection formData = provider.FormData;

            IList<HttpContent> files = provider.Files;

            HttpContent file1 = files[0];
            var thisFileName = file1.Headers.ContentDisposition.FileName.Trim('\"');

            string filename = String.Empty;
            Stream input = await file1.ReadAsStreamAsync();
            string directoryName = String.Empty;
            string URL = String.Empty;
            string tempDocUrl = WebConfigurationManager.AppSettings["DocsUrl"];

            if (formData["TutorialName"] != string.Empty && formData["StudentId"] !="")
            {
                var path = HttpRuntime.AppDomainAppPath;
                directoryName = System.IO.Path.Combine(path, "ClientDocument");
                filename = System.IO.Path.Combine(directoryName, thisFileName);

                //Deletion exists file  
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                string DocsPath = tempDocUrl + "/" + "ClientDocument" + "/";
                URL = DocsPath + thisFileName;

                Tutorial tutorial = new Tutorial() {
                    FileLocation = URL,
                    StudentId = Convert.ToInt32(formData["StudentId"]),
                    TutorialName = formData["TutorialName"],
                    FileName = thisFileName
                };
                using(StudentDbContext db=new StudentDbContext())
                {
                    db.Tutorials.Add(tutorial);
                    db.SaveChanges();
                }
            }
            else
            {
                var res = Request.CreateResponse(HttpStatusCode.NoContent, "Please fill form with correct data");
                res.Headers.Add("DocsUrl", URL);
                return res;
            }


            //Directory.CreateDirectory(@directoryName);  
            using (Stream file = File.OpenWrite(filename))
            {
                input.CopyTo(file);
                //close file  
                file.Close();
            }

            var response = Request.CreateResponse(HttpStatusCode.OK,"Saved Successfully");
            response.Headers.Add("DocsUrl", URL);
            return response;
        }

    }
}
