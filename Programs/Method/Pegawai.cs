using System;
using System.Data.SqlClient;
using System.Data;
using Programs.Model;
using Programs.Method;

namespace Programs.Method
{
    class Pegawai : TSQL
    {
        SqlConnection sqlConnection;
        string connectionString =
                "Data Source=AERUNISA;Initial Catalog=MCCDTS;User ID= AERUNISA; Password = AERUNISA";

        public Pegawai()
        {
        }

        public int IDPegawai { get; set; }
        public string PegawaiName { get; set; }
        public int IDDept { get; set; }
        public int IDPosition { get; set; }
        public string Phone { get; set; }
        public string Addres { get; set; }
        public string EmailPegawai { get; set; }
        public int IDSalary { get; set; }

        public override void Delete(Pegawai pegawai)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter ParaName = new SqlParameter();
                ParaName.ParameterName = "@id";
                ParaName.Value = pegawai.IDPegawai;
                sqlCommand.Parameters.Add(ParaName);

                try
                {
                    sqlCommand.CommandText = "DELETE FROM Pegawai WHERE IDPegawai=@id";
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
            string query = "SELECT Salary.Amount , Pegawai.PegawaiName , Position.Position ," +
                "Department.DeptName, REGIST.EmailPegawai, Pegawai.Phone FROM Pegawai JOIN Salary " +
                " On Pegawai.IDSalary = Salary.IDSalary JOIN Position " +
                " On Pegawai.IDPosition = Position.IDPosition JOIN Department " +
                " On Pegawai.IDDept = Department.IDDept JOIN REGIST "+
                " on REGIST.EmailPegawai = Pegawai.EmailPegawai ";

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
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter ParaName = new SqlParameter();
                ParaName.ParameterName = "@name";
                ParaName.Value = pegawai.PegawaiName;

                SqlParameter ParaDept = new SqlParameter();
                ParaDept.ParameterName = "@deptid";
                ParaDept.Value = pegawai.IDDept;

                SqlParameter ParaPost = new SqlParameter();
                ParaPost.ParameterName = "@postId";
                ParaPost.Value = pegawai.IDPosition;

                SqlParameter ParaPhone = new SqlParameter();
                ParaPhone.ParameterName = "@phone";
                ParaPhone.Value = pegawai.Phone;

                SqlParameter ParaAddres = new SqlParameter();
                ParaAddres.ParameterName = "@address";
                ParaAddres.Value = pegawai.Addres;

                SqlParameter ParaEmail = new SqlParameter();
                ParaEmail.ParameterName = "@email";
                ParaEmail.Value = pegawai.EmailPegawai;

                SqlParameter ParaSalary = new SqlParameter();
                ParaSalary.ParameterName = "@Salary";
                ParaSalary.Value = pegawai.IDSalary;

                sqlCommand.Parameters.Add(ParaName);
                sqlCommand.Parameters.Add(ParaDept);
                sqlCommand.Parameters.Add(ParaPost);
                sqlCommand.Parameters.Add(ParaPhone);
                sqlCommand.Parameters.Add(ParaAddres);
                sqlCommand.Parameters.Add(ParaEmail);
                sqlCommand.Parameters.Add(ParaSalary);

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Pegawai " +
                        "(PegawaiName, IDDept, IDPosition, Phone, Addres, EmailPegawai, IDSalary) " +
                        "VALUES (@name, @deptid, @postId, @phone, @address, @email ,  @Salary)";
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
            throw new NotImplementedException();
        }

        public override void Update(Pegawai pegawai)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@id";
                sqlParameter.Value = pegawai.IDPegawai;

                SqlParameter ParaName = new SqlParameter();
                ParaName.ParameterName = "@name";
                ParaName.Value = pegawai.PegawaiName;

                SqlParameter ParaDept = new SqlParameter();
                ParaDept.ParameterName = "@deptid";
                ParaDept.Value = pegawai.IDDept;

                SqlParameter ParaPost = new SqlParameter();
                ParaPost.ParameterName = "@postId";
                ParaPost.Value = pegawai.IDPosition;

                SqlParameter ParaPhone = new SqlParameter();
                ParaPhone.ParameterName = "@phone";
                ParaPhone.Value = pegawai.Phone;

                SqlParameter ParaAddres = new SqlParameter();
                ParaAddres.ParameterName = "@address";
                ParaAddres.Value = pegawai.Addres;

                SqlParameter ParaEmail = new SqlParameter();
                ParaEmail.ParameterName = "@email";
                ParaEmail.Value = pegawai.EmailPegawai;

                SqlParameter ParaSalary = new SqlParameter();
                ParaSalary.ParameterName = "@Salary";
                ParaSalary.Value = pegawai.IDSalary;

                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.Parameters.Add(ParaName);
                sqlCommand.Parameters.Add(ParaDept);
                sqlCommand.Parameters.Add(ParaPost);
                sqlCommand.Parameters.Add(ParaPhone);
                sqlCommand.Parameters.Add(ParaAddres);
                sqlCommand.Parameters.Add(ParaEmail);
                sqlCommand.Parameters.Add(ParaSalary);



                try
                {
                    sqlCommand.CommandText = "UPDATE Salary SET PegawaiName=@name, IDDept=@deptid, IDPosition=@postId, Phone=@phone, Addres=@address, EmailPegawai=@email, IDSalary=@Salary WHERE IDPegawai = @id";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }

            }
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
            throw new NotImplementedException();
        }
    }
}
