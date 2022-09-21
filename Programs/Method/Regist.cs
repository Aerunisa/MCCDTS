using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace Programs.Method
{
    
    class REGIST : TSQL
    {
        SqlConnection sqlConnection;
        string connectionString =
                "Data Source=AERUNISA;Initial Catalog=MCCDTS;User ID= AERUNISA; Password = AERUNISA";
        public REGIST()
        {
                
        }
        public int IDRegist { get; set; }
        public string EmailPegawai { get; set; }
        public string Passwords { get; set; }
        public string DateJoin { get; set; }
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
            throw new NotImplementedException();
        }

        public override void Get()
        {
            string query = "SELECT * FROM REGIST";

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
                            Console.WriteLine("ID REGIST : " + sqlDataReader[0]);
                            Console.WriteLine("Email : " + sqlDataReader[1]);
                            Console.WriteLine("Password : " + sqlDataReader[2]);
                            Console.WriteLine("Date : " + sqlDataReader[3]);
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
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter ParaEmail = new SqlParameter();
                ParaEmail.ParameterName = "@email";
                ParaEmail.Value = regist.EmailPegawai;

                SqlParameter ParaPass = new SqlParameter();
                ParaPass.ParameterName = "@pass";
                ParaPass.Value = regist.Passwords;

                SqlParameter ParaDate = new SqlParameter();
                ParaDate.ParameterName = "@date";
                ParaDate.Value = regist.DateJoin;


                sqlCommand.Parameters.Add(ParaEmail);
                sqlCommand.Parameters.Add(ParaPass);
                sqlCommand.Parameters.Add(ParaDate);

                try
                {
                    sqlCommand.CommandText = "INSERT INTO REGIST " +
                        "(EmailPegawai , Passwords , DateJoinn) " +
                        "VALUES (@email, @pass, @date) ";
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

        public override void Insert(CutiPegawai cutiPegawai)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override void Update(REGIST regist)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter ParaEmail = new SqlParameter();
                ParaEmail.ParameterName = "@email";
                ParaEmail.Value = regist.EmailPegawai;

                SqlParameter ParaPass = new SqlParameter();
                ParaPass.ParameterName = "@pass";
                ParaPass.Value = regist.Passwords;

                SqlParameter ParaDate = new SqlParameter();
                ParaDate.ParameterName = "@date";
                ParaDate.Value = regist.DateJoin;


                sqlCommand.Parameters.Add(ParaEmail);
                sqlCommand.Parameters.Add(ParaPass);
                sqlCommand.Parameters.Add(ParaDate);

                try
                {
                    sqlCommand.CommandText = "UPDATE Salary SET EmailPegawai=@email, Password=@pass, DateJoin=@date, WHERE  EmailPegawai=@email";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }

            }
        }
    }
}
