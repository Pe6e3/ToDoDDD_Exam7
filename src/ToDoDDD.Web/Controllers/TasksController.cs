using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoDDD.BLL.Repositories;
using ToDoDDD.BLL.uow;
using ToDoDDD.DAL.Entities;

namespace ToDoDDD.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly UnitOfWork _uow;
        public TasksController(UnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            IEnumerable<Taska> tasks = _uow.TaskRepository.GetIncluded();
            return View(tasks);
        }


        public IActionResult Create()
        {
            List<Status> Statuses = _uow.StatusRepository.Get().ToList();
            ViewBag.StatusNew = Statuses.FirstOrDefault(s => s.StatusName == "Новая").Id;
            List<Prioritet> Prioritets = _uow.PrioritetRepository.Get().ToList();
            ViewBag.Prioritetes = new SelectList(Prioritets, "Id", "PrioritetName");

            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id", "TaskName", "Desc", "PrioritetId", "StatusId", "CreateDate")] Taska task)
        {
            _uow.TaskRepository.Insert(task);
            _uow.TaskRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(Guid id)
        {
            return View(_uow.TaskRepository.GetByIdIncluded(id));
        }


        public IActionResult ChangeStatus(Guid id)
        {
            _uow.TaskRepository.ChangeStatus(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            return View(_uow.TaskRepository.GetByIdIncluded(id));
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(Guid id)
        {
            Taska myTask = _uow.TaskRepository.GetByIdIncluded(id);

            if (myTask == null)
            {
                return NotFound();
            }
            _uow.TaskRepository.Delete(myTask);
            _uow.TaskRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
