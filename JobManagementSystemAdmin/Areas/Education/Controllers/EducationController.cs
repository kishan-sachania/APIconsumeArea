using JobManagementSystemAdmin.Areas.Education.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace JobManagementSystemAdmin.Controllers
{
    [Area("Education")]
    [Route("Education/[controller]/[action]")]
    public class EducationController : Controller
    {
        string baseurl = "http://localhost:5250/api/";
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync("Education");
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    EducationListResponse jsonObject = JsonConvert.DeserializeObject<EducationListResponse>(data);
                    var dataOfObject = jsonObject;
                    return View("Index", dataOfObject);
                }
                else
                {
                    Console.WriteLine("Error in api");
                }
                return View("Index");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync("Education/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    EducationResponse jsonObject = JsonConvert.DeserializeObject<EducationResponse>(data);
                    var dataOfObject = jsonObject.data;
                    return View("InsertEducation", dataOfObject);



                    /*dt = JsonConvert.DeserializeObject<DataTable>(data);*/
                }
                else
                {
                    Console.WriteLine("Error in api");
                }


            }

            return View("InsertEducation");
        }

        public async Task<IActionResult> Insert(Educationall? EducationResponse)
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine(EducationResponse);
                client.BaseAddress = new Uri(baseurl);
                string data = JsonConvert.SerializeObject(EducationResponse);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                if (EducationResponse?.educationID == 0)
                {
                    HttpResponseMessage responseMessage = await client.PostAsync("Education", content);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Console.WriteLine("Error in api");
                    }
                }
                else
                {
                    HttpResponseMessage responseMessage = await client.PutAsync("Education", content);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Console.WriteLine("Error in api");
                    }
                }
                return View("InsertEducation");
            }
        }

        public async Task<IActionResult> DeleteEducation(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.DeleteAsync("Education?EducationID=" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    return View("Index");
                }
            }
        }
    }
}