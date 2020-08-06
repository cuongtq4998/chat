using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.RestClient
{
    public enum getLinkPage
    {
        linkKhachHang = 1,
        linkGetDichVu = 2,
        linkGetChamSocKH = 3,
        linkDatLichHen = 4,
        linkChat = 5
    }
    public class RestClient<T>
    {

        public RestClient(int getLink)
        {
            setLink = getLink;
        }

        public const string Https = "https://admin-chatbot.conveyor.cloud/";

        private const string UriKhachHang = Https + "api/KHACH_HANG";
        private const string UriDichVu = Https + "api/THONG_TIN_DICH_VUAPI";
        private const string UriChamSocKH = Https + "api/CHAM_SOC_KHAPI";
        private const string UriDatLichHen = Https + "api/DAT_LICH_HEN";
        private const string UriChat = Https + "api/Chatapi";


        public static int setLink { get; set; }

        public static string getLink()
        {
            string link = "";
            if (setLink == (int)getLinkPage.linkKhachHang)
            {
                link = UriKhachHang;
            }
            else if (setLink == (int)getLinkPage.linkGetDichVu)
            {
                link = UriDichVu;

            }
            else if (setLink == (int)getLinkPage.linkGetChamSocKH)
            {
                link = UriChamSocKH;

            }
            else if (setLink == (int)getLinkPage.linkDatLichHen)
            {
                link = UriDatLichHen;
            }else if(setLink == (int)getLinkPage.linkChat)
            {
                link = UriChat;
            }
            return link;
        }

        HttpClientHandler httpHandler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (o, cert, chain, errors) => true
        };
            
        public async Task<ObservableCollection<T>> GetAsync()
        {
            using (var client = new HttpClient(httpHandler))
            {

                var json = await client.GetStringAsync(getLink());

                var taskModels = JsonConvert.DeserializeObject<ObservableCollection<T>>(json);

                return taskModels;
            }

        }

        public async Task<List<T>> GetAsyncList( int idKH)
        {
            using (var client = new HttpClient(httpHandler))
            {

                var json = await client.GetStringAsync(getLink() + "/" + idKH);

                var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

                return taskModels;
            }

        }

        public async Task<List<T>> GetAsyncCSKH(int idKH, int gioiTinh)
        {
            using (var client = new HttpClient(httpHandler))
            {

                var json = await client.GetStringAsync(getLink() + "/" + idKH + "/" + gioiTinh);

                var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

                return taskModels;
            }

        }
        public async Task<T> GetCustomersID(string TaiKhoan1, string MatKhau1)
        {
            using (var client = new HttpClient(httpHandler))
            {

                var json = await client.GetStringAsync(getLink() + "/" + TaiKhoan1 + "/" + MatKhau1);

                var taskModels = JsonConvert.DeserializeObject<T>(json);

                //taskModels.ToString();

                return taskModels;
            }

        }
        public async Task<List<string>> GetMessage(string cauhoi )
        {
            using (var client = new HttpClient(httpHandler))
            {

                var json = await client.GetStringAsync(getLink() + "/" + cauhoi);

                var taskModels = JsonConvert.DeserializeObject<List<string>>(json);

                //taskModels.ToString();

                return taskModels;
            }

        }
        public async Task<bool> PostAsync(T t)
        {
            var httpClient = new HttpClient(httpHandler);

            //var s = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            //httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //var result = await httpClient.PostAsync(Uri, httpContent); 

            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(getLink(), jsonContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(int id, T t)
        {
            var httpClient = new HttpClient(httpHandler);

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(UriKhachHang + id, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id, T t)
        {
            var httpClient = new HttpClient(httpHandler);
            var respone = await httpClient.DeleteAsync(UriKhachHang + id);

            return respone.IsSuccessStatusCode;
        }
        public async Task<bool> DanhGiaAsync(int id, T t)
        {

            var httpClient = new HttpClient(httpHandler);
            var json = JsonConvert.SerializeObject(t);
            HttpContent httpContent = new StringContent(json);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            var respone = await httpClient.PutAsync(UriChamSocKH + "/" + id, jsonContent);

            return respone.IsSuccessStatusCode;
        }

        public async Task<bool> HuyLichHenAsync(int id, T t)
        {

            var httpClient = new HttpClient(httpHandler);
            var json = JsonConvert.SerializeObject(t);
            HttpContent httpContent = new StringContent(json);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            var respone = await httpClient.PutAsync(UriDatLichHen + "/" + id, jsonContent);

            return respone.IsSuccessStatusCode;
        }
    }
}
