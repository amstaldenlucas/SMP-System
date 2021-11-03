using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Areas.Web.ViewModels;
using SMPSystem.Data;
using SMPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Controllers
{
    [Authorize]
    [Area("Web")]
    public class UserProductionHistoryController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserProductionHistoryController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(OrderWithDbUserVm vm)
        {
            var orderProduction = await _dbContext.ProductionOrders
                .FirstOrDefaultAsync(x => x.Code == vm.ProductionOrderCode);

            vm.ProductionOrderId = orderProduction.Id;
            var orderProductionItem = await _dbContext.OrderProductSteps
                .Where(x => x.OrderId == orderProduction.Id)
                .Where(x => !x.FinalizedStatus)
                .OrderBy(x => x.ExecutionOrder)
                .FirstOrDefaultAsync();

            var productProductionStep = await _dbContext.ProductProductionSteps
                                                            .FindAsync(orderProductionItem.ProductProductionStepId);
            productProductionStep.Product = await _dbContext.Products
                                                .FindAsync(productProductionStep.ProductId);

            productProductionStep.ProductionStep = await _dbContext.ProductionSteps
                                                .FindAsync(productProductionStep.ProductionStepId);

            orderProductionItem.ProductProductionStep = productProductionStep;

            if (orderProductionItem.InitialQuantity == 0)
                orderProductionItem.InitialQuantity = orderProduction.TotalQuantity;

            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == vm.DbUserId);

            var dimensionsToCheck = await _dbContext.ProductStepDimensions
                .Include(x => x.ProductionStep)
                .Where(x => x.ProductId == productProductionStep.Product.Id)
                .Where(x => x.ProductionStepId == productProductionStep.ProductionStep.Id)
                .ToListAsync();


            var userProducingVm = new UserProducingVm();

            userProducingVm.DbUserId = user.Id;
            userProducingVm.ProductId = productProductionStep.Product.Id;
            userProducingVm.Order = orderProduction;
            userProducingVm.DbUser = user;
            userProducingVm.DimensionsToCheck = dimensionsToCheck;
            userProducingVm.Product = productProductionStep.Product;
            userProducingVm.OrderProductStep = orderProductionItem;
            userProducingVm.ProductionStepId = orderProductionItem.ProductProductionStep.Id;


            var userProducHistory = await _dbContext.UserProductionHistories
                .Where(x => x.DbUserId == user.Id)
                .Where(x => x.ProductionOrderId == orderProduction.Id)
                .Where(x => x.ProductionStepId == productProductionStep.Id)
                .Where(x => x.Status)
                .FirstOrDefaultAsync();

            if (userProducHistory != null)
                userProducingVm.UserProductionHistory = userProducHistory;
            else
            {
                userProducHistory = new UserProductionHistory();
                userProducHistory.DbUserId = user.Id;
                userProducHistory.ProductionOrderId = orderProduction.Id;
                userProducHistory.ProductionStepId = productProductionStep.Id;
                userProducHistory.ProductId = productProductionStep.ProductId;
                userProducHistory.Status = true;
                userProducHistory.ProducedQuantity = 0;

                await _dbContext.AddAsync(userProducHistory);
                await _dbContext.SaveChangesAsync();
            }

            userProducingVm.UserProductionHistory = userProducHistory;
            userProducingVm.DimensionsToCheck = await GetProductStepDimensions(userProducHistory.ProductId, userProducHistory.ProductionStepId);
            userProducingVm.MeasuringHistories = await GetMeasuresToRecord(userProducingVm);

            //vm.MeasuringHistories = 
            // ProductionorderId
            return View(userProducingVm);
        }

        public async Task<IActionResult> SumQuantity(UserProducingVm vm)
        {
            var itemsToChange = await PrepareToChangeQuantity(vm);

            itemsToChange.UserHistory.ProducedQuantity++;
            itemsToChange.OrderProductStep.ProducedQuantity++;
            await _dbContext.SaveChangesAsync();

            var orderWithUserVm = CreteOrderWithUserVm(vm);
            return RedirectToAction(nameof(Index), vm);
        }

        public async Task<IActionResult> SubtractQuantity(UserProducingVm vm)
        {
            var itemsToChange = await PrepareToChangeQuantity(vm);

            if (itemsToChange.UserHistory.ProducedQuantity > 0)
                itemsToChange.UserHistory.ProducedQuantity--;

            if (itemsToChange.OrderProductStep.ProducedQuantity > 0)
                itemsToChange.OrderProductStep.ProducedQuantity--;

            await _dbContext.SaveChangesAsync();

            var orderWithUserVm = CreteOrderWithUserVm(vm);
            return RedirectToAction(nameof(Index), vm);
        }

        private async Task<(UserProductionHistory UserHistory, OrderProductStep OrderProductStep)> PrepareToChangeQuantity(UserProducingVm vm)
        {
            var userProducHistory = await _dbContext.UserProductionHistories
                .Where(x => x.DbUserId == vm.DbUserId)
                .Where(x => x.ProductionOrderId == vm.ProductionOrderId)
                .Where(x => x.ProductionStepId == vm.ProductionStepId)
                .Where(x => x.Status)
                .FirstOrDefaultAsync();

            var orderProductStep = await _dbContext.OrderProductSteps
                .Include(x => x.ProductProductionStep)
                .Where(x => x.OrderId == vm.ProductionOrderId)
                .Where(x => x.ProductProductionStepId == vm.ProductionStepId)
                .FirstOrDefaultAsync();

            return (userProducHistory, orderProductStep);
        }

        private async Task<OrderWithDbUserVm> CreteOrderWithUserVm(UserProducingVm userProducingVm)
        {
            var order = await _dbContext.ProductionOrders.FindAsync(userProducingVm.ProductionOrderId);
            var vm = new OrderWithDbUserVm();

            vm.DbUserId = userProducingVm.DbUserId;
            vm.ProductionOrderCode = order.Code;
            return vm;
        }

        private async Task<List<ProductStepDimension>> GetProductStepDimensions(int productId, int productionStepId)
        {
            return await _dbContext.ProductStepDimensions
                .Include(x => x.ProductionStep)
                .Where(x => x.ProductId == productId)
                .Where(x => x.ProductionStepId == productionStepId)
                .ToListAsync();
        }

        private async Task<List<MeasuringHistory>> GetMeasuresToRecord(UserProducingVm vm)
        {
            var measuresToRecord = new List<MeasuringHistory>();
            foreach (var item in vm.DimensionsToCheck)
            {
                var newMeasuring = await MeasuringHistory(vm, item);
                if (newMeasuring != null)
                    measuresToRecord.Add(newMeasuring);
            }
            return measuresToRecord;
        }


        // Pegar as cotas que serão medidas na próxima adição
        private async Task<MeasuringHistory> MeasuringHistory(UserProducingVm vm, ProductStepDimension dimension)
        {
            var recordByQuantity = false;
            var recordByTime = false;

            //var productStepDimension = vm.DimensionsToCheck
            //    .Where(x => x.Id == measuring.ProductStepDimensionId)
            //    .FirstOrDefault();

            var lastHistory = await _dbContext.MeasuringHistories
                .Where(x => x.ProductId == vm.ProductId)
                .Where(x => x.DbUserId == vm.DbUserId)
                .Where(x => x.ProductionStepId == vm.ProductionStepId)
                .OrderByDescending(x => x.Created)
                .FirstOrDefaultAsync();

            var productStep = await _dbContext.ProductProductionSteps
                .Where(x => x.ProductId == vm.ProductId)
                .Where(x => x.ProductionStepId == vm.ProductionStepId)
                .FirstOrDefaultAsync();

            var nextQuantity = vm.OrderProductStep.ProducedQuantity + 1;
            recordByQuantity = (lastHistory?.ProducedQuantity + dimension.FrequencyToMeasureInQuantity <= nextQuantity) || lastHistory == null;

            var nextTime = lastHistory?.Created.AddMinutes(dimension.FrequencyToMeasureInMinutes);
            var AverageTimeToProduce = (productStep.ProductionTimeInSeconds + productStep.MaximumProductionTimeInSeconds) / 2;
            recordByTime = DateTime.Now.AddSeconds(AverageTimeToProduce) >= nextTime;

            if (recordByQuantity || recordByTime)
                return new MeasuringHistory()
                {
                    ProducedQuantity = nextQuantity,
                    ProductId = vm.ProductId,
                    ProductionOrderId = vm.Order.Id,
                    DbUserId = vm.DbUserId,
                    ProductStepDimensionId = dimension.Id,
                    ProductionStepId = dimension.ProductId,
                    ProductStepDimension = dimension,
                };

            return null;
        }

        public async Task<IActionResult> FinalizeUserProductionHistory(UserProducingVm vm)
        {
            var userProducHistory = await _dbContext.UserProductionHistories
                .Where(x => x.DbUserId == vm.DbUserId)
                .Where(x => x.ProductionOrderId == vm.ProductionOrderId)
                .Where(x => x.ProductionStepId == vm.ProductionStepId)
                .Where(x => x.Status)
                .FirstOrDefaultAsync();

            userProducHistory.Status = false;
            await _dbContext.SaveChangesAsync();
            return View();

            // ainda falta informar as cotas da última peça e rotina para finalizar a ordem
        }
    }
}
