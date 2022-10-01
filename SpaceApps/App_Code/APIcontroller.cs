using System;
using System.IO;
using System.Net;
using DevLab.JmesPath;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceApps.App_Code
{
    public class APIcontroller
    {
        public static bool GenerateImageByPrompt (string prompt, string input_image, string outputFilename)
        {
            try
            {
                string serverPath = HttpContext.Current.Server.MapPath("/temp/");
                PostReturnToJSON(prompt, input_image);
                string id = FilterJSON(serverPath + "response.json", "id");
                id = id.Remove(0, 1);
                id = id.Remove(id.Length - 1, 1);
                Console.WriteLine(id);
                GetImageByID(id);
                string image_url = FilterJSON(serverPath + "image-response.json", "output[0]");
                while (image_url.Equals("ul") || image_url.Equals("null"))
                {
                    GetImageByID(id);
                    Console.WriteLine("Waiting for response");
                    image_url = FilterJSON(serverPath + "image-response.json", "output[0]");
                }
                image_url = image_url.Remove(0, 1);
                image_url = image_url.Remove(image_url.Length - 1, 1);
                DownloadImageByURL(image_url, outputFilename);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine (e.Message);
                return false;
            }
            
        }

        static void PostReturnToJSON(string prompt, string ref_img_url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.replicate.com/v1/predictions");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization", "Token ac78f0282f522735ba6d1221eb3da574cd40da68");

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{" +
                                    "\"version\": \"a9758cbfbd5f3c2094457d996681af52552901775aa2d6dd0b17fd15df959bef\"," +
                                    "\"input\": {" +
                                        "\"prompt\": \"" + prompt + "\"," +
                                        "\"init_image\": \"" + ref_img_url + "\"," +
                                        "\"width\": \"512\"," +
                                        "\"height\": \"512\"" +

                                    "}" +
                                "}";

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                File.WriteAllText(HttpContext.Current.Server.MapPath("/temp/") + "response.json", result);
                Console.WriteLine(result);
            }
        }

        static void GetImageByID(string id)
        {
            var request = WebRequest.Create(string.Format("https://api.replicate.com/v1/predictions/{0}", id));
            request.ContentType = "application/json; charset=utf-8";
            request.Method = "GET";
            request.Headers.Add("Authorization", "Token ac78f0282f522735ba6d1221eb3da574cd40da68");

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                //Here you got the JSON as string:
                var result = streamReader.ReadToEnd();
                // Write the text to a new file named "Response.json".
                File.WriteAllText(HttpContext.Current.Server.MapPath("/temp/") + "image-response.json", result);
            }

        }

        static void DownloadImageByURL(string url, string filename)
        {
            using (WebClient client = new WebClient())
            {
                Console.WriteLine(url);
                client.Headers.Add("Authorization", "Token ac78f0282f522735ba6d1221eb3da574cd40da68");
                client.DownloadFile(new Uri(url), filename);

            }
        }

        static string FilterJSON(string JSONfilename, string expression)
        {
            string input = File.ReadAllText(JSONfilename);

            var jmes = new JmesPath();
            var result = jmes.Transform(input, expression);

            File.WriteAllText(HttpContext.Current.Server.MapPath("/temp/") + "image_urls.txt", result);
            return result;
        }

    }
}