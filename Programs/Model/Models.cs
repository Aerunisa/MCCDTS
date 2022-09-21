using System;
using System.Collections.Generic;
using System.Text;

namespace Programs.Model
{
    public class Pegawai
    {
       /* public Pegawai(int id)
        {
            IDPegawai = id;
        }*/
        public int IDPegawai { get; set; }
        public string PegawaiName { get; set; }
        public int IDDept { get; set; }
        public int IDPosition { get; set; }
        public string Phone { get; set; }
        public string Addres { get; set; }
        public string EmailPegawai { get; set; }
        public int IDSalary { get; set; }

    }
    public class REGIST
    {
        public int IDRegist { get; set; }
        public string EmailPegawai { get; set; }
        public string Passwords { get; set; }
        public DateTime DateJoin { get; set; }
    }

    public class LOGINHISTORY
    {
        public int IDHistory { get; set; }
        public string EmailPegawai { get; set; }
        public string Passwords { get; set; }
        public DateTime Datelogin { get; set; }
    }

    public class Location
    {
        public int IDLoc{ get; set; }
        public string LocAdress{ get; set; }
        public string LocPostCode { get; set; }
        public string LocCity { get; set; }
    }
    
    public class PositionC
    {
        public int IDPosition{ get; set; }
        public string Position{ get; set; }
        public string Duty{ get; set; }
        public string Auth{ get; set; }
    }

    public class Salary
    {
        public int IDSalary { get; set; }
        public int Amount { get; set; }
        public int IDPosition { get; set; }
    }

    public class KeteranganC
    {
        public int IDKet{ get; set; }
        public string Penjelasan{ get; set; }
        public string Keterangan{ get; set; }

    }

    public class Department
    {
        public int IDDept { get; set; }
        public string DeptName { get; set; }
        public int IDLoc{ get; set; }
        public int Manager{ get; set; }
    }

    public class CutiPegawai
    {
        public int IDCuti{ get; set; }
        public int IDPegawai{ get; set; }
        public int IDPosition { get; set; }
        public DateTime AwalCuti{ get; set; }
        public DateTime AkhirCuti{ get; set; }
        public int IDKet{ get; set; }
    }

    public class Attendance
    {
        public int IDHistory { get; set; }
        public int IDPegawai { get; set; }
        public int IDDept { get; set; }
        public int IDPosition { get; set; }
        public DateTime Tanggal { get; set; }
        public DateTime WaktuDatang { get; set; }
        public DateTime WaktuPulang { get; set; }
        public int IDKet { get; set; }
    }

   

}
