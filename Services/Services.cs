using Refit;

public interface IOrderApi
{
    // ✅ جلب كل الطلبات
    [Get("/api/Res")]
    Task<List<ResWithOrderItemsDto>> GetAllOrders();

    // ✅ جلب الطلب حسب Id
    [Get("/api/Res/{id}")]
    Task<ResWithOrderItemsDto> GetOrder(int id);

    // ✅ إنشاء طلب جديد
    [Post("/api/Res")]
    Task<ResWithOrderItemsDto> CreateOrder([Body] ResWithOrderItemsDto order);

    // ✅ تعديل طلب
    [Put("/api/Res/{id}")]
    Task <ResWithOrderItemsDto> UpdateOrder(int id, [Body] ResWithOrderItemsDto order);

    // ✅ حذف طلب
    [Delete("/api/Res/{id}")]
    Task DeleteOrder(int id);
}
