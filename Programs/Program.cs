using System;
using System.Data.SqlClient;
using System.Data;
using Programs.Model;
using Programs.Method;


namespace Programs
{
    class Program
    {
        
        SqlConnection sqlConnection;
        string connectionString =
                "Data Source=AERUNISA;Initial Catalog=MCCDTS;User ID= AERUNISA; Password = AERUNISA";
        static void Main(string[] args)
        {
            Program Run = new Program();
            Console.WriteLine("Silahkan Login dengan Masukkan email Enter password");
            Model.REGIST login = new Model.REGIST()
            {
                EmailPegawai = Console.ReadLine(),
                Passwords = Console.ReadLine()
            };
            Run.Login(login);

            TSQL sql;
            sql = new Method.Pegawai();
            Method.Pegawai pegawai = new Method.Pegawai()
            {
                PegawaiName = "Stephanie",
                IDDept = 2,
                IDPosition = 7,
                Phone = "+6285887173252",
                Addres = "Jalan Kali dirumah mulu",
                EmailPegawai = "Pegawai12@mail.com",
                IDSalary = 5,
                IDPegawai = 15

                /*// Gatau keluar sendiri setelah isi adress
                PegawaiName = Console.ReadLine(), 
                IDDept = Console.Read(),
                IDPosition = Console.Read(),
                Phone = Console.ReadLine(),
                Addres = Console.ReadLine(),
                EmailPegawai = Console.ReadLine(),
                IDSalary = Console.Read(),
                IDPegawai = Console.Read()*/
            };

            TSQL sqlSalary;
            sqlSalary = new Method.Salary();
            Method.Salary salary = new Method.Salary()
            {
                IDSalary = 15,
                Amount = 2000000,
                IDPosition = 14
                /*IDSalary = Console.Read(),
                Amount = Console.Read(),
                IDPosition = Console.Read()*/

            };

            TSQL sqlCuti;
            sqlCuti = new Method.CutiPegawai();
            Method.CutiPegawai cutiPegawai = new Method.CutiPegawai()
            {

                IDCuti = 15,
                IDPegawai = 10,
                IDDept = 1,
                IDPosition = 1,
                AwalCuti = "2020-10-11",
                AkhirCuti = "2020-10-12",
                IDKet = 1
                /*
                IDCuti = Console.Read(),
                IDPegawai = Console.Read(),
                IDDept = Console.Read(),
                IDPosition = Console.Read(),
                AwalCuti = DateTime.Parse(Console.ReadLine()),
                AkhirCuti = DateTime.Parse(Console.ReadLine()),
                IDKet = Console.Read()*/

            };

            TSQL sqlRegist;
            sqlRegist = new Method.REGIST();
            Method.REGIST regist = new Method.REGIST()
            {
                IDRegist = 6,
                EmailPegawai = "Pegawai20@mail.com",
                Passwords = "Random",
                DateJoin = "2020-10-12",
                /*IDRegist = Console.Read(),
                EmailPegawai = Console.ReadLine(),
                Passwords = Console.ReadLine(),
                DateJoin = Console.ReadLine(),*/

            };

            


            for (;;)
            {
                Console.WriteLine("Welcome to Program HR!");
                
                Console.WriteLine("---------------------");
                Console.WriteLine("Program Yang Tesedia  ");
                Console.WriteLine("1 - Pegawai {0}2 - Salary {0}3 - Perizinan Cuti {0}4 - Daftar Anggota {0}5 - Menu Lainnya", Environment.NewLine);
                Console.Write("Enter Choice(1-5):");
                var userInput = int.Parse(Console.ReadKey().KeyChar.ToString());
                Console.WriteLine(); ;
                //Console.WriteLine();
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Program Pegawai  ");
                        Console.WriteLine("1 - Insert {0}2 - Update {0}3 - Delete {0}4 - SeeData", Environment.NewLine);
                        Console.Write("Enter Choice(1-4):");
                        var inputpegawai = int.Parse(Console.ReadKey().KeyChar.ToString());
                        switch (inputpegawai)
                        {
                            case 1:
                                sql.Insert(pegawai);
                                break;
                            case 2:
                                sql.Update(pegawai);
                                break;
                            case 3:
                                sql.Delete(pegawai);
                                break;
                            case 4:
                                sql.Get();
                                break;

                        }
                        break;
                    case 2:
                        Console.WriteLine("Program Salary  ");
                        Console.WriteLine("1 - Insert {0}2 - Update {0}3 - Delete {0}4 -SeeData", Environment.NewLine);
                        Console.Write("Enter Choice(1-5):");
                        var Inputsalary = int.Parse(Console.ReadKey().KeyChar.ToString());
                        switch (Inputsalary)
                        {
                            case 1:
                                sqlSalary.Insert(salary);
                                break;
                            case 2:
                                sqlSalary.Update(salary);
                                break;
                            case 3:
                                sqlSalary.Delete(salary);
                                break;
                            case 4:
                                sqlSalary.Get();
                                break;
                        }
                        
                        break;
                    case 3:
                        Console.WriteLine("Program Perizinan  ");
                        Console.WriteLine("1 - Insert {0}2 - Update {0}3 - Delete {0}4 -SeeData", Environment.NewLine);
                        Console.Write("Enter Choice(1-5):");
                        var inputcuti = int.Parse(Console.ReadKey().KeyChar.ToString());
                        switch (inputcuti)
                        {
                            case 1:
                                sqlCuti.Insert(cutiPegawai);
                                break;
                            case 2:
                                sqlCuti.Update(cutiPegawai);
                                break;
                            case 3:
                                sqlCuti.Delete(cutiPegawai);
                                break;
                            case 4:
                                sqlCuti.Get();
                                break;
                        }
                        break;
                    case 4:
                        Console.WriteLine("Program Daftar Anggota ");
                        Console.WriteLine("1 - Insert {0}2 - Update {0}3 -SeeData", Environment.NewLine);
                        Console.Write("Enter Choice(1-5):");
                        var user = int.Parse(Console.ReadKey().KeyChar.ToString());
                        switch (user)
                        {
                            case 1:
                                sqlRegist.Insert(regist);
                                break;
                            case 2:
                                sqlRegist.Update(regist);
                                break;
                            case 3:
                                sqlRegist.Get();
                                break;
                        }
                        break;
                    case 5:
                        Console.WriteLine("Menu Lainnya");
                        Console.WriteLine("1 - Perhitungan Gaji {0}2 - Penugasan {0}3 - Calculator Sederhana", Environment.NewLine);
                        Run.HRProgram();
                        break;
                }
                Console.Write("Apakah Anda ingin melanjutkan? [Ya/Tidak]: ");
                string pilihan = Console.ReadLine();

                if (pilihan.ToLower() == "tidak")
                {
                    break;
                }
            }
            

            /*Pegawai pegawai = new Pegawai()
            {
                PegawaiName = "Ani",
                 IDDept = 2,
                 IDPosition = 7,
                 Phone = "+6285887173252",
                 Addres = "Jalan Kali dirumah mulu",
                 EmailPegawai = "Pegawai12@mail.com",
                 IDSalary = 5
             };
            Run.Insert(pegawai);*/

            /*Pegawai pegawai = new Pegawai()
            {
                IDPegawai = 12

            };
            Run.Delete(pegawai);*/

            /* Salary salary = new Salary()
             {
                 IDSalary = 14,
                 Amount = 5000000
             };
             Run.Update(salary);*/
            //Run.GetDataDetailSalary();
            /* Run.GetData();
             Run.GetById(2);*/






        }

        void Login(Model.REGIST login)
        {
            string query = "Select EmailPegawai from REGIST where EmailPegawai = @email and Passwords = @pass";
            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection); //query, sqlConnection
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = query;

            SqlParameter ParaEmail = new SqlParameter();
            ParaEmail.ParameterName = "@email";
            ParaEmail.Value = login.EmailPegawai;

            SqlParameter ParaPass = new SqlParameter();
            ParaPass.ParameterName = "@pass";
            ParaPass.Value = login.Passwords;
            sqlCommand.Parameters.Add(ParaEmail);
            sqlCommand.Parameters.Add(ParaPass);
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
             

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read()==true)
                        {
                            
                            Console.WriteLine("Selamat Datang " + sqlDataReader[0]);

                        }
                    }
                    else
                    {
                        Console.WriteLine("Email or/and Password is/are invalid. Please try again");
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

        void GetData()
        {
            string query = "SELECT * FROM Department";

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
                            Console.WriteLine(sqlDataReader[0] + " - "
                                + sqlDataReader[1] + " - " + sqlDataReader[2]
                                + " - " + sqlDataReader[3]);
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
        
        void GetByIdDepartment(int DeptID)
        {
            string query = "SELECT * FROM Department WHERE IDDept = @id";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@id";
            sqlParameter.Value = DeptID;

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.Add(sqlParameter);
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + " - "
                                + sqlDataReader[1] + " - " + sqlDataReader[2]
                                + " - " + sqlDataReader[3]);
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

        void HRProgram()
        {
            Methode programHR = new Methode();
            for (; ; )
            {
                Console.WriteLine("Welcome to Program HR!");
                Console.WriteLine("---------------------");
                Console.WriteLine("Please Choice ");
                Console.WriteLine("1 - Perhitungan Gaji {0}2 - Penugasan {0}3 - Calculator Sederhana", Environment.NewLine);
                Console.Write("Enter Choice(1-3):");
                var userInput = int.Parse(Console.ReadKey().KeyChar.ToString());
                Console.WriteLine();
                switch (userInput)
                {
                    case 1:
                        GetUserInputGaji(programHR);
                        var getOperationCount = new double[]{
                                       programHR.CountingGaji()
                                };
                        Console.WriteLine(getOperationCount[userInput - 1]);
                        Console.ReadKey();
                        break;
                    case 2:
                        int jumlah;
                        Console.Write("Masukkan jumlah Pegawai yang ingin di Assign : ");
                        jumlah = int.Parse(Console.ReadLine());
                        int[] angka = new int[jumlah];  // ukuran array sesuai inputan pada variabel jumlah

                        Console.WriteLine("");

                        for (int a = 1; a <= angka.Length; a++)
                        {
                            Console.Write("Masukkan nama Pegawai " + a + " : ");
                            string sa = Console.ReadLine();
                        }

                        Console.Write("Press any key to continue . . . ");
                        Console.ReadKey(true);
                        break;
                    case 3:

                        for (; ; )
                        {
                            Console.WriteLine("Welcome to basic calculator! Enter a number. {0}1 - Addition{0}2 - Substraction{0}3 - Multiplication{0}4 - Division", Environment.NewLine);
                            var inputCal = int.Parse(Console.ReadKey().KeyChar.ToString());
                            Console.WriteLine();
                            GetUserInputCal(programHR);
                            var getOperationSUB = new double[]{
                                                       programHR.Counting(),
                                                       programHR.Subtraction(),
                                                       programHR.Multiplication(),
                                                       programHR.Division()
                                        };
                            Console.WriteLine(getOperationSUB[inputCal - 1]);
                            Console.ReadKey();
                            Console.Write("Apakah Anda ingin melanjutkan? [Ya/Tidak]: ");
                            string pilih = Console.ReadLine();

                            if (pilih.ToLower() == "tidak")
                            {
                                break;
                            }
                        }
                        break;
                }
                Console.Write("Apakah Anda ingin melanjutkan? [Ya/Tidak]: ");
                string pilihan = Console.ReadLine();

                if (pilihan.ToLower() == "tidak")
                {
                    break;
                }
            }
        }

        static void GetUserInputGaji(Methode programHR)
        {
            Console.WriteLine("Masukkan Jumlah Absen ");
            programHR.jumlahAbsen = double.Parse(Console.ReadLine());
            Console.WriteLine("Masukkan Jumlah Gaji Utama");
            programHR.gajiUtama = double.Parse(Console.ReadLine());
            Console.WriteLine("Masukkan Jumlah Lembur");
            programHR.lembur = double.Parse(Console.ReadLine());
            Console.WriteLine("Masukkan Jumlah Bonus");
            programHR.bonus = double.Parse(Console.ReadLine());
        }
        static void GetUserInputCal(Methode programHR)
        {
            Console.WriteLine("Masukkan Angka ");
            programHR.angka = double.Parse(Console.ReadLine());
            Console.WriteLine("Masukkan Angka");
            programHR.angka2 = double.Parse(Console.ReadLine());

        }
        // yangn non void ada di kelas methode ya


        
    }

    abstract class TSQL
    {
        public abstract void Insert(Method.Pegawai pegawai);
        public abstract void Insert(Method.Salary salary);
        public abstract void Insert(Method.REGIST regist);
        public abstract void Insert(Method.CutiPegawai cutiPegawai);
        public abstract void Update(Method.Pegawai pegawai);
        public abstract void Update(Method.Salary salary);
        public abstract void Update(Method.CutiPegawai cutiPegawai);
        public abstract void Update(Method.REGIST regist);
        public abstract void Get();
        public abstract void Delete(Method.Pegawai pegawai);
        public abstract void Delete(Method.Salary salary);
        public abstract void Delete(Method.CutiPegawai cutiPegawai);
    }

    /*interface TSQL
    {
        public void Insert();
        public void Update();
        public void Delete();
        public void Get();
    }*/
} 
    

