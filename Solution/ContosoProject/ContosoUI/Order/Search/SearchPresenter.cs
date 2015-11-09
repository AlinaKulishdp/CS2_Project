using ContosoUI.Order.Search;
using Domain.DAO;
using Data.EFData;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContosoUI.Order.Search
{
    class SearchPresenter
    {
        readonly SearchView view;
        public List<SearchViewModel> viewModel { get; set; } 

        readonly IOrderRepository orderModel = new OrderDao();
        readonly IOrderStatusRepository orderStatusModel = new OrderStatusDao();

        private List<Domain.Entities.Order> ordersList = new List<Domain.Entities.Order>();
        readonly List<OrderStatus> statuses = new List<OrderStatus>();

        public List<OrderStatus> StatusesList
        {
            get { return statuses; }
        }

        public SearchPresenter(SearchView view)
        {
            this.view = view;
            viewModel = new List<SearchViewModel>();
            statuses = orderStatusModel.GetAll().Distinct().ToList();
            statuses.Add(new OrderStatus() { Status = "Все статусы" });
        }

        public void SelectOrdersByStatus(OrderStatus status)
        {
            if (status.Status == "Все статусы")
            {
                ordersList = orderModel.GetAll().ToList();
                FillViewModel();
            }
            else if (statuses.Select(x => x.Status == status.Status).ToList()[0])
            {
                ordersList = orderModel.GetOrderByStatus(status).ToList();
                FillViewModel();
            }
            else
            {
                viewModel.Clear();
                MessageBox.Show("Не существует заказов с таким статусом", buttons: MessageBoxButtons.OK, caption: "Уведомление");
            } 

        }

        private void FillViewModel ()
        {
            viewModel.Clear();

            foreach (var order in ordersList)
            {
                viewModel.Add(new SearchViewModel()
                {
                    Id = order.Id,
                    Status = order.Status,
                    Customer = order.Customer,
                    countOfGoods = order.GoodsList.Count,
                    TotalCost = order.TotalCost,
                });
            }
        }
}

    public class SearchViewModel
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public Customer Customer { get; set; }
        public int countOfGoods { get; set; }
        public double TotalCost { get; set; }
    }
}
