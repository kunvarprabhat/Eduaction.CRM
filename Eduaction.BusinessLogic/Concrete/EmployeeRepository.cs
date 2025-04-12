using Eduaction.BusinessLogic.Abstract;
using Eduaction.DataModel;
using Eduaction.DataModel.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Reflection.Emit;
using System.Net.Mail;



using Eduaction.On.Web.Comman;
using Eduaction.DataModel.Comman;

namespace Eduaction.BusinessLogic.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EducationDbContext _DBContext;

        public EmployeeRepository(EducationDbContext context)
        {
            this._DBContext = context;
        }
        public async Task<EmployeeMaster> CreateEmployee(EmployeeMaster employee)
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    // Generate year part: last two digits of current year
                    string yearPart = DateTime.Now.ToString("yy"); // "25" for 2025
                    // Static part
                    string staticPart = "2215";
                    // You can optionally make this dynamic (e.g., for branch/department ID)
                    string regionOrBranch = "02";
                    // Fixed prefix
                    string prefix = "CIPC";
                    // Get the last employee with matching prefix (filter to only EmpCodes starting with current prefix)
                    var empCodePrefix = $"E{yearPart}{staticPart}{regionOrBranch}{prefix}";
                    var lastEmp = await _DBContext.EmployeeMasters
                        .Where(e => e.EmpCode.StartsWith(empCodePrefix))
                        .OrderByDescending(e => e.EmpCode)
                        .FirstOrDefaultAsync();
                    int sequenceNumber = 1;

                    if (lastEmp != null)
                    {
                        // Extract the last numeric part and increment
                        string lastEmpCode = lastEmp.EmpCode;
                        string lastSequenceStr = lastEmpCode.Substring(empCodePrefix.Length);
                        if (int.TryParse(lastSequenceStr, out int lastSequence))
                        {
                            sequenceNumber = lastSequence + 1;
                        }
                    }
                    // Pad the sequence with leading zeros, e.g., 0001, 0010, 0100, etc.
                    string empCode = $"{empCodePrefix}{sequenceNumber:D4}";
                    // Generate a password and compute its hash
                    var rawPassword = GeneratePassword();
                   // string hashedPassword = ComputeHash(rawPassword, string.Empty, null);
                    string hashedPassword = HashPassword(rawPassword);
                    //  var localIpAddress = GetLocalIpAddress();
                    var localIpAddress = Securites.GetLocalIpAddress();
                    employee.Ipaddress = localIpAddress;
                    employee.EmpCode = empCode;
                    employee.AddedBy = 1;
                    employee.AddedDate = DateTime.Now;
                    employee.IsActive = true;
                    // Create login details for the employee
                    var loginDetail = new LoginInfo
                    {
                        LoginId = employee.EmpCode,
                        Password = hashedPassword,
                        IsFirstLogin = true,
                        AddedBy = 1,
                        AddedDate = employee.AddedDate,
                        ModifiedDate = employee.ModifiedDate,
                        Ipaddress = employee.Ipaddress,
                        IsActive = employee.IsActive
                    };
                    // Add login details to the employee
                    employee.LoginInfos.Add(loginDetail);
                    // Add employee to the database
                    await _DBContext.EmployeeMasters.AddAsync(employee);
                    // Save changes to the database
                    await _DBContext.SaveChangesAsync();
                    // ✅ Send Login Info Email
                   await SendLoginInfoEmail(employee.EmailId, empCode, rawPassword);
                    // Complete the transaction
                    scope.Complete();
                    // Return success response
                    return employee;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        public async Task SendLoginInfoEmail(string toEmail, string loginId, string password)
        {
            try
            {
                var fromEmail = "Kunavrprabhat44@gmail.com";
                var appPassword = "Suman@2001"; // Use App Password here

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromEmail, appPassword),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = "Your Login Details",
                    Body = $"Hello,\n\nHere are your login credentials:\nLogin ID: {loginId}\nPassword: {password}\n\nPlease change your password after first login.",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email sending failed: {ex.Message}");
                // Handle or rethrow
            }
        }
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
        public static string ComputeHash(string plainText, string hashAlgorithm, byte[] saltBytes)
        {
            // If salt is not specified, generate it.
            if (saltBytes == null)
            {
                // Define min and max salt sizes.
                int minSaltSize = 4;
                int maxSaltSize = 8;

                // Generate a random number for the size of the salt.
                Random random = new Random();
                int saltSize = random.Next(minSaltSize, maxSaltSize);

                // Allocate a byte array, which will hold the salt.
                saltBytes = new byte[saltSize];

                // Initialize a random number generator.
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                // Fill the salt with cryptographically strong byte values.
                rng.GetNonZeroBytes(saltBytes);
            }

            // Convert plain text into a byte array.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Allocate array, which will hold plain text and salt.
            byte[] plainTextWithSaltBytes =
            new byte[plainTextBytes.Length + saltBytes.Length];

            // Copy plain text bytes into resulting array.
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];

            // Append salt bytes to the resulting array.
            for (int i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

            HashAlgorithm hash;

            // Make sure hashing algorithm name is specified.
            if (hashAlgorithm == null)
                hashAlgorithm = "";

            // Initialize appropriate hashing algorithm class.
            switch (hashAlgorithm.ToUpper())
            {

                case "SHA384":
                    hash = new SHA384Managed();
                    break;

                case "SHA512":
                    hash = new SHA512Managed();
                    break;

                default:
                    hash = new MD5CryptoServiceProvider();
                    break;
            }

            // Compute hash value of our plain text with appended salt.
            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            // Create array which will hold hash and original salt bytes.
            byte[] hashWithSaltBytes = new byte[hashBytes.Length +
            saltBytes.Length];

            // Copy hash bytes into resulting array.
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            // Append salt bytes to the result.
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            // Convert result into a base64-encoded string.
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            // Return the result.
            return hashValue;
        }
        private string GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ipAddress = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            return ipAddress?.ToString() ?? "-None-";
        }
        private static string GetRandomString(int length, IEnumerable<char> characterSet)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
        }
        public static string GeneratePassword()
        {
            const string alphanumericCharacters =
          "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
          "abcdefghijklmnopqrstuvwxyz" +
          "0123456789";
            return GetRandomString(8, alphanumericCharacters);
        }
        public Task<bool> DeleteEmployee(int modelId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeMaster>> GetAllEmployee()
        {
            using (EducationDbContext context = new EducationDbContext())
            {
                return await context.EmployeeMasters.Where(x => x.IsActive == true).ToListAsync();
            }
        }

        public Task<EmployeeMaster> GetEmployeeById(int modelId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEmployee(int modelId, EmployeeMaster model)
        {
            throw new NotImplementedException();
        }
    }
}
