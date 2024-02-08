using JobManagementSystemAdmin.Areas.Like.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace JobManagementSystemAdmin.Controllers
{
    [Area("Like")]
    [Route("Like/[controller]/[action]")]
    public class LikeController : Controller
    {
        string baseurl = "http://localhost:5250/api/";
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync("Like");
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    LikeListResponse jsonObject = JsonConvert.DeserializeObject<LikeListResponse>(data);
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
                HttpResponseMessage responseMessage = await client.GetAsync("Like/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    LikeResponse jsonObject = JsonConvert.DeserializeObject<LikeResponse>(data);
                    var dataOfObject = jsonObject.data;
                    return View("InsertLike", dataOfObject);



                    /*dt = JsonConvert.DeserializeObject<DataTable>(data);*/
                }
                else
                {
                    Console.WriteLine("Error in api");
                }


            }

            return View("InsertLike");
        }

        public async Task<IActionResult> Insert(Likeall? LikeResponse)
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine(LikeResponse);
                client.BaseAddress = new Uri(baseurl);
                string data = JsonConvert.SerializeObject(LikeResponse);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                if (LikeResponse?.likeID == 0)
                {
                    HttpResponseMessage responseMessage = await client.PostAsync("Like", content);
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
                    HttpResponseMessage responseMessage = await client.PutAsync("Like", content);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Console.WriteLine("Error in api");
                    }
                }
                return View("InsertLike");
            }
        }

        public async Task<IActionResult> DeleteLike(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.DeleteAsync("Like?LikeID=" + id);
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