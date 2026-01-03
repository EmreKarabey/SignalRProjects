using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRApiProject.Dto.Notification;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationServices _notificationServices;

        public NotificationController(INotificationServices notificationServices)
        {
            _notificationServices = notificationServices;
        }
        [HttpGet("GetCount")]
        public IActionResult GetCount()
        {
            var count = _notificationServices.NotificationCount();
            return Ok(count);
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var list = _notificationServices.GetList();

            return Ok(list);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var entity = _notificationServices.GetById(id);

            if (entity == null) return NotFound();

            _notificationServices.Delete(entity);

            return Ok("Başarılı Bir Şekilde Bildirim Silindi");
        }

        [HttpPut]
        public IActionResult UpdateNotification(Notification notification)
        {
            _notificationServices.Update(notification);

            return Ok("Başarılı Bir Şekilde Güncellendi");
        }
        [HttpPut("UpdateRead")]
        public IActionResult UpdateRead(UpdateNotification updateNotification)
        {
            var entity = _notificationServices.GetById(updateNotification.NotificationID);

            if (entity == null) return NotFound();

            entity.Status = true;

            _notificationServices.Update(entity);

            return Ok("Başarılı Bir Şekilde Güncellendi");
        }

        [HttpPut("UpdateNotRead")]
        public IActionResult UpdateNotRead(UpdateNotification updateNotification)
        {
            var entity = _notificationServices.GetById(updateNotification.NotificationID);

            if (entity == null) return NotFound();

            entity.Status = false;

            _notificationServices.Update(entity);

            return Ok("Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _notificationServices.GetById(id);

            if (entity == null) return NotFound();

            return Ok(entity);
        }


    }
}
