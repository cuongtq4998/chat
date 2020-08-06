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
        // Lấy danh sach lich hen
        public async Task<List<getDatHenThongTinDichVu>> GetLichHen(int linkGetDichVu, int idKH)
        {
            RestClient<getDatHenThongTinDichVu> restClient = new RestClient<getDatHenThongTinDichVu>(linkGetDichVu);

            var listDichVu = await restClient.GetAsyncList(idKH);

            return listDichVu;
        }

        //Lấy thông tin chăm sóc khách hàng
        public async Task<List<ThongTinChamSocKH>> GetChamSocKH(int linkChamSocKH, int idKH, int gioiTinh)
        {
            RestClient<ThongTinChamSocKH> restClient = new RestClient<ThongTinChamSocKH>(linkChamSocKH);

            var listChamSocKH = await restClient.GetAsyncCSKH(idKH, gioiTinh);

            return listChamSocKH;
        }

        public async Task<Customers> GetCustomersWithID(string Taikhoan, string Matkhau, int linkKhachHang)
        {
            RestClient<Customers> restClient = new RestClient<Customers>(linkKhachHang);

            var customerList = await restClient.GetCustomersID(Taikhoan, Matkhau);

            return customerList;
        }

        public async Task<List<string>> getMessage(string cauhoi)
        {
            RestClient<List<string>> restClient = new RestClient<List<string>>(5);

            var customerList = await restClient.GetMessage(cauhoi);

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
        public async Task PutHuyLichHen(DatLichHen danhgia, int linkDanhGia)
        {
            RestClient<DatLichHen> restClient = new RestClient<DatLichHen>(linkDanhGia);
            var danhgiaList = await restClient.HuyLichHenAsync(danhgia.ID, danhgia);
        }

    }
}
