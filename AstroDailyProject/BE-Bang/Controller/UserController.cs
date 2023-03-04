using AstroDailyProject.BE_Bang.Model;
using AstroDailyProject.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AstroDailyProject.BE_Bang.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly AstroDailyDBContext _context;

        public UserController(AstroDailyDBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetProfileById(string id)
        {
            var user = _context.Users.SingleOrDefault(lo => lo.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("create")]
        public IActionResult CreateAccount(UserModel userModel)
        {
            try
            {
                var checkUserName = _context.Users.SingleOrDefault(u => u.Username == userModel.UserName);
                if (checkUserName == null)
                {
                    var user = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Username = userModel.UserName,
                        Password = userModel.Password,
                        Email = addTailEmail(userModel.Email),
                        Phone = userModel.Phone,
                        FirstName = userModel.FirstName,
                        LastName = userModel.LastName,
                        RoleId = 2,
                        Status = true,
                    };
                    _context.Add(user);
                    _context.SaveChanges(); ;
                    return Ok(user);
                }
                else
                {
                    return BadRequest("User Name existed!");
                }
                
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}/update")]
        public IActionResult EditProfile(string id, UserModel userModel)
        {
            var user = _context.Users.SingleOrDefault(lo => lo.Id == id);
            if (id != user.Id.ToString()) { return BadRequest(); }
            if (user != null)
            {
                user.Email = addTailEmail(userModel.Email) == null ? user.Email : addTailEmail(userModel.Email);
                user.Phone = userModel.Phone == null ? user.Phone : userModel.Phone;
                user.FirstName = userModel.FirstName == null ? user.FirstName : userModel.FirstName;
                user.LastName = userModel.LastName == null ? user.LastName : userModel.LastName;
                user.DobDay = userModel.DobDay;
                user.DobMonth = userModel.DobMonth ;
                user.DobYear = userModel.DobYear;
                user.BirthPlace = userModel.BirthPlace == null ? user.BirthPlace : userModel.BirthPlace;
                user.BirthTime = userModel.BirthTime == null ? user.BirthTime : userModel.BirthTime;
                user.Status = true;
                user.RoleId = 2;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }


        }

        [HttpPut("{id}/delete")]
        public IActionResult DeleteAccount(string id)
        {
            var user = _context.Users.SingleOrDefault(lo => lo.Id == id);
            if (user != null)
            {
                user.Status = Convert.ToBoolean(0);
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("{username}/password")]
        public IActionResult ChangePassword(string username, ChangeModel changeModel)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(lo => lo.Username == username);
                if (username != user.Username.ToString()) { return BadRequest(); }
                if (user != null)
                    {
                        var userPass = _context.Users.FirstOrDefault(lo => lo.Password == changeModel.password);
                        if (userPass != null)
                        {
                            if (changeModel.newPassword == changeModel.reNewPassword)
                            {
                                var change = new User { Password = changeModel.newPassword };
                                _context.SaveChanges();
                                return NoContent();
                            }
                            else
                            {
                                return StatusCode(409, new { StatusCode = 409, message = "Re-password incorrect" });
                            }
                        }
                        else
                        {
                            return StatusCode(409, new { StatusCode = 409, message = "Password incorrect" });
                        }
                    }
                    return NotFound();
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("{username}/email")]
        public async Task<IActionResult> SendOtp(string userName)
        {
            try
            {
                // Generate a random 6-digit OTP
                Random random = new Random();
                int otp = random.Next(100000, 999999);

                //search database
                var user = _context.Users.SingleOrDefault(lo => lo.Username == userName);
                if (user != null)
                {
                    user.Otp = Convert.ToString(otp);
                    _context.SaveChanges();

                    // Save the OTP to the database or some other storage
                    // so that it can be verified later

                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("bangdase150648@fpt.edu.vn");
                    message.To.Add(user.Email);
                    message.Subject = "Password Reset OTP";
                    message.Body = "Your OTP to reset your password is: " + otp;

                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.Credentials = new NetworkCredential("bangdase150648@fpt.edu.vn", "kouunaofwdtffjsp");
                    client.EnableSsl = true;

                    await client.SendMailAsync(message);

                    return Ok();


                }
                else
                {
                    return NotFound();
                }

                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("password/change")]
        public async Task<IActionResult> ResetPasswordWithOTP(ChangeModel changeModel)
        {
            var user = _context.Users.SingleOrDefault(lo => lo.Otp == changeModel.otp);
            if (user != null)
            {
                if (changeModel.newPassword == changeModel.reNewPassword)
                {
                    var change = new User {Password = changeModel.newPassword };
                    _context.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return StatusCode(409, new { StatusCode = 409, message = "Re-password incorrect" });
                }
            }
            return StatusCode(409, new { StatusCode = 409, message = "OTP incorrect" });
        }

        private string addTailEmail(string email)
        {
            if (!email.Contains("@")) //auto add ".com"              
            {
                return email + "@gmail.com";
            }
            return email;
        }
    }
}
