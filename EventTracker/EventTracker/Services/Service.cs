using ChatBot.Models;
using ChatBot.RestClient;
using ChatBot.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Services
{
    class Service
    { 
        // Lấy thông tin dịch vụ : 
        public async Task<ObservableCollection<THONGTINDICHVU>> GetTTDV(int linkGetDichVu)
        {
            RestClient<THONGTINDICHVU> restClient = new RestClient<THONGTINDICHVU>(linkGetDichVu);

            var listDichVu = await restClient.GetAsync();

            return listDichVu;
        }

        //Lấy thông tin chăm sóc khách hàng
        public async Task<ObservableCollection<CHAMSOCKH>> GetChamSocKH(int linkChamSocKH)
        {
            RestClient<CHAMSOCKH> restClient = new RestClient<CHAMSOCKH>(linkChamSocKH);

            var listChamSocKH = await restClient.GetAsync();

            return listChamSocKH;
        }

        public async Task<List<Customers>> GetCustomersWithID(string ID)
        {
            RestClient<Customers> restClient = new RestClient<Customers>(1);

            var customerList = await restClient.GetCustomersID(ID);

            return customerList;
        }

        //Thêm khách hàng : Done
        public async Task PostCustomers(AddUser customers, int linkKhachHang)
        {
            RestClient<AddUser> restClient = new RestClient<AddUser>(linkKhachHang); 
            var customerList = await restClient.PostAsync(customers); 
        }

        public async Task DatLichHen(DatLichHenPuss datLichHenPuss, int linkDatLichhen)
        {
            RestClient<DatLichHenPuss> restClientDatLichHen = new RestClient<DatLichHenPuss>(linkDatLichhen);
            var datLichHen = await restClientDatLichHen.PostAsync(datLichHenPuss);
        }
    }
}
