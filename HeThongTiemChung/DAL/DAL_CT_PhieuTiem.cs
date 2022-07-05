﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_CT_PhieuTiem: DAL_DataAccess
    {
        public List<DTO_CT_PhieuTiem> LayChiTietCuaPhieuTiem(string ma)
        {
            List<DTO_CT_PhieuTiem> dsChiTiet = new List<DTO_CT_PhieuTiem>();
            MoKetNoi();
            SqlCommand cmd = new SqlCommand("Select * from CT_PHIEUTIEMLE where MAPT = @ma", con);
            cmd.Parameters.AddWithValue("@ma", ma);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string maPT = dr.GetString(0);
                string maVX = dr.GetString(1);
                int gia = dr.GetInt32(2);
                string ngayTiem = dr.GetDateTime(3).ToShortDateString();

                DTO_CT_PhieuTiem KH = new DTO_CT_PhieuTiem(maPT, maVX, gia, ngayTiem);
                dsChiTiet.Add(KH);
            }
            DongKetNoi();
            return dsChiTiet;
        }

        public bool GhiNgayTiem(string maPT, string maVX, string ngay)
        {
            int res = 0;

            try
            {
                MoKetNoi();
                SqlCommand cmd = new SqlCommand("Update CT_PHIEUTIEMLE set NGTIEM = @ngay where MAPT = @maPT and MAVX = @maVX", con);
                cmd.Parameters.AddWithValue("@ngay", ngay);
                cmd.Parameters.AddWithValue("@maPT", maPT);
                cmd.Parameters.AddWithValue("@maVX", maVX);
                res = cmd.ExecuteNonQuery();
                DongKetNoi();
            }
            catch
            {
                return false;
            }
            return res > 0;
        }

        public List<DTO_CT_PhieuTiem> LayChiTietPhieuTiemGoi(string ma)
        {
            List<DTO_CT_PhieuTiem> dsChiTiet = new List<DTO_CT_PhieuTiem>();
            MoKetNoi();
            SqlCommand cmd = new SqlCommand("Select * from CT_PHIEUTIEMGOI where MAPT = @ma", con);
            cmd.Parameters.AddWithValue("@ma", ma);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string maPT = dr.GetString(0);
                string maVX = dr.GetString(1);
                int gia = dr.GetInt32(2);
                string ngayTiem = dr.GetDateTime(3).ToShortDateString();

                DTO_CT_PhieuTiem KH = new DTO_CT_PhieuTiem(maPT, maVX, gia, ngayTiem);
                dsChiTiet.Add(KH);
            }
            DongKetNoi();
            return dsChiTiet;
        }

        public bool GhiNgayTiemGoi(string maPT, string maGoi, string ngay)
        {
            int res = 0;
            try
            {
                MoKetNoi();
                SqlCommand cmd = new SqlCommand("Update CT_PHIEUTIEMGOI set NGTIEM = @ngay where MAPT = @maPT and MAGOI = @maGoi", con);
                cmd.Parameters.AddWithValue("@ngay", ngay);
                cmd.Parameters.AddWithValue("@maPT", maPT);
                cmd.Parameters.AddWithValue("@maGoi", maGoi);
                res = cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return res > 0;
        }
    }
}
