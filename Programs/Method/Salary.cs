using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace Programs.Method
{

    class Salary : TSQL
    {
        SqlConnection sqlConnection;
        string connectionString =
                "Data Source=AERUNISA;Initial Catalog=MCCDTS;User ID= AERUNISA; Password = AERUNISA";
        public int IDSalary { get; set; }
        public int Amount { get; set; }
        public int IDPosition { get; set; }
        public override void Delete(Pegawai pegawai)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Salary salary)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter ParaName = new SqlParameter();
                ParaName.ParameterName = "@id";
                ParaName.Value = salary.IDSalary;
                sqlCommand.Parameters.Add(ParaName);

                try
                {
                    sqlCommand.CommandText = "DELETE FROM Salary WHERE IDSalary=@id";
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

        public override void Delete(CutiPegawai cutiPegawai)
        {
            throw new NotImplementedException();
        }

        public override void Get()
        {
            string query = "SELECT Salary.Amount , Pegawai.PegawaiName , Position.Position ," +
                "Department.DeptName FROM Pegawai JOIN Salary " +
                " On Pegawai.IDSalary = Salary.IDSalary JOIN Position " +
                " On Pegawai.IDPosition = Position.IDPosition JOIN Department " +
                " On Pegawai.IDDept = Department.IDDept ";

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

                            Console.WriteLine("Pegawai : " + sqlDataReader[1]);
                            Console.WriteLine("Salary : " + sqlDataReader[0]);
                            Console.WriteLine("Jabatan : " + sqlDataReader[2]);
                            Console.WriteLine("Department : " + sqlDataReader[3]);
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
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter ParaAmount = new SqlParameter();
                ParaAmount.ParameterName = "@amount";
                ParaAmount.Value = salary.Amount;

                SqlParameter ParaPost = new SqlParameter();
                ParaPost.ParameterName = "@postId";
                ParaPost.Value = salary.IDPosition;



                sqlCommand.Parameters.Add(ParaAmount);
                sqlCommand.Parameters.Add(ParaPost);

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Salary " +
                        "(Amount,IDPosition) " +
                        "VALUES (@idpegawai, @deptid)";
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

        public override void Insert(REGIST regist)
        {
            throw new NotImplementedException();
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
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@id";
                sqlParameter.Value = salary.IDSalary;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@amount";
                sqlParameter2.Value = salary.Amount;

                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.Parameters.Add(sqlParameter2);
                try
                {
                    sqlCommand.CommandText = "UPDATE Salary SET Amount=@amount WHERE IDSalary = @id";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }

            }
        }

        public override void Update(CutiPegawai cutiPegawai)
        {
            throw new NotImplementedException();
        }

        public override void Update(REGIST regist)
        {
            throw new NotImplementedException();
        }
    }
}
