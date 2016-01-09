using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WpfAuthenticationSample
{
	public interface IAuthenticationService
  {
		User AuthenticateUser(string username, string password);
	}

	public class AuthenticationService : IAuthenticationService
	{
		private class InternalUserData
		{
			public InternalUserData(string username, string email, string hashedPassword, string[] roles)
			{
				Username = username;
				Email = email;
				HashedPassword = hashedPassword;
				Roles = roles;
			}

			public string Username
			{
				get;
				private set;
			}

			public string Email
			{
				get;
				private set;
			}

			public string HashedPassword
			{
				get;
				private set;
			}

			public string[] Roles
			{
				get;
				private set;
			}
		}

		private static readonly List<InternalUserData> _users = new List<InternalUserData>() 
        { 
            // 123456
            new InternalUserData("mark", "mark@company.com", "RgACjj51V2ZAE1VAqcg+qHjVSc3tZx6VL1VhcsuhZqs=", new string[] { "Administrators" }), 
            // 2468
            new InternalUserData("john", "john@company.com", "xzZ8o7iWnJlk1oPXTxJfHyPMtFyhQrRnGpeKlfZmmR0=", new string[] { })
        };

		public User AuthenticateUser(string username, string clearTextPassword)
		{
            var userData = _users.FirstOrDefault(u => (string.Compare(u.Username, username, true) == 0) && u.HashedPassword.Equals(CalculateHash(clearTextPassword, u.Username)));
			if (userData == null)
				throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");

			return new User(userData.Username, userData.Email, userData.Roles);
		}

		private string CalculateHash(string clearTextPassword, string salt)
		{
			// Convert the salted password to a byte array
			byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
			// Use the hash algorithm to calculate the hash
			HashAlgorithm algorithm = new SHA256Managed();
			byte[] hash = algorithm.ComputeHash(saltedHashBytes);

			// Return the hash as a base64 encoded string to be compared to the stored password
			return Convert.ToBase64String(hash);
		}
	}
}
