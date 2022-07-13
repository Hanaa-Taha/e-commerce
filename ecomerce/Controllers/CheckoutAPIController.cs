using ecomerce.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutAPIController : ControllerBase
    {

        public class emptyStr { }
        emptyStr emptyString = new emptyStr { };
        private readonly dbSmartAgricultureContext _context;
        public CheckoutAPIController(dbSmartAgricultureContext context)
        {
            _context = context;
            

        }
        
        [HttpPost("AddInformation")]
        
        public async Task<ActionResult<CheckoutInfo>> AddInformation([FromBody] CheckoutInfo model)
        {
            if (!ModelState.IsValid) { return NotFound(); }

                var result = new CheckoutInfo
            {

                MemberId = model.MemberId,
                
                phone = model.phone,
                city = model.city,
                street = model.street,
                district = model.district,
                governorate = model.governorate,
                specialMarque = model.specialMarque,
                propertyNumber = model.propertyNumber 
            };
            _context.checkoutInfo.Add(result);
            await _context.SaveChangesAsync();
            return Ok(result);
           
           
        }
        [HttpGet("GetInformation/{Informationid}")]
        public async Task<ActionResult<CheckoutInfo>> GetTInformation(int Informationid)
        {
            var checkoutInfoId = await _context.checkoutInfo.Where(s => s.checkoutInfoId == Informationid).FirstOrDefaultAsync();


            if (checkoutInfoId == null)
            {
                return NotFound();
            }

            return checkoutInfoId;
        }








        //[HttpPost("OrderDetails")]

        //public async Task<ActionResult<Order_details>> OrderDetails([FromBody] Order_details model)
        //{
        //    if (!ModelState.IsValid) { return NotFound(); }

        //    var result = new Order_details
        //    {

        //        checkoutInfoId = model.checkoutInfoId,
        //        total = model.total,
        //        PaymentspaymentDetailsId = model.PaymentspaymentDetailsId,
        //        ModifiedDate = DateTime.UtcNow,
        //        CreatedDate = DateTime.UtcNow
        //    };
        //    _context.Order_details.Add(result);
        //    await _context.SaveChangesAsync();
        //    return Ok(result.orderDetailsId);


        //}


        //[HttpGet("GetOrderDetails/{OrderDetailsid}")]
        //public async Task<ActionResult<Order_details>> GetOrderDetails(int OrderDetailsid)
        //{
        //    var Order_details = await _context.Order_details.Include(s => s.checkoutInfo).Where(s => s.orderDetailsId == OrderDetailsid).FirstOrDefaultAsync();


        //    if (Order_details == null)
        //    {
        //        return NotFound();
        //    }

        //    return Order_details;
        //}


        //[HttpPost("PostOrderItems")]
        //public async Task<ActionResult<Order_items>> PostOrderItems(Order_items model)
        //{
        //    var oldOrderItems = await _context.Order_items.SingleOrDefaultAsync(s => s.orderItemsId == model.orderDetailsId && s.productId == model.productId);
        //    if (oldOrderItems != null)
        //    {
        //        oldOrderItems.Quantity = oldOrderItems.Quantity + 1;
        //        await _context.SaveChangesAsync();
        //        return Ok(emptyString);
        //    }
        //    else
        //    {
        //        Order_items orderItems = new Order_items
        //        {
        //            productId = model.productId,
        //            orderDetailsId = model.orderDetailsId,
        //            Quantity = 1,
        //            ModifiedDate = DateTime.UtcNow,
        //            CreatedDate = DateTime.UtcNow
        //        };
        //        _context.Order_items.Add(orderItems);

        //        await _context.SaveChangesAsync();

        //        return Ok(orderItems);
        //    }
        //}

        //[HttpGet("GetOrderItems/{orderDetailsId}")]
        //public async Task<ActionResult<IEnumerable<Order_items>>> GetOrderItems(int orderDetailsId)
        //{
        //    var Order_items = await _context.Order_items.Include(s => s.TblProduct).Where(s => s.orderDetailsId == orderDetailsId).ToListAsync();


        //    if (Order_items == null)
        //    {
        //        return NotFound();
        //    }

        //    return Order_items;
        //}


        //[HttpDelete("DeleteOrderItems/{OrderItemsid}")]
        //public async Task<IActionResult> DeleteOrderItems(int OrderItemsid)
        //{
        //    var orderItems = await _context.Order_items.SingleOrDefaultAsync(s => s.orderItemsId == OrderItemsid);
        //    if (orderItems == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Order_items.Remove(orderItems);
        //    await _context.SaveChangesAsync();

        //    return Ok(emptyString);
        //}


        //[HttpPatch("PatchOrderDetails/{OrderDetailsId}")]
        //public async Task<IActionResult> PatchOrderDetails([FromBody] JsonPatchDocument OrderDetails, [FromRoute] int OrderDetailsId)
        //{
        //    var orderDetails = await _context.Order_details.FindAsync(OrderDetailsId);
        //    if (orderDetails != null)
        //    {
        //        OrderDetails.ApplyTo(orderDetails);
        //        await _context.SaveChangesAsync();
        //    }
        //    return Ok(emptyString);
        //}

        [HttpPatch("PatchInformation/{CheckoutInformationId}")]
        public async Task<IActionResult> PatchInformation([FromBody] JsonPatchDocument CheckoutInfo, [FromRoute] int CheckoutInformationId)
        {
            var checkoutInformation = await _context.checkoutInfo.FindAsync(CheckoutInformationId);
            if (checkoutInformation != null)
            {
                CheckoutInfo.ApplyTo(checkoutInformation);
                await _context.SaveChangesAsync();
            }
            return Ok(emptyString);
        }



        //[HttpGet("GetPaymentDetails/{paymentDetailsId}")]
        //public async Task<ActionResult<payment_details>> GetPaymentDetails(int paymentDetailsId)
        //{
        //    var PaymentDetailsId = await _context.payment_details.Where(s => s.paymentDetailsId == paymentDetailsId).FirstOrDefaultAsync();


        //    if (PaymentDetailsId == null)
        //    {
        //        return NotFound();
        //    }

        //    return PaymentDetailsId;
        //}








        //[HttpPost("PostPaymentDetails")]

        //public async Task<ActionResult<payment_details>> PostPaymentDetails([FromBody] payment_details model)
        //{
        //    if (!ModelState.IsValid) { return NotFound(); }

        //    var result = new payment_details
        //    {

        //        amount = model.amount,
        //        provider = model.provider,
        //        status = model.status,
        //        ModifiedDate = DateTime.UtcNow,
        //        CreatedDate = DateTime.UtcNow
        //    };
        //    _context.payment_details.Add(result);
        //    await _context.SaveChangesAsync();
        //    return Ok(result);


        //}




        [HttpPost("PostAllDetails")]

        public async Task<ActionResult<CheckoutAllModels>> PostAllDetails([FromBody] CheckoutAllModels model )
        {
            if (!ModelState.IsValid) { return NotFound(); }

            var user = _context.checkoutInfo.Where(s => s.MemberId == model.userId).FirstOrDefault();
            //var createdAction = CreatedAtAction("OrderDetails", new { total = model.total , checkoutInfoId = user.checkoutInfoId , PaymentspaymentDetailsId  = 1}, model);
            //foreach (var product in model.productLists) { CreatedAtAction("PostOrderItems", new { orderDetailsId = createdAction, productId = product.productId, Quantity = product.quantity }, model); };



            if (!ModelState.IsValid) { return NotFound(); }

            var result = new Order_details
            {

                checkoutInfoId = user.checkoutInfoId,
                total = model.total,
                PaymentspaymentDetailsId =1,
                ModifiedDate = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow
            };
            _context.Order_details.Add(result);
            await _context.SaveChangesAsync();

            
                foreach (var product in model.productLists)
            {
                var oldOrderItems = await _context.Order_items.SingleOrDefaultAsync(s => s.orderItemsId == result.orderDetailsId && s.productId == product.productId);
                if (oldOrderItems != null)
                {
                    oldOrderItems.Quantity = oldOrderItems.Quantity + 1;
                    await _context.SaveChangesAsync();
                    
                }
                else
                {
                    Order_items orderItems = new Order_items
                    {
                        productId = product.productId,
                        orderDetailsId = result.orderDetailsId,
                        Quantity = 1,
                        ModifiedDate = DateTime.UtcNow,
                        CreatedDate = DateTime.UtcNow
                    };
                    _context.Order_items.Add(orderItems);
                    await _context.SaveChangesAsync();
                }
                //return Ok(orderItems);


            }

            var tblCartId = _context.TblCart.Where(s => s.MemberId == model.userId).FirstOrDefault();
            var tblCart = await _context.CartItems.Where(s => s.userId == tblCartId.MemberId).ToListAsync();
            if (tblCart == null)
            {
                return NotFound();
            }

            foreach (var item in tblCart)
            {
                _context.CartItems.Remove(item);
            }

            await _context.SaveChangesAsync();
            return Ok(emptyString);

            //}
        }



    }
}
