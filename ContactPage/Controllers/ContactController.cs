using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContactPage.Models;
using ContactPage.Helpers;
using System;
using System.Linq;
using Microsoft.Extensions.Options;

namespace ContactPage.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactDbContext _context; 
        private readonly IMailHandler _mailHandler;
        private readonly IOptions<MailHandler> _mailOptions;

        public ContactController(IMailHandler mailHandler, ContactDbContext context, IOptions<MailHandler> mailOptions)
        {
            _mailHandler = mailHandler;
            _context = context;
            _mailOptions = mailOptions;
        }

        // GET: Contact/MessageSended
        public IActionResult MessageSended(bool messageSended = false)
        {
            if (messageSended)
            {
                return View("MessageSended");
            }
            return RedirectToAction(nameof(Create));
        }

        // GET: Contact/Create
        public IActionResult Create()
        {
            ViewData["AreaOfInterest"] = new SelectList(_context.MessagesAreaOfInterest, "Id", "AreaOfInterest");
            return View("Create");
        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone,AreaOfInterest,ContactMessage")] ContactMessages contactMessages)
        {
            if (ModelState.IsValid)
            {
                await SaveRecordToDb(contactMessages);
                await SendMail(contactMessages);
                return RedirectToAction(nameof(MessageSended), new {MessageSended = true});
            }
            ViewData["AreaOfInterest"] = new SelectList(_context.MessagesAreaOfInterest, "Id", "AreaOfInterest", contactMessages.AreaOfInterest);
            return View(contactMessages);
        }

        private async Task SaveRecordToDb(ContactMessages contactMessages)
        {
            try
            {
                _context.Add(contactMessages);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void ConfigureMail()
        {
            _mailHandler.Configure(_mailOptions.Value.ReceiverEmailAddress, _mailOptions.Value.ReceiverDisplayName, _mailOptions.Value.ReceiverEmailPassword,
                _mailOptions.Value.Host, _mailOptions.Value.Port);
        }

        private async Task SendMail(ContactMessages contactMessages)
        {
            ConfigureMail();
            //var areaOfInterest = _context.MessagesAreaOfInterest.ToList().First(p => p.Id == contactMessages.AreaOfInterest).AreaOfInterest.ToString();
            await _mailHandler.SendEmail(contactMessages.FirstName, contactMessages.LastName, contactMessages.Email,
                                  contactMessages.Phone, "New Contact Message", contactMessages.ContactMessage);
        }
    }
}
