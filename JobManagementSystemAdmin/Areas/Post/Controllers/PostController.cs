using JobManagementSystemAdmin.Areas.Post.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace JobManagementSystemAdmin.Controllers
{
    [Area("Post")]
    [Route("Post/[controller]/[action]")]
    public class PostController : Controller
    {
        string baseurl = "http://localhost:5250/api/";
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync("Post");
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    PostListResponse jsonObject = JsonConvert.DeserializeObject<PostListResponse>(data);
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
                HttpResponseMessage responseMessage = await client.GetAsync("Post/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    PostResponse jsonObject = JsonConvert.DeserializeObject<PostResponse>(data);
                    var dataOfObject = jsonObject.data;
                    return View("InsertPost", dataOfObject);



                    /*dt = JsonConvert.DeserializeObject<DataTable>(data);*/
                }
                else
                {
                    Console.WriteLine("Error in api");
                }


            }

            return View("InsertPost");
        }

        public async Task<IActionResult> Insert(Postall? PostResponse)
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine(PostResponse);
                client.BaseAddress = new Uri(baseurl);
                string data = JsonConvert.SerializeObject(PostResponse);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                if (PostResponse?.postID == 0)
                {
                    HttpResponseMessage responseMessage = await client.PostAsync("Post", content);
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
                    HttpResponseMessage responseMessage = await client.PutAsync("Post", content);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Console.WriteLine("Error in api");
                    }
                }
                return View("InsertPost");
            }
        }

        public async Task<IActionResult> DeletePost(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.DeleteAsync("Post?PostID=" + id);
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