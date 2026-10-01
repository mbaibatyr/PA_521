namespace MySwagger
{
    public class ErrorResponse
    {
        /// <summary>
        /// Код или тип ошибки (например, "INVALID_PRODUCT_ID" или "ValidationError")
        /// </summary>
        public string ErrorCode { get; set; } = string.Empty;

        /// <summary>
        /// Человекопонятное описание того, что пошло не так
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Время возникновения ошибки
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
