using ChatBot.Models;
using ChatBot.RestClient;
using ChatBot.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
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
        public async Task<List<ThongTinChamSocKH>> GetChamSocKH(int linkChamSocKH, int idKH)
        {
            RestClient<ThongTinChamSocKH> restClient = new RestClient<ThongTinChamSocKH>(linkChamSocKH);

            var listChamSocKH = await restClient.GetAsyncCSKH(idKH);

            return listChamSocKH;
        }

        public async Task<List<Customers>> GetCustomersWithID(string Taikhoan, string Matkhau, int linkKhachHang)
        {
            RestClient<Customers> restClient = new RestClient<Customers>(linkKhachHang);

            var customerList = await restClient.GetCustomersID(Taikhoan, Matkhau);

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

        //Đánh giá

        public async Task PostDanhGia(DanhGia danhgia, int linkDanhGia)
        {
            RestClient<DanhGia> restClient = new RestClient<DanhGia>(linkDanhGia);
            var danhgiaList = await restClient.DanhGiaAsync(danhgia.id, danhgia);
        }

    }
}
