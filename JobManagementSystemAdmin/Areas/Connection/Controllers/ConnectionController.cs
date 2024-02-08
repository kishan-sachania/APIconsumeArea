using JobManagementSystemAdmin.Areas.Connection.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace JobManagementSystemAdmin.Areas.Connection.Controllers
{

    [Area("Connection")]
    [Route("Connection/[controller]/[action]")]
    public class ConnectionController : Controller
    {
        string baseurl = "http://localhost:5250/api/";
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync("Connection");
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    ConnectionListResponse jsonObject = JsonConvert.DeserializeObject<ConnectionListResponse>(data);
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
                HttpResponseMessage responseMessage = await client.GetAsync("Connection/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    ConnectionResponse jsonObject = JsonConvert.DeserializeObject<ConnectionResponse>(data);
                    var dataOfObject = jsonObject.data;
                    return View("InsertConnection", dataOfObject);



                    /*dt = JsonConvert.DeserializeObject<DataTable>(data);*/
                }
                else
                {
                    Console.WriteLine("Error in api");
                }


            }

            return View("InsertConnection");
        }

       /* public async Task<IActionResult> Insert(Connectionall ConnectionResponse)
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine(ConnectionResponse);
                client.BaseAddress = new Uri(baseurl);
                string data = JsonConvert.SerializeObject(ConnectionResponse);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                if (ConnectionResponse?.connectionId == 0)
                {
                    HttpResponseMessage responseMessage = await client.PostAsync("Connection", content);
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
                    HttpResponseMessage responseMessage = await client.PutAsync("Connection", content);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Console.WriteLine("Error in api");
                    }
                }
                return View("InsertConnection");
            }
        }
*/
        public async Task<IActionResult> DeleteConnection(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.DeleteAsync("Connection?connectionID=" + id);
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