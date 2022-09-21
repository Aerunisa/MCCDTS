using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace Programs.Method
{
    
    class CutiPegawai : TSQL
    {
        SqlConnection sqlConnection;
        string connectionString =
                "Data Source=AERUNISA;Initial Catalog=MCCDTS;User ID= AERUNISA; Password = AERUNISA";

        public CutiPegawai()
        {

        }

        public int IDCuti { get; set; }
        public int IDPegawai { get; set; }
        public int IDDept { get; set; }
        public int IDPosition { get; set; }
        public string AwalCuti { get; set; }
        public string AkhirCuti { get; set; }
        public int IDKet { get; set; }
        public override void Delete(Pegawai pegawai)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Salary salary)
        {
            throw new NotImplementedException();
        }

        public override void Delete(CutiPegawai cutiPegawai)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter ParaName = new SqlParameter();
                ParaName.ParameterName = "@id";
                ParaName.Value = cutiPegawai.IDCuti;
                sqlCommand.Parameters.Add(ParaName);

                try
                {
                    sqlCommand.CommandText = "DELETE FROM CutiPegawai WHERE IDCuti=@id";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine("Data Telah Dihapus");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            } 
        }

        public override void Get()
        {
            string query = "SELECT CutiPegawai.IDPegawai, Pegawai.PegawaiName , Position.Position , Keterangan.Keterangan " +
                " FROM CutiPegawai JOIN Pegawai " +
                " On Pegawai.IDPegawai = CutiPegawai.IDPegawai JOIN Position " +
                " On Position.IDPosition = Pegawai.IDPosition JOIN Keterangan " +
                " On Keterangan.IDKet = CutiPegawai.IDKet ";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine("ID Pegawai : " + sqlDataReader[0]);
                            Console.WriteLine("Pegawai : " + sqlDataReader[1]);
                            Console.WriteLine("Position : " + sqlDataReader[2]);
                            Console.WriteLine("Keterangan : " + sqlDataReader[3]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        public override void Insert(Pegawai pegawai)
        {
            throw new NotImplementedException();
        }

        public override void Insert(Salary salary)
        {
            throw new NotImplementedException();
        }

        public override void Insert(REGIST regist)
        {
            throw new NotImplementedException();
        }

        public override void Insert(CutiPegawai cutiPegawai)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter ParaName = new SqlParameter();
                ParaName.ParameterName = "@idpegawai";
                ParaName.Value = cutiPegawai.IDPegawai;

                SqlParameter ParaDept = new SqlParameter();
                ParaDept.ParameterName = "@deptid";
                ParaDept.Value = cutiPegawai.IDDept;

                SqlParameter ParaPost = new SqlParameter();
                ParaPost.ParameterName = "@postId";
                ParaPost.Value = cutiPegawai.IDPosition;

                SqlParameter ParaAwal = new SqlParameter();
                ParaAwal.ParameterName = "@tglawal";
                ParaAwal.Value = cutiPegawai.AwalCuti;

                SqlParameter ParaAkhir = new SqlParameter();
                ParaAkhir.ParameterName = "@tglakhir";
                ParaAkhir.Value = cutiPegawai.AkhirCuti;

                SqlParameter ParaKet = new SqlParameter();
                ParaKet.ParameterName = "@idket";
                ParaKet.Value = cutiPegawai.IDKet;

          

                sqlCommand.Parameters.Add(ParaName);
                sqlCommand.Parameters.Add(ParaDept);
                sqlCommand.Parameters.Add(ParaPost);
                sqlCommand.Parameters.Add(ParaAwal);
                sqlCommand.Parameters.Add(ParaAkhir);
                sqlCommand.Parameters.Add(ParaKet);

                try
                {
                    sqlCommand.CommandText = "INSERT INTO CutiPegawai " +
                        "(IDPegawai,IDDept,IDPosition,AwalCuti,AkhirCuti,IDKet) " +
                        "VALUES (@idpegawai, @deptid, @postId, @tglawal, @tglakhir, @idket)";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine("Data telah Terimput");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public override void Update(Pegawai pegawai)
        {
            throw new NotImplementedException();
        }

        public override void Update(Salary salary)
        {
            throw new NotImplementedException();
        }

        public override void Update(CutiPegawai cutiPegawai)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter ParaName = new SqlParameter();
                ParaName.ParameterName = "@idpegawai";
                ParaName.Value = cutiPegawai.IDPegawai;

                SqlParameter ParaDept = new SqlParameter();
                ParaDept.ParameterName = "@deptid";
                ParaDept.Value = cutiPegawai.IDDept;

                SqlParameter ParaPost = new SqlParameter();
                ParaPost.ParameterName = "@postId";
                ParaPost.Value = cutiPegawai.IDPosition;

                SqlParameter ParaAwal = new SqlParameter();
                ParaAwal.ParameterName = "@tglawal";
                ParaAwal.Value = cutiPegawai.AwalCuti;

                SqlParameter ParaAkhir = new SqlParameter();
                ParaAkhir.ParameterName = "@tglakhir";
                ParaAkhir.Value = cutiPegawai.AkhirCuti;

                SqlParameter ParaKet = new SqlParameter();
                ParaKet.ParameterName = "@idket";
                ParaKet.Value = cutiPegawai.IDKet;

                SqlParameter ParaCuti = new SqlParameter();
                ParaCuti.ParameterName = "@idcuti";
                ParaCuti.Value = cutiPegawai.IDCuti;



                sqlCommand.Parameters.Add(ParaName);
                sqlCommand.Parameters.Add(ParaDept);
                sqlCommand.Parameters.Add(ParaPost);
                sqlCommand.Parameters.Add(ParaAwal);
                sqlCommand.Parameters.Add(ParaAkhir);
                sqlCommand.Parameters.Add(ParaKet);
                sqlCommand.Parameters.Add(ParaCuti);



                try
                {
                    sqlCommand.CommandText = "UPDATE Salary SET IDPegawai=@idpegawai, IDDept=@deptid, IDPosition=@postId,  AwalCuti=@tglawal, AkhirCuti=@tglakhir, IDKet=@idket WHERE IDCuti = @idcuti";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }

            }
        }

        public override void Update(REGIST regist)
        {
            throw new NotImplementedException();
        }
    }
}
