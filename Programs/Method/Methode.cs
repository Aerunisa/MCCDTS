using System;
using System.Data.SqlClient;
using Programs.Model;

namespace Programs.Method
{
    class Methode
    {
        public double jumlahAbsen;
        public double penalty = 25000;
        public double gajiUtama;
        public double bonus;
        public double lembur;
        public double result;
        public double angka;
        public double angka2;

        public double CountingGaji()
        {
            if (jumlahAbsen == 0)
            {
                result = (gajiUtama) + (lembur * bonus);
                return result;
            }
            else
            {
                result = gajiUtama - (penalty * jumlahAbsen) + (lembur * bonus);
                return result;
            }


        }
        /* public double CountingGaji(double pajak= 0.25)
         {
             if (jumlahAbsen == 0)
             {
                 result = (gajiUtama) -(gajiUtama*pajak)+ (lembur * bonus);
                 return result;
             }
             else
             {
                 result = gajiUtama - (penalty * jumlahAbsen) + (lembur * bonus);
                 return result;
             }
         }*/
        public double Counting()
        {
            result = angka + angka2;
            return result;
        }
        public double Subtraction()
        {
            result = angka - angka2;
            return result;
        }
        public double Multiplication()
        {
            result = angka * angka2;
            return result;
        }
        public double Division()
        {
            result = angka / angka2;
            return result;
        }
    }
}
