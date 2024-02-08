using JobManagementSystemAdmin.Areas.Industry.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace JobManagementSystemAdmin.Controllers
{
    [Area("Industry")]
    [Route("Industry/[controller]/[action]")]
    public class IndustryController : Controller
    {
        string baseurl = "http://localhost:5250/api/";
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync("Industry");
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    IndustryListResponse jsonObject = JsonConvert.DeserializeObject<IndustryListResponse>(data);
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
                HttpResponseMessage responseMessage = await client.GetAsync("Industry/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    IndustryResponse jsonObject = JsonConvert.DeserializeObject<IndustryResponse>(data);
                    var dataOfObject = jsonObject.data;
                    return View("InsertIndustry", dataOfObject);



                    /*dt = JsonConvert.DeserializeObject<DataTable>(data);*/
                }
                else
                {
                    Console.WriteLine("Error in api");
                }


            }

            return View("InsertIndustry");
        }

        public async Task<IActionResult> Insert(Industryall? IndustryResponse)
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine(IndustryResponse);
                client.BaseAddress = new Uri(baseurl);
                string data = JsonConvert.SerializeObject(IndustryResponse);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                if (IndustryResponse?.industryID == 0)
                {
                    HttpResponseMessage responseMessage = await client.PostAsync("Industry", content);
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
                    HttpResponseMessage responseMessage = await client.PutAsync("Industry", content);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Console.WriteLine("Error in api");
                    }
                }
                return View("InsertIndustry");
            }
        }

        public async Task<IActionResult> DeleteIndustry(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.DeleteAsync("Industry?IndustryID=" + id);
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